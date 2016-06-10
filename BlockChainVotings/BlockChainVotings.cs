using NetworkCommsDotNet;
using NetworkCommsDotNet.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Virgil.Crypto;

namespace BlockChainVotings
{
    public class BlockChainVotings
    {
        VotingsDB db;
        Network net;

        public bool Started
        {
            get { return net.Started; }
        }

        System.Timers.Timer t;

        //блоки и транзакции, для проверки которых требуются дополнительные загрузки
        Dictionary<Block, DateTime> pendingBlocks;
        Dictionary<Transaction, DateTime> pendingTransactions;

        public event EventHandler<IntEventArgs> NewVoting;
        public event EventHandler<IntEventArgs> NewTransaction;
        public event EventHandler<IntEventArgs> NewUser;
        public event EventHandler<IntEventArgs> NewBlock;




        public BlockChainVotings()
        {

            NetworkComms.DisableLogging();
            if (File.Exists("BlockChainVotings_log.txt"))
                File.Delete("BlockChainVotings_log.txt");
            LiteLogger logger = new LiteLogger(LiteLogger.LogMode.ConsoleAndLogFile, "BlockChainVotings_log.txt");
            NetworkComms.EnableLogging(logger);


            db = new VotingsDB();
            net = new Network();

            db.ConnectToDBAsync();

            t = new System.Timers.Timer(CommonHelpers.PeersCheckInterval * 10);

            pendingBlocks = new Dictionary<Block, DateTime>();
            pendingTransactions = new Dictionary<Transaction, DateTime>();

            net.OnBlocksMessage += OnBlockMessage;
            net.OnRequestBlocksMessage += OnRequestBlocksMessage;
            net.OnRequestTransactionsMessage += OnRequestTransactionsMessage;
            net.OnTransactionsMessage += OnTransactionsMessage;

            t.Elapsed += CheckDeleteOldPendingItems;
        }



        public void Start()
        {

            net.OnPeerConnected += Net_OnPeerConnected;

            net.Connect();



        }

        private void Net_OnPeerConnected(object sender, MessageEventArgs e)
        {
            RequestLastBlock(e.SenderAddress);
            RequestLastFreeTransactions(e.SenderAddress);
        }

        public void Stop()
        {
            net.OnPeerConnected -= Net_OnPeerConnected;

            net.Disconnect();

        }

        private void CheckDeleteOldPendingItems(object sender, ElapsedEventArgs e)
        {
            var pendingBlocksCopy = new Dictionary<Block, DateTime>(pendingBlocks);

            foreach (var item in pendingBlocksCopy)
            {
                //если ожидающий блок старее 10 минут - проверяем, затем удаляем его
                if ((CommonHelpers.GetTime() - item.Value) > TimeSpan.FromMilliseconds(CommonHelpers.PeersCheckInterval * 10))
                {
                    CheckBlock(GetLastBlockFromPending(item.Key));
                    pendingBlocks.Remove(item.Key);
                    //отмечаем ожидающие транзакции из базы как свободные
                    db.MarkAsFreePendingTransactions(false, item.Key.Transactions);
                }
            }


            var pendingTransactionsCopy = new Dictionary<Transaction, DateTime>(pendingTransactions);

            foreach (var item in pendingTransactionsCopy)
            {
                //если ожидающая транзакция старее 10 минут - проверяем, затем удаляем ее
                if ((CommonHelpers.GetTime() - item.Value) > TimeSpan.FromMilliseconds(CommonHelpers.PeersCheckInterval * 10))
                {
                    CheckTransaction(item.Key);
                    pendingTransactions.Remove(item.Key);
                }
            }
        }

        private void OnTransactionsMessage(object sender, MessageEventArgs e)
        {
            Thread.Sleep(10);
            var message = e.Message as TransactionsMessage;

            foreach (var transaction in message.Transactions)
            {
                //если транзакция была в блоке, помечаем ее как транзакцию из непроверенного блока
                if (transaction.Status == TransactionStatus.InBlock)
                    transaction.Status = TransactionStatus.InPendingBlock;


                //проверка на существование транзакции с таким же хешем
                if (!pendingTransactions.Keys.Any(tr => tr.Hash == transaction.Hash))
                {
                    if (CheckTransaction(transaction, e.SenderAddress))
                    {
                        //если внесли хотя бы одну транзакцию в базу, отсылаем сообщение остальным пирам
                        net.SendMessageToAllPeers(message);
                    }
                }
            }
        }

        private void OnRequestTransactionsMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as RequestTransactionsMessage;
            var transactions = new List<Transaction>();
            foreach (var hash in message.Hashes)
            {
                var tr = db.GetTransaction(hash);
                if (tr != null)
                {
                    transactions.Add(tr);
                }
                else
                {
                    //если не нашли транзакцию, ищем по хешу пользователя
                    //сначала отсылаем бан, чтобы запросившая транзакция правильно проверялась
                    var userBan = db.GetUserBan(hash);
                    if (userBan != null) transactions.Add(userBan);

                    var userCreation = db.GetUserCreation(hash);
                    if (userCreation != null) transactions.Add(userCreation);
                }

            }


            if (message.Date > 0)
            {
                //получаем все свободные транзакции, а не только с даты, поскольку иногда дата указывается неверно в запросе (поздняя)
                //transactions.AddRange(db.GetFreeTransactionsFromDate(message.Date0, CommonHelpers.TransactionsInBlock));
                transactions.AddRange(db.GetFreeTransactions(CommonHelpers.TransactionsInBlock));
            }



            if (transactions.Count > 0)
            {
                var messageToSend = new TransactionsMessage(transactions);
                net.SendMessageToPeer(messageToSend, e.SenderAddress);
            }
        }

        private void OnRequestBlocksMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as RequestBlocksMessage;
            var blocks = new List<Block>();
            foreach (var hash in message.Hashes)
            {
                if (hash == "0") return;
                var block = db.GetBlock(hash);
                if (block != null) blocks.Add(block);
            }

            //если пришел пустой запрос, отсылаем последний блок
            if (message.Hashes.Count == 0)
            {
                blocks.Add(db.GetLastBlock());
            }

            var messageToSend = new BlocksMessage(blocks);
            net.SendMessageToPeer(messageToSend, e.SenderAddress);
        }

        private void OnBlockMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as BlocksMessage;

            foreach (var block in message.Blocks)
            {
                //проверка на существование блока с таким же хешем
                if (!pendingBlocks.Keys.Any(bl => bl.Hash == block.Hash))
                {
                    if (CheckBlock(block, e.SenderAddress))
                    {
                        //если внесли блок в базу, отсылаем его остальным пирам
                        net.SendMessageToAllPeers(message);
                    }

                }
            }
        }


        private void RequestBlock(string hash, EndPoint peerAddress = null)
        {
            var list = new List<string>();
            list.Add(hash);
            var message = new RequestBlocksMessage(list);

            if (peerAddress == null)
                net.SendMessageToAllPeers(message);
            else
                net.SendMessageToPeer(message, peerAddress);
        }



        void RequestLastBlock(EndPoint address = null)
        {
            var message = new RequestBlocksMessage(new List<string>());
            if (address != null)
            {
                net.SendMessageToPeer(message, address);
            }
            else
            {
                net.SendMessageToAllPeers(message);
            }
        }

        private void RequestTransaction(string hash, EndPoint peerAddress = null)
        {
            var list = new List<string>();
            list.Add(hash);
            var message = new RequestTransactionsMessage(list);

            if (peerAddress == null)
                net.SendMessageToAllPeers(message);
            else
                net.SendMessageToPeer(message, peerAddress);
        }

        private bool CheckBlock(Block block, EndPoint peerAddress = null)
        {

            if (db.GetBlock(block.Hash) != null) return false;

            var prevBlock = db.GetBlock(block.PreviousHash);
            var creator = db.GetUserCreation(block.CreatorHash);

            bool needWait = false;


            //проверка существования предыдущего блока
            if (prevBlock == null)
            {
                //если ее нет и в ожидающих - запрашиваем от пиров
                if (!pendingBlocks.Keys.Any(bl => bl.Hash == block.PreviousHash))
                    RequestBlock(block.PreviousHash, peerAddress);
                needWait = true;
            }


            //проверка существования создателя блока
            if (creator == null)
            {
                if (!pendingTransactions.Keys.Any(tr => tr.RecieverHash == block.CreatorHash))
                    RequestTransaction(block.CreatorHash, peerAddress);
                needWait = true;
            }

            if (block.Transactions == null) return false;

            //проверка существования транзакций
            foreach (var itemHash in block.Transactions)
            {
                if (db.GetTransaction(itemHash) == null)
                {
                    if (!pendingTransactions.Keys.Any(tr => tr.Hash == itemHash))
                        RequestTransaction(itemHash, peerAddress);
                    needWait = true;
                }
            }


            //если блок не в списке ожидающих и запросили инфу, то отправляем ее в список ожидающих
            if (needWait == true)
            {
                if (!pendingBlocks.ContainsKey(block))
                    pendingBlocks.Add(block, CommonHelpers.GetTime());
                return false;
            }


            ////если все данные есть, начинаем проверку блока

            //удаляем его из ожидающих
            pendingBlocks.Remove(block);


            //проверка хеша и подписи
            if (!(block.CheckHash() && block.CheckSignature())) return false;


            //проверка даты
            if (!(block.Date0 >= prevBlock.Date0 && block.Date0 <= CommonHelpers.GetTime())) return false;


            //проверка создателя блока
            //var senderCreation = db.GetUserCreation(block.CreatorHash);
            var senderBan = db.GetUserBan(block.CreatorHash);

            if (!(creator.Date0 <= block.Date0 &&
                (senderBan == null || senderBan.Date0 > block.Date0)))
                return false;



            //сравнение длины цепочки этого блока с длиной цепочки в базе
            var blockCopyInDB = db.GetBlock(block.Number);
            if (blockCopyInDB != null)
            {
                var lastBlockInChain = GetLastBlockFromPending(block);
                var lastBlockInDB = db.GetLastBlock();

                //если цепочка нового блока длиннее или цепочки равны, но дата нового блока раньше
                if ((lastBlockInChain.Number > lastBlockInDB.Number) ||
                    (lastBlockInChain.Number == lastBlockInDB.Number && block.Date0 < blockCopyInDB.Date0))
                {
                    //удаляем из базы все блоки начиная с этого
                    for (int i = blockCopyInDB.Number; i <= lastBlockInDB.Number; i++)
                    {
                        var blockToRemove = db.GetBlock(i);
                        db.DeleteBlock(blockToRemove);

                        //СПОРНЫЙ МОМЕНТ
                        //отмечаем транзакции из блока как свободные
                        db.MarkAsFreePendingTransactions(true, blockToRemove.Transactions);

                    }

                    //добавляем блок обратно в ожидающие
                    pendingBlocks.Add(block, CommonHelpers.GetTime());
                    //запускаем проверку последнего ожидающего блока из цепочки (он снова загрузит нужные транзакции)
                    CheckBlock(lastBlockInChain);

                }
                else
                {
                    //СПОРНЫЙ МОМЕНТ
                    //если не приняли новый блок, то освобождаем полученные для него транзакции
                    db.MarkAsFreePendingTransactions(false, block.Transactions);
                }


                NewTransaction?.Invoke(this, new IntEventArgs(db.TransactionsCount()));
                NewBlock?.Invoke(this, new IntEventArgs(db.BlocksCount()));

                return false;

            }


            //проверка транзакций
            foreach (var itemHash in block.Transactions)
            {
                var tr = db.GetTransaction(itemHash);
                if (tr.Status == TransactionStatus.InBlock || tr.Date0 > block.Date0) return false;
            }



            ////если все хорошо, добавляем блок в базу
            db.PutBlock(block);

            NetworkComms.Logger.Warn("Added block " + block.Hash);

            NewBlock?.Invoke(this, new IntEventArgs(db.BlocksCount()));

            //помечаем транзакции, что они в блоке
            foreach (var itemHash in block.Transactions)
            {
                var tr = db.GetTransaction(itemHash);
                db.MarkTransaction(tr, TransactionStatus.InBlock);
            }

            //ищем в ожидающих блоках связанные с этим и проверяем их
            var pending = pendingBlocks.Keys.Where(bl => bl.PreviousHash == block.Hash).ToList();
            foreach (var item in pending)
            {
                CheckBlock(item);
            }


            return true;
        }

        //рекурсивный поиск последнего блока в цепочке ожидающих
        private Block GetLastBlockFromPending(Block block)
        {
            var nextBlock = pendingBlocks.Keys.FirstOrDefault(bl => bl.PreviousHash == block.Hash);

            if (nextBlock == null) return block;
            else return GetLastBlockFromPending(nextBlock);
        }

        private bool CheckTransaction(Transaction transaction, EndPoint peerAddress = null)
        {

            if (db.GetTransaction(transaction.Hash) != null) return false;

            bool needWait = false;


            //проверка существования транзакции создания пользователя
            //если ее нет, то транзакция создания и бана пользователя запрашиваются
            if (db.GetUserCreation(transaction.SenderHash) == null)
            {
                //если ее нет и в ожидающих - запрашиваем от пиров
                if (!pendingTransactions.Keys.Any(tr => tr.RecieverHash == transaction.PreviousHash))
                    RequestTransaction(transaction.SenderHash, peerAddress);
                needWait = true;
            }

            //проверяем получателя транзакции только для транзакций бана и посылки голоса
            if ((transaction.Type == TransactionType.BanUser || transaction.Type == TransactionType.Vote)
                && (db.GetUserCreation(transaction.RecieverHash) == null))
            {
                if (!pendingTransactions.Keys.Any(tr => tr.RecieverHash == transaction.RecieverHash))
                    RequestTransaction(transaction.RecieverHash, peerAddress);
                needWait = true;
            }

            //проверка существования предыдущей транзакции
            if (db.GetTransaction(transaction.PreviousHash) == null)
            {
                if (!pendingTransactions.Keys.Any(tr => tr.Hash == transaction.PreviousHash))
                    RequestTransaction(transaction.PreviousHash, peerAddress);
                needWait = true;
            }


            //если транзакция не в списке ожидающих и запросили инфу, то отправляем ее в список ожидающих
            if (needWait == true)
            {
                if (!pendingTransactions.ContainsKey(transaction))
                    pendingTransactions.Add(transaction, CommonHelpers.GetTime());
                return false;
            }


            ////проверка транзакции

            //удаляем из ожидающих
            pendingTransactions.Remove(transaction);

            var checkPassed = true;

            switch (transaction.Type)
            {
                case TransactionType.CreateUser:
                    checkPassed = CheckCreateUserTransaction(transaction); break;
                case TransactionType.BanUser:
                    checkPassed = CheckBanUserTransaction(transaction); break;
                case TransactionType.Vote:
                    checkPassed = CheckVoteTransaction(transaction); break;
                case TransactionType.StartVoting:
                    checkPassed = CheckStartVotingTransaction(transaction); break;
                default:
                    checkPassed = false; break;
            }


            ////если транзакция проверена успешно
            if (checkPassed)
            {

                //добавляем транзакцию в базу
                db.PutTransaction(transaction);

                NetworkComms.Logger.Warn("Added transaction " + transaction.Type.ToString() + " " + transaction.Hash);

                NewTransaction?.Invoke(this, new IntEventArgs(db.TransactionsCount()));

                //если добавили новую транзакцию голосования, то вызываем событие
                if (transaction.Type == TransactionType.StartVoting)
                    NewVoting?.Invoke(this, new IntEventArgs(transaction.VotingNumber));
                else if (transaction.Type == TransactionType.CreateUser)
                    NewUser?.Invoke(this, new IntEventArgs(db.UsersCount()));

                //проверяем нужно ли создавать новый блок
                MakeBlock();

                //ищем в ожидающих транзакции связанные с этой и проверяем их
                var pending = pendingTransactions.Keys.Where(tr =>
                {
                    return tr.PreviousHash == transaction.Hash ||
                    tr.SenderHash == transaction.RecieverHash ||
                    tr.RecieverHash == transaction.RecieverHash;
                }).ToList();
                foreach (var item in pending)
                {
                    CheckTransaction(item);
                }


                //ищем в ожидающих блоках связанные с этим и проверяем их
                var pending2 = pendingBlocks.Keys.Where(bl =>
                {
                    return bl.TransactionsBlob.Contains(transaction.Hash)
                    || bl.CreatorHash == transaction.RecieverHash;
                }).ToList();
                foreach (var item in pending2)
                {
                    CheckBlock(item);
                }

                return true;
            }
            else return false;
        }

        bool CheckVoteTransaction(Transaction transaction)
        {
            var voting = db.GetTransaction(transaction.PreviousHash);

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            //проверка даты транзакции
            if (!(transaction.Date0 >= voting.Date0 && transaction.Date0 <= CommonHelpers.GetTime())) return false;

            var senderCreation = db.GetUserCreation(transaction.SenderHash);
            var senderBan = db.GetUserBan(transaction.SenderHash);
            ////проверка создателя транзакции
            //if (senderCreation == null) return false;
            //проверка даты создателя транзакции
            if (!(senderCreation.Date0 <= voting.Date0 &&
                (senderBan == null || senderBan.Date0 > voting.Date0)))
                return false;

            var recieverCreation = db.GetUserCreation(transaction.RecieverHash);
            var recieverBan = db.GetUserBan(transaction.RecieverHash);
            ////проверка получателя транзакции
            //if (recieverCreation == null) return false;
            //проверка даты получателя транзакции
            if (!(recieverCreation.Date0 <= voting.Date0 &&
                (recieverBan == null || recieverBan.Date0 > voting.Date0)))
                return false;

            var existsVote = db.GetUserVote(transaction.SenderHash, transaction.VotingNumber);
            //проверка существования копий транзакции
            if (existsVote != null)
            {
                //если копия уже в блоке то выход
                if (existsVote.Status == TransactionStatus.InBlock) return false;
                //если копия транзакции старее и при этом свободна, то выход
                else if (existsVote.Date0 <= transaction.Date0 && existsVote.Status == TransactionStatus.Free) return false;
                //иначе удаляем существующую транзакцию из базы 
                else
                {
                    db.DeleteTransaction(existsVote);
                    NewTransaction?.Invoke(this, new IntEventArgs(db.TransactionsCount()));
                }
            }

            return true;

        }

        bool CheckCreateUserTransaction(Transaction transaction)
        {

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            //проверка даты транзакции
            if (!(transaction.Date0 > VotingsUser.RootUserDate && transaction.Date0 <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;

            //проверка на существование пользователя
            if (db.GetUserCreation(transaction.RecieverHash) != null) return false;

            //проверка чтобы предыдущая транзакция не была новее
            if (transaction.Date0 < db.GetTransaction(transaction.PreviousHash).Date0) return false;


            var existsUser = db.GetSameUser(transaction);
            //проверка существования копий транзакции
            if (existsUser != null)
            {
                //если копия уже в блоке то выход
                if (existsUser.Status == TransactionStatus.InBlock) return false;
                //если копия транзакции старее и при этом свободна, то выход
                else if (existsUser.Date0 <= transaction.Date0 && existsUser.Status == TransactionStatus.Free) return false;
                //иначе удаляем существующую транзакцию из базы 
                else
                {
                    db.DeleteTransaction(existsUser);
                    NewTransaction?.Invoke(this, new IntEventArgs(db.TransactionsCount()));
                }
            }




            try
            {
                var info = JObject.Parse(transaction.Info);
                if (!(info["name"].Value<string>() != "" && info["id"].Value<string>() != "")) return false;
            }
            catch
            {
                return false;
            }


            return true;

        }

        bool CheckBanUserTransaction(Transaction transaction)
        {

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            //проверка даты транзакции
            if (!(transaction.Date0 >= VotingsUser.RootUserDate && transaction.Date0 <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;


            var recieverCreation = db.GetUserCreation(transaction.RecieverHash);
            //проверка на существование пользователя на заданную дату
            if (recieverCreation.Date0 > transaction.Date0) return false;



            var prevTransaction = db.GetTransaction(transaction.PreviousHash);

            //предыдущая транзакция и транзакция создания пользователя - одно и то же
            if (prevTransaction.Hash != recieverCreation.Hash) return false;
            //проверка чтобы предыдущая транзакция не была новее
            if (transaction.Date0 < prevTransaction.Date0) return false;


            var existsBan = db.GetUserBan(transaction.RecieverHash);
            //проверка существования копий транзакции
            if (existsBan != null)
            {
                //если копия уже в блоке то выход
                if (existsBan.Status == TransactionStatus.InBlock) return false;
                //если копия транзакции старее и при этом свободна, то выход
                else if (existsBan.Date0 <= transaction.Date0 && existsBan.Status == TransactionStatus.Free) return false;
                //иначе удаляем существующую транзакцию из базы 
                else
                {
                    db.DeleteTransaction(existsBan);
                    NewTransaction?.Invoke(this, new IntEventArgs(db.TransactionsCount()));
                }
            }



            try
            {
                var info = JObject.Parse(transaction.Info);
                if (!(info["cause"].Value<string>() != "")) return false;
            }
            catch
            {
                return false;
            }

            return true;

        }



        void RequestLastFreeTransactions(EndPoint address)
        {
            var date = db.GetLastTransaction().Date0;
            var message = new RequestTransactionsMessage(date);

            if (address != null)
            {
                net.SendMessageToPeer(message, address);
            }
            else
            {
                net.SendMessageToAllPeers(message);
            }

        }


        bool CheckStartVotingTransaction(Transaction transaction)
        {

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            var prevVoting = db.GetTransaction(transaction.PreviousHash);

            //проверка номера голосования
            if (transaction.VotingNumber != (prevVoting.VotingNumber + 1)) return false;

            //проверка даты транзакции
            if (!(transaction.Date0 >= prevVoting.Date0 && transaction.Date0 <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;


            var existsVoting = db.GetVoting(transaction.VotingNumber);
            //проверка существования копий транзакции
            if (existsVoting != null)
            {
                //если копия уже в блоке то выход
                if (existsVoting.Status == TransactionStatus.InBlock) return false;
                //если копия транзакции старее и при этом свободна, то выход
                else if (existsVoting.Date0 <= transaction.Date0 && existsVoting.Status == TransactionStatus.Free) return false;
                //иначе удаляем существующую транзакцию из базы 
                else
                {
                    db.DeleteTransaction(existsVoting);
                    NewTransaction?.Invoke(this, new IntEventArgs(db.TransactionsCount()));
                }
            }


            try
            {
                var info = JObject.Parse(transaction.Info);
                if (!(info["name"].Value<string>() != "")) return false;

                if (info["candidates"].Count() == 0) return false;

                foreach (JToken item in info["candidates"])
                {
                    if (item.Value<string>() == "") return false;
                }
            }
            catch
            {
                return false;
            }

            return true;

        }

        public void CheckRoot()
        {

            var root = Transaction.CreateUserTransacton(VotingsUser.RootPublicKey, "Root", "0", "0");
            root.SenderHash = VotingsUser.RootPublicKey;
            root.Date0 = VotingsUser.RootUserDate;
            root.Hash = root.CalcHash();
            root.Signature = VotingsUser.RootCreationSignature;
            root.Status = TransactionStatus.InBlock;

            var voting = Transaction.StartVotingTransation(new List<string>(), "0", 0, "0");
            voting.SenderHash = VotingsUser.RootPublicKey;
            voting.Date0 = VotingsUser.RootUserDate;
            voting.Hash = voting.CalcHash();
            voting.Signature = VotingsUser.FirstVotingSignature;
            voting.Status = TransactionStatus.InBlock;

            var transactions = new List<Transaction>();
            transactions.Add(root);
            transactions.Add(voting);

            var block = new Block();
            block.CreatorHash = VotingsUser.RootPublicKey;
            block.Date0 = VotingsUser.RootUserDate;
            block.Number = 0;
            block.PreviousHash = "0";
            block.Transactions = transactions.Select(tr => tr.Hash).ToList();
            block.Hash = block.CalcHash();
            block.Signature = VotingsUser.FirstBlockSignature;


            var rootInDB = db.GetUserCreation(VotingsUser.RootPublicKey);
            var votingInDB = db.GetVoting(0);
            var blockInDB = db.GetBlock(0);

            //если транзакции нет в базе или она ошибочна, обнуляем базу и вносим транзакцию в нее
            if (rootInDB == null || votingInDB == null || blockInDB == null
                /*root.Hash != rootInDB.Hash || root.Info != rootInDB.Info || root.PreviousHash != rootInDB.PreviousHash ||
                root.RecieverHash != rootInDB.RecieverHash || root.SenderHash != rootInDB.SenderHash || 
                root.Signature != rootInDB.Signature || root.Type != rootInDB.Type || root.VotingNumber!=rootInDB.VotingNumber*/)
            {
                db.Clear();
                db.PutTransaction(root);
                db.PutTransaction(voting);
                db.PutBlock(block);
            }
            else
            {
                //освобождаем ожидающие транзакции, чтобы не засоряли базу
                db.MarkAsFreePendingTransactions(false);
            }


            NetworkComms.Logger.Warn("Database root checked");

        }

        private void MakeBlock()
        {

            var transactions = db.GetFreeTransactions(CommonHelpers.TransactionsInBlock);

            if (transactions.Count < CommonHelpers.TransactionsInBlock || !VotingsUser.CreateOwnBlocks) return;

            //помечаем их как ожидающие, поскольку сейчас создадим блок
            foreach (var item in transactions)
            {
                db.MarkTransaction(item, TransactionStatus.InPendingBlock);
            }


            var lastBlock = db.GetLastBlock();
            var newBlock = new Block(transactions, lastBlock);

            //проверка блока и добавление его в базу
            if (CheckBlock(newBlock))
            {
                //отправка блока всем клиентам
                var list = new List<Block>();
                list.Add(newBlock);
                var message = new BlocksMessage(list);

                net.SendMessageToAllPeers(message);
            }


        }

        public void CreateVote(string candidateHash, string votingHash)
        {
            var voting = db.GetTransaction(votingHash);
            var vote = Transaction.VoteTransaction(candidateHash, voting.Hash, voting.VotingNumber);

            if (CheckTransaction(vote))
            {
                var list = new List<Transaction>();
                list.Add(vote);
                var message = new TransactionsMessage(list);

                net.SendMessageToAllPeers(message);

            }
        }


        public void CreateVoting(List<string> candidatesHashes, string votingName)
        {
            var prevVoting = db.GetLastVoting();
            var voting = Transaction.StartVotingTransation(candidatesHashes, votingName, prevVoting.VotingNumber + 1, prevVoting.Hash);

            if (CheckTransaction(voting))
            {
                var list = new List<Transaction>();
                list.Add(voting);
                var message = new TransactionsMessage(list);

                net.SendMessageToAllPeers(message);

            }
        }


        public void CreateUser(string publicKey, string name, string id)
        {
            var user = Transaction.CreateUserTransacton(publicKey, name, id, db.GetLastUserCreation().Hash);

            if (CheckTransaction(user))
            {
                var list = new List<Transaction>();
                list.Add(user);
                var message = new TransactionsMessage(list);

                net.SendMessageToAllPeers(message);

            }

        }


        public void BanUser(string publicKey, string cause)
        {
            var prevTransaction = db.GetUserCreation(publicKey);

            var userBan = Transaction.BanUserTransaction(cause, publicKey, prevTransaction.Hash);

            if (CheckTransaction(userBan))
            {
                var list = new List<Transaction>();
                list.Add(userBan);
                var message = new TransactionsMessage(list);

                net.SendMessageToAllPeers(message);

            }

        }



        public List<Transaction> SearchUsers(string nameIdHash)
        {
            return db.SearchUsers(nameIdHash);
        }

        public List<Transaction> GetOpenedVotings()
        {
            return db.GetUserOpenedVotings();
        }

        public List<Transaction> GetVotings()
        {
            return db.GetVotings();
        }





        public List<Transaction> GetCandidates(Transaction voting)
        {
            return db.GetCandidates(voting);
        }


        public Dictionary<Transaction, int> GetCandidatesResults(Transaction voting)
        {
            return db.GetCandidatesResults(voting);
        }

        public Dictionary<Transaction, Transaction> GetUserVotesAndVotings(string userHash)
        {
            return db.GetUserVotesAndVotings(userHash);
        }


        public Transaction GetUserBan(string userHash)
        {
            return db.GetUserBan(userHash);
        }

        public Transaction GetUserCreation(string userHash)
        {
            return db.GetUserCreation(userHash);
        }


        public string GetVotingName(int num)
        {
            var voting = db.GetVoting(num);

            return "№" + voting.VotingNumber + " " + JObject.Parse(voting.Info)["name"];
        }


        public int GetUsersCount()
        {
            return db.UsersCount();
        }

        public int GetTransactionsCount()
        {
            return db.TransactionsCount();
        }

        public int GetBlocksCount()
        {
            return db.BlocksCount();
        }


        public int GetUserAsCandiddateCount(string userHash)
        {
            return db.UserAsCandidateCount(userHash);
        }


        public string GetMyName()
        {
            var me = SearchUsers(VotingsUser.PublicKey);

            if (me.Count > 0)
                return JObject.Parse(me[0].Info)["name"].Value<string>();
            else
                return null;

        }
    }
}

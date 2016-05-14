using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BlockChainVotings
{
    public class BlockChainVotings
    {
        VotingsDB db;
        Network net;

        Timer t;
        DateTime curTime;

        //блоки и транзакции, для проверки которых требуются дополнительные загрузки
        Dictionary<Block, DateTime> pendingBlocks;
        Dictionary<Transaction, DateTime> pendingTransactions;


        public BlockChainVotings()
        {
            db = new VotingsDB();
            net = new Network();

            pendingBlocks = new Dictionary<Block, DateTime>();
            pendingTransactions = new Dictionary<Transaction, DateTime>();

            net.OnBlocksMessage += OnBlockMessage;
            net.OnRequestBlocksMessage += OnRequestBlocksMessage;
            net.OnRequestTransactionsMessage += OnRequestTransactionsMessage;
            net.OnTransactionsMessage += OnTransactionsMessage;

            t.Elapsed += DeleteOldPendingItems;
        }

        private void DeleteOldPendingItems(object sender, ElapsedEventArgs e)
        {
            var pendingBlocksCopy = new Dictionary<Block, DateTime>(pendingBlocks);

            foreach (var item in pendingBlocksCopy)
            {
                //если ожидающий блок старее 1 часа - удаляем его
                if ((CommonHelpers.GetTime() - item.Value) > TimeSpan.FromHours(1)) pendingBlocks.Remove(item.Key);
            }


            var pendingTransactionsCopy = new Dictionary<Transaction, DateTime>(pendingTransactions);

            foreach (var item in pendingTransactionsCopy)
            {
                //если ожидающая транзакция старее 1 часа - удаляем ее
                if ((CommonHelpers.GetTime() - item.Value) > TimeSpan.FromHours(1)) pendingTransactions.Remove(item.Key);
            }
        }

        private void OnTransactionsMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as TransactionsMessage;

            foreach (var transaction in message.Transactions)
            {
                //проверка на существование транзакции с таким же хешем
                if (db.GetTransaction(transaction.Hash) == null && !pendingTransactions.Keys.Any(tr => tr.Hash == transaction.Hash))
                    CheckTransaction(transaction);
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
                    transactions.Add(tr);
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
                var block = db.GetBlock(hash);
                if (block != null) blocks.Add(block);
            }

            //если пришел пустой запрос, отсылаем последний блок
            if (blocks.Count == 0)
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
                if (db.GetBlock(block.Hash) == null && !pendingBlocks.Keys.Any(bl => bl.Hash == block.Hash))
                    CheckBlock(block);
            }
        }


        public void CreateVote(string recieverHash, int votingNumber)
        {
            //создаем транзакцию
            //отсылаем ее всем
        }


        public void RequestBlock(string hash, EndPoint peerAddress = null)
        {
            var list = new List<string>();
            list.Add(hash);
            var message = new RequestBlocksMessage(list);

            if (peerAddress == null)
                net.SendMessageToAllPeers(message);
            else
                net.SendMessageToPeer(message, peerAddress);
        }


        public void RequestTransaction(string hash, EndPoint peerAddress = null)
        {
            var list = new List<string>();
            list.Add(hash);
            var message = new RequestTransactionsMessage(list);

            if (peerAddress == null)
                net.SendMessageToAllPeers(message);
            else
                net.SendMessageToPeer(message, peerAddress);
        }

        void MakeBlock()
        {
            //по алгоритму
        }


        public bool CheckBlock(Block block)
        {

            var prevBlock = db.GetBlock(block.PreviousHash);
            var creator = db.GetUserCreation(block.CreatorHash);

            bool needWait = true;


            //проверка существования предыдущего блока
            if (prevBlock == null)
            {
                RequestBlock(block.PreviousHash);
                needWait = true;
            }


            //проверка существования создателя блока
            if (creator == null)
            {
                RequestTransaction(block.CreatorHash);
                needWait = true;
            }

            //проверка существования транзакций
            foreach (var itemHash in block.Transactions)
            {
                if (db.GetTransaction(itemHash) == null)
                {
                    RequestTransaction(itemHash);
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
            if (!(block.Date >= prevBlock.Date && block.Date <= CommonHelpers.GetTime())) return false;


            //проверка создателя блока
            //var senderCreation = db.GetUserCreation(block.CreatorHash);
            var senderBan = db.GetUserBan(block.CreatorHash);

            if (!(creator.Date <= block.Date &&
                (senderBan == null || senderBan.Date > block.Date)))
                return false;


            //проверка транзакций
            foreach (var itemHash in block.Transactions)
            {
                var tr = db.GetTransaction(itemHash);
                if (tr.InBlock == true || tr.Date > block.Date) return false;
            }



            //сравнение длины цепочки этого блока с длиной цепочки в базе
            var blockCopyInDB = db.GetBlock(block.Number);
            if (blockCopyInDB != null)
            {
                var lastBlockInChain = GetLastBlockFromPending(block);
                var lastBlockInDB = db.GetLastBlock();

                //если цепочка нового блока длинее или цепочки равны, но дата нового блока раньше
                if ((lastBlockInChain.Number > lastBlockInDB.Number) ||
                    (lastBlockInChain.Number == lastBlockInDB.Number && block.Date < blockCopyInDB.Date))
                {
                    //удаляем из базы все блоки начиная с этого
                    for (int i = blockCopyInDB.Number; i < lastBlockInDB.Number; i++)
                    {
                        var blockToRemove = db.GetBlock(i);
                        db.DeleteBlock(blockToRemove);
                    }
                }
                else return false;

            }



            ////если все хорошо, добавляем блок в базу
            db.PutBlock(block);

            //ищем в ожидающих блоках связанные с этим и проверяем их
            var pending = pendingBlocks.Keys.Where(bl => bl.PreviousHash == block.Hash);
            foreach (var item in pending)
            {
                CheckBlock(item);
            }

            return true;
        }

        //рекурсивный поиск последнего блока в цепочке ожидающих
        private Block GetLastBlockFromPending(Block block)
        {
            var nextBlock = pendingBlocks.Keys.First(bl => bl.PreviousHash == block.Hash);

            if (nextBlock == null) return block;
            else return GetLastBlockFromPending(nextBlock);
        }


        public bool CheckTransaction(Transaction transaction)
        {

            bool needWait = true;


            //проверка существования транзакции создания пользователя
            //если ее нет, то транзакция создания и бана пользователя запрашиваются
            if (db.GetUserCreation(transaction.SenderHash) == null)
            {
                RequestTransaction(transaction.SenderHash);
                needWait = false;
            }

            //проверяем получателя транзакции только для транзакций бана и посылки голоса
            if ((transaction.Type != TransactionType.StartVoting || transaction.Type != TransactionType.CreateUser)
                && (db.GetUserCreation(transaction.RecieverHash) == null))
            {
                RequestTransaction(transaction.RecieverHash);
                needWait = false;
            }

            //проверка существования предыдущей транзакции
            if (db.GetTransaction(transaction.PreviousHash) == null)
            {
                RequestTransaction(transaction.PreviousHash);
                needWait = false;
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

            var checkPass = true;

            switch (transaction.Type)
            {
                case TransactionType.CreateUser:
                    checkPass = CheckCreateUserTransaction(transaction); break;
                case TransactionType.BanUser:
                    checkPass = CheckBanUserTransaction(transaction); break;
                case TransactionType.Vote:
                    checkPass = CheckVoteTransaction(transaction); break;
                case TransactionType.StartVoting:
                    checkPass = CheckStartVotingTransaction(transaction); break;
                default:
                    checkPass = false; break;
            }


            ////если транзакция проверена успешно
            if (checkPass)
            {

                //добавляем транзакцию в базу
                db.PutTransaction(transaction);
                


                //ищем в ожидающих транзакции связанные с этой и проверяем их
                var pending = pendingTransactions.Keys.Where(tr => tr.PreviousHash == transaction.Hash);
                foreach (var item in pending)
                {
                    CheckTransaction(item);
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
            if (!(transaction.Date >= voting.Date && transaction.Date <= CommonHelpers.GetTime())) return false;

            var senderCreation = db.GetUserCreation(transaction.SenderHash);
            var senderBan = db.GetUserBan(transaction.SenderHash);
            ////проверка создателя транзакции
            //if (senderCreation == null) return false;
            //проверка даты создателя транзакции
            if (!(senderCreation.Date <= voting.Date &&
                (senderBan == null || senderBan.Date > voting.Date)))
                return false;

            var recieverCreation = db.GetUserCreation(transaction.RecieverHash);
            var recieverBan = db.GetUserBan(transaction.RecieverHash);
            ////проверка получателя транзакции
            //if (recieverCreation == null) return false;
            //проверка даты получателя транзакции
            if (!(recieverCreation.Date <= voting.Date &&
                (recieverBan == null || recieverBan.Date > voting.Date)))
                return false;

            var existsVote = db.GetUserVote(transaction.SenderHash, transaction.VotingNumber);
            //проверка существования копий транзакции
            if (existsVote != null)
            {
                //если копия уже в блоке то выход
                if (existsVote.InBlock) return false;
                //если копия транзакции старее то выход
                else if (existsVote.Date < transaction.Date) return false;
                //иначе удаляем сущесвующую транзакцию из базы
                else db.DeleteTransaction(existsVote);
            }

            return true;

        }

        bool CheckCreateUserTransaction(Transaction transaction)
        {

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            //проверка даты транзакции
            if (!(transaction.Date >= VotingsUser.RootUserDate && transaction.Date <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;

            //проверка на существование пользователя
            if (db.GetUserCreation(transaction.RecieverHash) != null) return false;

            //проверка чтобы предыдущая транзакция не была новее
            if (transaction.Date < db.GetTransaction(transaction.PreviousHash).Date) return false;

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
            if (!(transaction.Date >= VotingsUser.RootUserDate && transaction.Date <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;


            var recieverCreation = db.GetUserCreation(transaction.RecieverHash);
            //проверка на существование пользователя на заданную дату
            if (recieverCreation.Date > transaction.Date) return false;
            if (db.GetUserBan(transaction.RecieverHash) != null) return false;


            var prevTransaction = db.GetTransaction(transaction.PreviousHash);

            //предыдущая транзакция и транзакция создания пользователя - одно и то же
            if (prevTransaction.Hash != recieverCreation.Hash) return false;
            //проверка чтобы предыдущая транзакция не была новее
            if (transaction.Date < prevTransaction.Date) return false;


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

        bool CheckStartVotingTransaction(Transaction transaction)
        {

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            var prevVoting = db.GetTransaction(transaction.PreviousHash);

            //проверка номера голосования
            if (transaction.VotingNumber != (prevVoting.VotingNumber - 1)) return false;

            //проверка даты транзакции
            if (!(transaction.Date >= prevVoting.Date && transaction.Date <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;

            //проверка на существование голосования с таким же номером
            if (db.GetVoting(transaction.VotingNumber) != null) return false;


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

        void CheckDBRoot()
        {

        }

        void ReadMyInfo(string hash)
        {
            //получаем из бд транзакцию с нашим хешем
        }



    }
}

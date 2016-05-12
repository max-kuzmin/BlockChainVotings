using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public BlockChainVotings()
        {
            db = new VotingsDB();
            net = new Network();

            net.OnBlocksMessage += OnBlockMessage;
            net.OnRequestBlocksMessage += OnRequestBlocksMessage;
            net.OnRequestTransactionsMessage += OnRequestTransactionsMessage;
            net.OnTransactionsMessage += OnTransactionsMessage;
        }

        private void OnTransactionsMessage(object sender, MessageEventArgs e)
        {
            //проверка транзакции и добавление в базу данных
        }

        private void OnRequestTransactionsMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as RequestTransactionsMessage;
            var transactions = new List<Transaction>();
            foreach (var hash in message.Hashes)
            {
                var tr = db.GetTransaction(hash);
                if (tr != null) transactions.Add(tr);
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
            //проверка блока и добавление в базу данных
        }


        public void CreateVote(string recieverHash, int votingNumber)
        {
            //создаем транзакцию
            //отсылаем ее всем
        }


        public void RequestBlock(string hash)
        {
            //запрос блока, на него приходит блок
            //если послать пустой запрос, то должен прийти последний блок
        }

        void MakeBlock()
        {
            //по алгоритму
        }

        bool CheckBlock(Block block)
        {
            
        }


        public bool CheckTransaction(Transaction transaction)
        {
            switch (transaction.Type)
            {
                case TransactionType.CreateUser:
                    return CheckCreateUserTransaction(transaction);
                case TransactionType.BanUser:
                    return CheckBanUserTransaction(transaction);
                case TransactionType.Vote:
                    return CheckVoteTransaction(transaction);
                case TransactionType.StartVoting:
                    return CheckStartVotingTransaction(transaction);
                default:
                    return false;
            }
        }

        bool CheckVoteTransaction(Transaction transaction)
        {
            //проверка на существование транзакции с таким же хешем
            if (db.GetTransaction(transaction.Hash) != null) return false;

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            var voting = db.GetTransaction(transaction.PreviousHash);

            //проверка существования голосования
            if (voting == null) return false;

            //проверка даты транзакции
            if (!(transaction.Date >= voting.Date && transaction.Date <= CommonHelpers.GetTime())) return false;

            var senderCreation = db.GetUserCreation(transaction.SenderHash);
            var senderBan = db.GetUserBan(transaction.SenderHash);
            //проверка создателя транзакции
            if (!(senderCreation.Date <= voting.Date &&
                (senderBan == null || senderBan.Date > voting.Date)))
                return false;

            var recieverCreation = db.GetUserCreation(transaction.RecieverHash);
            var recieverBan = db.GetUserBan(transaction.RecieverHash);
            //проверка получателя транзакции
            if (!(recieverCreation.Date <= voting.Date &&
                (recieverBan == null || recieverBan.Date > voting.Date)))
                return false;

            var existsVote = db.GetUserVote(transaction.SenderHash, transaction.VotingNumber);
            //проверка существования копий транзакции
            if (existsVote != null)
            {
                if (existsVote.InBlock) return false;
                else if (existsVote.Date < transaction.Date) return false;
                else db.DeleteTransaction(existsVote);
            }

            return true;

        }

        bool CheckCreateUserTransaction(Transaction transaction)
        {
            //проверка на существование транзакции с таким же хешем
            if (db.GetTransaction(transaction.Hash) != null) return false;

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            //проверка даты транзакции
            if (!(transaction.Date >= VotingsUser.RootUserDate && transaction.Date <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;

            //проверка на существование пользователя
            if (db.GetTransaction(transaction.RecieverHash) != null) return false;

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
            //проверка на существование транзакции с таким же хешем
            if (db.GetTransaction(transaction.Hash) != null) return false;

            //проверка хеша и подписи
            if (!(transaction.CheckHash() && transaction.CheckSignature())) return false;

            //проверка даты транзакции
            if (!(transaction.Date >= VotingsUser.RootUserDate && transaction.Date <= CommonHelpers.GetTime())) return false;

            //проверка, что транзакцию создал корневой клиент
            if (transaction.SenderHash != VotingsUser.RootPublicKey) return false;

            //проверка на существование пользователя
            if (db.GetUserCreation(transaction.RecieverHash) != null) return false;
            if (db.GetUserBan(transaction.RecieverHash) == null) return false;


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
            //проверка на существование транзакции с таким же хешем
            if (db.GetTransaction(transaction.Hash) != null) return false;

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

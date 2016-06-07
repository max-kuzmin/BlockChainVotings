using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainVotings;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTestVotingDB
    {

        VotingsDB db;
        SQLiteAsyncConnection db0;

        string[] keys = CommonHelpers.GetPublicPrivateKeys();
        string userName = "userName";
        string userId = "222";
        string votingName = "votingName";
        string prevHash = "0";
        string cause = "0";
        int votingNum = 1;
        int blockNum = 1;

        Block block;


        Transaction ban, user, voting, vote;

        public UnitTestVotingDB()
        {

            db = new VotingsDB();
            db.ConnectToDBAsync();
            db.Clear();

            //создаем подключение к БД
            string dbPath = Path.Combine(Environment.CurrentDirectory, "VotingsDB.db3");
            db0 = new SQLiteAsyncConnection(dbPath);
            

            VotingsUser.PrivateKey = keys[1];
            VotingsUser.PublicKey = keys[0];

            //создаем тестовые транзакции
            user = Transaction.CreateUserTransacton(VotingsUser.PublicKey, userName, userId, prevHash);

            var list = new List<string>();
            list.Add(VotingsUser.PublicKey);
            voting = Transaction.StartVotingTransation(list, votingName, votingNum, prevHash);

            vote = Transaction.VoteTransaction(VotingsUser.PublicKey, voting.Hash, votingNum);

            ban = Transaction.BanUserTransaction(cause, VotingsUser.PublicKey, prevHash);

            db0.InsertAsync(user).Wait();
            db0.InsertAsync(voting).Wait();
            db0.InsertAsync(vote).Wait();
            db0.InsertAsync(ban).Wait();


            //тестоввый блок
            var trs = new List<Transaction>();
            trs.Add(ban);
            trs.Add(vote);
            trs.Add(voting);
            trs.Add(user);

            block = new Block(trs, new Block());
            block.PreviousHash = prevHash;
            block.Number = blockNum;
            db0.InsertAsync(block).Wait();
        } 

        [TestMethod]
        public void TestMethodTransactions()
        {
            //проверка поиска траназкций
            db0.DeleteAsync(ban).Wait();
            Assert.IsTrue(db.SearchUsers(userName).Count == 1);
            Assert.IsTrue(db.SearchUsers(VotingsUser.PublicKey).Count == 1);
            Assert.IsTrue(db.SearchUsers(userId).Count == 1);
            db0.InsertAsync(ban).Wait();
            Thread.Sleep(1000);


            Assert.IsTrue(db.GetTransaction(user.Hash).Hash == user.Hash);
            Assert.IsTrue(db.TransactionsCount() == 4);
            Assert.IsTrue(db.UsersCount() == 1);
            Assert.IsTrue(db.UserAsCandidateCount(VotingsUser.PublicKey) == 1);
            Assert.IsTrue(db.GetVoting(votingNum).Hash == voting.Hash);
            Assert.IsTrue(db.GetLastVoting().Hash == voting.Hash);
            Assert.IsTrue(db.GetLastVoting().Hash == voting.Hash);
            Assert.IsTrue(db.GetUserCreation(VotingsUser.PublicKey).Hash == user.Hash);

            Assert.IsTrue(db.GetLastUserCreation().Hash == user.Hash);
            Assert.IsTrue(db.GetLastTransaction().Hash == ban.Hash);
            Assert.IsTrue(db.GetFreeTransactionsFromDate(new DateTime(2015,1,1), 10).Count == 4);
            Assert.IsTrue(db.GetSameUser(user) == null);
            Assert.IsTrue(db.GetUserBan(VotingsUser.PublicKey).Hash == ban.Hash);
            Assert.IsTrue(db.GetUserVote(VotingsUser.PublicKey, votingNum).Hash == vote.Hash);
            Assert.IsTrue(db.GetVotings().Count == 1);

            var results = db.GetCandidatesResults(voting);
            Assert.IsTrue(results.Count == 1 && results.Keys.First().Hash == user.Hash && results.Values.First() == 1);

            var results2 = db.GetCandidates(voting);
            Assert.IsTrue(results2.Count == 1 && results2[0].Hash == user.Hash);

            var results3 = db.GetUserVotesAndVotings(VotingsUser.PublicKey);
            Assert.IsTrue(results3.Count == 1 && results3.Keys.First().Hash == voting.Hash && results3.Values.First().Hash == vote.Hash);

            Assert.IsTrue(db.GetUserOpenedVotings().Count == 0);
            Assert.IsTrue(db.GetUserVotes(VotingsUser.PublicKey).Count == 1);
            Assert.IsTrue(db.GetUserVotes(VotingsUser.PublicKey).Count == 1);
            Assert.IsTrue(db.GetFreeTransactions(10).Count == 4);

            //проверка пометки статуса транзакций
            ban.Status = TransactionStatus.InPendingBlock;
            db0.UpdateAsync(ban);
            db.MarkAsFreePendingTransactions(true);
            Assert.IsTrue(db.GetTransaction(ban.Hash).Status == TransactionStatus.Free);

            ban.Status = TransactionStatus.InBlock;
            db0.UpdateAsync(ban);
            db.MarkAsFreePendingTransactions(false);
            Assert.IsTrue(db.GetTransaction(ban.Hash).Status == TransactionStatus.InBlock);
        }


        [TestMethod]
        public void TestMethodBlocks()
        {
            Assert.IsTrue(db.GetBlock(block.Hash).Hash == block.Hash);
            Assert.IsTrue(db.BlocksCount() == 1);
            Assert.IsTrue(db.GetBlock(blockNum).Hash == block.Hash);
            Assert.IsTrue(db.GetLastBlock().Hash == block.Hash);
        }
    }
}

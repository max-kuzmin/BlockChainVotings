using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{


    public class VotingsDB
    {

        SQLiteAsyncConnection dbAsync = null;


        void ConnectToDBAsync()
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "VotingsDB.db3");
            dbAsync = new SQLiteAsyncConnection(dbPath);
            dbAsync.CreateTableAsync<Transaction>().Wait();
            dbAsync.CreateTableAsync<Block>().Wait();
        }

        public Transaction GetTransaction(string hash)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Hash == hash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public Block GetBlock(string hash)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Block>().Where(bl => bl.Hash == hash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public Block GetBlock(int number)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Block>().Where(bl => bl.Number == number);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Block GetLastBlock()
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Block>().OrderBy(block => block.Date);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetVoting(int number)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.StartVoting && tr.VotingNumber == number);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetUserCreation(string userHash)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.CreateUser && tr.Hash == userHash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public Transaction GetUserBan(string userHash)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.BanUser && tr.Hash == userHash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetUserVote(string userHash, int votingNumber)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.Vote && tr.Hash == userHash && tr.VotingNumber == votingNumber);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }



        public void PutTransaction(Transaction item)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            dbAsync.InsertAsync(item);
        }

        public void DeleteTransaction(Transaction item)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            dbAsync.DeleteAsync(item);
        }


        public void PutBlock(Block item)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            dbAsync.InsertAsync(item);
        }


        public void MarkTransactionAsInBlock(Transaction item)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            item.InBlock = true;
            dbAsync.UpdateAsync(item);
        }

        public List<Transaction> GetFreeTransactions(int count)
        {
            //if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.InBlock == false);
            query = query.OrderBy(tr => tr.Date).Take(count);
            var elems = query.ToListAsync();
            elems.Wait();

            return elems.Result;

        }


    }
}

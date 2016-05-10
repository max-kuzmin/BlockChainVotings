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
            string dbPath = Path.Combine(Environment.CurrentDirectory, "VotingsDB.db3"));
            dbAsync = new SQLiteAsyncConnection(dbPath);
            dbAsync.CreateTableAsync<Transaction>().Wait();
            dbAsync.CreateTableAsync<Block>().Wait();
        }

        public Transaction GetTransaction(string hash)
        {
            if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Hash == hash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public Block GetBlock(string hash)
        {
            if (dbAsync == null) ConnectToDBAsync();

            var query = dbAsync.Table<Block>().Where(bl => bl.Hash == hash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }



        public void PutTransaction(Transaction item)
        {
            if (dbAsync == null) ConnectToDBAsync();

            dbAsync.InsertAsync(item);
        }


        public void PutBlock(Block item)
        {
            if (dbAsync == null) ConnectToDBAsync();

            dbAsync.InsertAsync(item);
        }


    }
}

using Newtonsoft.Json.Linq;
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


        public void ConnectToDBAsync()
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "VotingsDB.db3");
            dbAsync = new SQLiteAsyncConnection(dbPath);
            dbAsync.CreateTableAsync<Transaction>().Wait();
            dbAsync.CreateTableAsync<Block>().Wait();
        }

        public Transaction GetTransaction(string hash)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Hash == hash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public Block GetBlock(string hash)
        {
            var query = dbAsync.Table<Block>().Where(bl => bl.Hash == hash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }



        public int BlocksCount()
        {
            var query = dbAsync.Table<Block>().CountAsync();
            query.Wait();
            return query.Result;
        }


        public int TransactionsCount()
        {
            var query = dbAsync.Table<Transaction>().CountAsync();
            query.Wait();
            return query.Result;
        }


        public int UsersCount()
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.CreateUser);
            var elem = query.CountAsync();
            elem.Wait();

            return elem.Result;
        }

        public Block GetBlock(int number)
        {
            var query = dbAsync.Table<Block>().Where(bl => bl.Number == number);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Block GetLastBlock()
        {
            var query = dbAsync.Table<Block>().OrderByDescending(block => block.Date);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetVoting(int number)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.StartVoting && tr.VotingNumber == number);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public Transaction GetLastVoting()
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.StartVoting);
            var elem = query.OrderByDescending(tr => tr.VotingNumber).FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetUserCreation(string userHash)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.CreateUser && tr.RecieverHash == userHash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public List<Transaction> SearchUsers(string nameIdHash)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.CreateUser && 
            (tr.Info.Contains(nameIdHash) || tr.RecieverHash == nameIdHash));
            var elem = query.ToListAsync();
            elem.Wait();

            var result = new List<Transaction>();

            foreach (var item in elem.Result)
            {
                //проверяем, не забанен ли пользователь
                if (GetUserBan(item.RecieverHash) == null)
                    result.Add(item);
            }

            return result;
        }




        public Transaction GetLastUserCreation()
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.CreateUser);
            var elem = query.OrderByDescending(tr => tr.Date).FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetLastTransaction()
        {
            var query = dbAsync.Table<Transaction>();
            var elem = query.OrderByDescending(tr => tr.Date).FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }

        public List<Transaction> GetFreeTransactionsFromDate(DateTime date, int count)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Date > date.Ticks && tr.Status == TransactionStatus.Free);
            var elems = query.Take(count).ToListAsync();
            elems.Wait();
            return elems.Result;
        }


        public void DeletePendingTransactions(List<string> transactions = null)
        {
            if (transactions == null)
            {
                var query = dbAsync.Table<Transaction>().Where(tr => tr.Status == TransactionStatus.InPendingBlock);
                var elems = query.ToListAsync();
                elems.Wait();

                foreach (Transaction item in elems.Result)
                {
                    dbAsync.DeleteAsync(item).Wait();
                }
            }
            else
            {
                foreach (var item in transactions)
                {
                    var tr = GetTransaction(item);
                    if (tr.Status == TransactionStatus.InPendingBlock)
                        DeleteTransaction(tr);
                }
            }

        }





        public Transaction GetUserBan(string userHash)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.BanUser && tr.RecieverHash == userHash);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }


        public Transaction GetUserVote(string userHash, int votingNumber)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.Vote && tr.SenderHash == userHash && tr.VotingNumber == votingNumber);
            var elem = query.FirstOrDefaultAsync();
            elem.Wait();

            return elem.Result;
        }





        public List<Transaction> GetVotings()
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.StartVoting && tr.VotingNumber != 0);
            var elem = query.ToListAsync();
            elem.Wait();

            return elem.Result;
        }


        public Dictionary<Transaction, int> GetCandidatesResults(Transaction voting)
        {
            var candidates = GetCandidates(voting);

            if (candidates == null) return null;

            var dict = new Dictionary<Transaction, int>();

            foreach (var item in candidates)
            {
                var query = dbAsync.Table<Transaction>().Where(tr => tr.PreviousHash == voting.Hash 
                && tr.RecieverHash == item.RecieverHash && tr.Type == TransactionType.Vote);
                var votes = query.CountAsync();
                votes.Wait();

                dict.Add(item, votes.Result);
            }


            dict.OrderByDescending(tr => tr.Value);

            return dict;

        }


        public List<Transaction> GetCandidates(Transaction voting)
        {

            List<Transaction> list = new List<Transaction>();

            var info = JObject.Parse(voting.Info)["candidates"];

            foreach (string hash in info)
            {
                var user = GetUserCreation(hash);
                if (user != null)
                    list.Add(user);
                else
                    return null;
            }

            return list;
        }


        public Dictionary<Transaction, Transaction> GetUserVotesAndVotings(string userHash)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.StartVoting && tr.VotingNumber != 0);
            var elem = query.ToListAsync();
            elem.Wait();

            var result = new Dictionary<Transaction, Transaction>();

            foreach (var item in elem.Result)
            {
                //находим голос пользователя для этого голосования
                var elem2 = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.Vote &&
                    tr.PreviousHash == item.Hash && tr.SenderHash == userHash).FirstOrDefaultAsync();
                elem2.Wait();

                //если голос есть, добавляем голосование в список
                if (elem2.Result != null)
                {

                    result.Add(item, elem2.Result);
                }
            }

            return result;
        }


        public List<Transaction> GetUserOpenedVotings()
        {

            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.StartVoting && tr.VotingNumber != 0);
            var elem = query.ToListAsync();
            elem.Wait();

            var result = new List<Transaction>();

            foreach (var item in elem.Result)
            {
                //находим голос пользователя для этого голосования
                var elem2 = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.Vote && 
                    tr.PreviousHash == item.Hash && tr.SenderHash == VotingsUser.PublicKey).FirstOrDefaultAsync();
                elem2.Wait();

                //если голоса нет, добавляем голосование в список
                if (elem2.Result == null)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<Transaction> GetUserVotes(string userHash)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Type == TransactionType.Vote && tr.SenderHash == userHash);
            var elem = query.ToListAsync();
            elem.Wait();

            return elem.Result;
        }



        public void PutTransaction(Transaction item)
        {
            dbAsync.InsertAsync(item);
        }

        public void DeleteTransaction(Transaction item)
        {
            dbAsync.DeleteAsync(item);
        }


        public void DeleteBlock(Block item)
        {
            dbAsync.DeleteAsync(item);
        }

        public void PutBlock(Block item)
        {
            dbAsync.InsertAsync(item);
        }


        public void MarkTransaction(Transaction item, TransactionStatus status)
        {
            item.Status = status;
            dbAsync.UpdateAsync(item);
        }


        public List<Transaction> GetFreeTransactions(int count)
        {
            var query = dbAsync.Table<Transaction>().Where(tr => tr.Status == TransactionStatus.Free);
            query = query.OrderBy(tr => tr.Date).Take(count);
            var elems = query.ToListAsync();
            elems.Wait();

            return elems.Result;

        }


        public void Clear()
        {
            dbAsync.DropTableAsync<Transaction>().Wait();
            dbAsync.DropTableAsync<Block>().Wait();
            ConnectToDBAsync();
        }
    }
}

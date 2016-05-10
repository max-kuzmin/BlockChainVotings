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
            throw new NotImplementedException();
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

            if (transactions.Count>0)
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

            if (blocks.Count > 0)
            {
                var messageToSend = new BlocksMessage(blocks);
                net.SendMessageToPeer(messageToSend, e.SenderAddress);
            }
        }

        private void OnBlockMessage(object sender, MessageEventArgs e)
        {
            throw new NotImplementedException();
        }


        public void CreateVote(string recieverHash, int votingNumber)
        {

        }

        void MakeBlock()
        {

        }

        bool CheckBlock(Block block)
        {

        }

        bool CheckTransaction(Transaction transaction)
        {

        }

        void CheckDBRoot()
        {

        }

        void ReadMyInfo(string hash)
        {

        }

        DateTime GetInternetTime()
        {

        }


    }
}

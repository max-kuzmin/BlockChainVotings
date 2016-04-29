using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsTracker
{
    public class Message
    {
        public MessageType Type {
            get { return type; }
        }

        protected MessageType type;
    }


    public class PeerHashMessage: Message
    {
        public string PeerHash { get; }

        public PeerHashMessage(string peerHash)
        {
            this.type = MessageType.PeerHash;
            this.PeerHash = peerHash;
        }
    }

    public class PeerDisconnectMessage : Message
    {
        public string PeerHash { get; }

        public PeerDisconnectMessage(string peerHash)
        {
            this.type = MessageType.PeerDisconnect;
            this.PeerHash = peerHash;
        }
    }

    public class PeersMessage : Message
    {
        public List<string> PeersAdresses { get; }

        public PeersMessage(List<string> peersAdresses)
        {
            this.type = MessageType.Peers;
            this.PeersAdresses = peersAdresses;
        }
    }

    public class RequestPeersMessage : Message
    {
        public int Count { get; }

        public RequestPeersMessage(int count)
        {
            this.type = MessageType.RequestPeers;
            this.Count = count;
        }
    }


    public class RequestBlocksMessage : Message
    {
        public List<string> Hashes { get; }

        public RequestBlocksMessage(List<string> hashes)
        {
            this.type = MessageType.RequestBlocks;
            this.Hashes = hashes;
        }
    }

    public class RequestTransactionsMessage : Message
    {
        public List<string> Hashes { get; }

        public RequestTransactionsMessage(List<string> hashes)
        {
            this.type = MessageType.RequestTransactions;
            this.Hashes = hashes;
        }
    }


    public class ToPeerMessage : Message
    {
        public string SenderHash { get; }
        public string RecieverHash { get; }
        public Message Message { get; }

        public ToPeerMessage(string senderHash, string recieverHash, Message message)
        {
            this.type = MessageType.MessageToPeer;
            this.SenderHash = senderHash;
            this.RecieverHash = recieverHash;
            this.Message = message;
        }
    }


    public class TransactionsMessage : Message
    {
        public TransactionsMessage()
        {
            this.type = MessageType.Transactions;
        }
    }

    public class BlocksMessage : Message
    {
        public BlocksMessage()
        {
            this.type = MessageType.Transactions;
        }
    }


    public class ConnectToPeerWithTrackerMessage : Message
    {
        public string SenderHash { get; }
        public string RecieverHash { get; }

        public ConnectToPeerWithTrackerMessage(string senderHash, string recieverHash)
        {
            this.type = MessageType.ConnectToPeerWithTracker;
            this.SenderHash = senderHash;
            this.RecieverHash = recieverHash;
        }
    }





}

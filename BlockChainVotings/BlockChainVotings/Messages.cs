using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    [ProtoContract]
    [ProtoInclude(100, typeof(PeerHashMessage))]
    public class Message
    {
        [ProtoMember(1)]
        public MessageType Type;

        public Message() { }
    }


    [ProtoContract]
    public class PeerHashMessage : Message
    {
        [ProtoMember(2)]
        public string PeerHash;
        [ProtoMember(3)]
        public bool NeedResponse;

        public PeerHashMessage(string peerHash, bool needResponse)
        {
            this.Type = MessageType.PeerHash;
            this.PeerHash = peerHash;
            this.NeedResponse = needResponse;

        }

        public PeerHashMessage() { }
    }

    public class PeerDisconnectMessage : Message
    {
        public EndPoint PeerAddress { get; }

        public PeerDisconnectMessage(EndPoint peerAddress)
        {
            this.Type = MessageType.PeerDisconnect;
            this.PeerAddress = peerAddress;
        }
    }

    public class PeersMessage : Message
    {
        public List<EndPoint> PeersAdresses { get; }

        public PeersMessage(List<EndPoint> peersAdresses)
        {
            this.Type = MessageType.Peers;
            this.PeersAdresses = peersAdresses;
        }
    }

    public class RequestPeersMessage : Message
    {
        public int Count { get; }

        public RequestPeersMessage(int count)
        {
            this.Type = MessageType.RequestPeers;
            this.Count = count;
        }
    }


    public class RequestBlocksMessage : Message
    {
        public List<string> Hashes { get; }

        public RequestBlocksMessage(List<string> hashes)
        {
            this.Type = MessageType.RequestBlocks;
            this.Hashes = hashes;
        }
    }

    public class RequestTransactionsMessage : Message
    {
        public List<string> Hashes { get; }

        public RequestTransactionsMessage(List<string> hashes)
        {
            this.Type = MessageType.RequestTransactions;
            this.Hashes = hashes;
        }
    }


    public class ToPeerMessage : Message
    {
        public EndPoint SenderAddress { get; }
        public EndPoint RecieverAddress { get; }
        public Message Message { get; }

        public ToPeerMessage(EndPoint senderAddress, EndPoint recieverAddress, Message message)
        {
            this.Type = MessageType.MessageToPeer;
            this.SenderAddress = senderAddress;
            this.RecieverAddress = recieverAddress;
            this.Message = message;
        }
    }


    public class TransactionsMessage : Message
    {
        public List<Transaction> Transactions { get; set; }
        public TransactionsMessage(List<Transaction> transactions)
        {
            this.Type = MessageType.Transactions;
            this.Transactions = transactions;
        }
    }

    public class BlocksMessage : Message
    {
        public List<Block> Blocks { get; set; }
        public BlocksMessage(List<Block> blocks)
        {
            this.Type = MessageType.Transactions;
            this.Blocks = blocks;
        }
    }


    public class ConnectToPeerWithTrackerMessage : Message
    {
        public EndPoint SenderAddress { get; }
        public EndPoint RecieverAddress { get; }

        public ConnectToPeerWithTrackerMessage(EndPoint senderAddress, EndPoint recieverAddress)
        {
            this.Type = MessageType.ConnectToPeerWithTracker;
            this.SenderAddress = senderAddress;
            this.RecieverAddress = recieverAddress;
        }
    }





}

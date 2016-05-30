using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsAndroid
{
    [ProtoContract]
    [ProtoInclude(100, typeof(PeerHashMessage))]
    [ProtoInclude(101, typeof(PeerDisconnectMessage))]
    [ProtoInclude(102, typeof(PeersMessage))]
    [ProtoInclude(103, typeof(RequestPeersMessage))]
    [ProtoInclude(104, typeof(RequestBlocksMessage))]
    [ProtoInclude(105, typeof(RequestTransactionsMessage))]
    [ProtoInclude(106, typeof(ToPeerMessage))]
    [ProtoInclude(107, typeof(ConnectToPeerWithTrackerMessage))]
    [ProtoInclude(108, typeof(BlocksMessage))]
    [ProtoInclude(109, typeof(TransactionsMessage))]
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

        //
        public PeerHashMessage() { }
    }

    [ProtoContract]
    public class PeerDisconnectMessage : Message
    {
        
        public EndPoint PeerAddress;

        public PeerDisconnectMessage(EndPoint peerAddress)
        {
            this.Type = MessageType.PeerDisconnect;
            this.PeerAddress = peerAddress;

        }

        //
        public PeerDisconnectMessage() { }

        [ProtoMember(2)]
        int peerPort;
        [ProtoMember(3)]
        long peerAddress;

        [ProtoBeforeSerialization]
        private void Serialize()
        {
            peerAddress = (PeerAddress as IPEndPoint).Address.Address;
            peerPort = (PeerAddress as IPEndPoint).Port ;
        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            PeerAddress = new IPEndPoint(peerAddress, peerPort);
        }

    }

    [ProtoContract]
    public class PeersMessage : Message
    {
        public List<EndPoint> PeersAdresses = new List<EndPoint>();

        public PeersMessage(List<EndPoint> peersAdresses)
        {
            this.Type = MessageType.Peers;
            this.PeersAdresses = peersAdresses;
        }


        //
        public PeersMessage() { }

        [ProtoMember(2)]
        List<int> peersPorts = new List<int>();
        [ProtoMember(3)]
        List<long> peersAddresses = new List<long>();

        [ProtoBeforeSerialization]
        private void Serialize()
        {
            for (int i = 0; i < PeersAdresses.Count; i++)
            {
                peersAddresses.Add((PeersAdresses[i] as IPEndPoint).Address.Address);
                peersPorts.Add((PeersAdresses[i] as IPEndPoint).Port);
            }

        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            for (int i = 0; i < peersPorts.Count; i++)
            {
                PeersAdresses.Add(new IPEndPoint(peersAddresses[i], peersPorts[i]));
            }
        }
    }

    [ProtoContract]
    public class RequestPeersMessage : Message
    {
        [ProtoMember(2)]
        public int Count;

        public RequestPeersMessage(int count)
        {
            this.Type = MessageType.RequestPeers;
            this.Count = count;
        }

        //
        public RequestPeersMessage() { }
    }

    [ProtoContract]
    public class RequestBlocksMessage : Message
    {
        [ProtoMember(2)]
        public List<string> Hashes = new List<string>();

        public RequestBlocksMessage(List<string> hashes)
        {
            this.Type = MessageType.RequestBlocks;
            this.Hashes = hashes;
        }

        //
        public RequestBlocksMessage() { }
    }

    [ProtoContract]
    public class RequestTransactionsMessage : Message
    {
        [ProtoMember(2)]
        public List<string> Hashes = new List<string>();

        public DateTime Date0
        {
            get { return new DateTime(Date); }
            set { Date = value.Ticks; }
        }

        [ProtoMember(3)]
        public long Date=0;

        public RequestTransactionsMessage(List<string> hashes)
        {
            this.Type = MessageType.RequestTransactions;
            this.Hashes = hashes;
        }

        public RequestTransactionsMessage(DateTime date)
        {
            this.Type = MessageType.RequestTransactions;
            this.Date = date.Ticks;
        }

        //
        public RequestTransactionsMessage() { }
    }

    [ProtoContract]
    public class ToPeerMessage : Message
    {
        public EndPoint SenderAddress;
        public EndPoint RecieverAddress;
        [ProtoMember(16, AsReference = true)]
        public Message Message;

        public ToPeerMessage(EndPoint senderAddress, EndPoint recieverAddress, Message message)
        {
            this.Type = MessageType.MessageToPeer;
            this.SenderAddress = senderAddress;
            this.RecieverAddress = recieverAddress;
            this.Message = message;
        }


        //
        public ToPeerMessage() { }

        [ProtoMember(12)]
        long senderAddress;
        [ProtoMember(13)]
        int senderPort;

        [ProtoMember(14)]
        long recieverAddress;
        [ProtoMember(15)]
        int recieverPort;

        [ProtoBeforeSerialization]
        private void Serialize()
        {
            senderAddress = (SenderAddress as IPEndPoint).Address.Address;
            senderPort = (SenderAddress as IPEndPoint).Port;

            recieverAddress = (RecieverAddress as IPEndPoint).Address.Address;
            recieverPort = (RecieverAddress as IPEndPoint).Port;
        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            SenderAddress = new IPEndPoint(senderAddress, senderPort);
            RecieverAddress = new IPEndPoint(recieverAddress, recieverPort);
        }
    }

    [ProtoContract]
    public class TransactionsMessage : Message
    {
        [ProtoMember(2)]
        public List<Transaction> Transactions;

        public TransactionsMessage(List<Transaction> transactions)
        {
            this.Type = MessageType.Transactions;
            this.Transactions = transactions;
        }

        public TransactionsMessage() { }
    }

    [ProtoContract]
    public class BlocksMessage : Message
    {
        [ProtoMember(2)]
        public List<Block> Blocks { get; set; }

        public BlocksMessage(List<Block> blocks)
        {
            this.Type = MessageType.Transactions;
            this.Blocks = blocks;
        }

        public BlocksMessage() { }
    }

    [ProtoContract]
    public class ConnectToPeerWithTrackerMessage : Message
    {
        public EndPoint SenderAddress;
        public EndPoint RecieverAddress;

        public ConnectToPeerWithTrackerMessage(EndPoint senderAddress, EndPoint recieverAddress)
        {
            this.Type = MessageType.ConnectToPeerWithTracker;
            this.SenderAddress = senderAddress;
            this.RecieverAddress = recieverAddress;
        }

        //
        public ConnectToPeerWithTrackerMessage() { }

        [ProtoMember(2)]
        long senderAddress;
        [ProtoMember(3)]
        int senderPort;

        [ProtoMember(4)]
        long recieverAddress;
        [ProtoMember(5)]
        int recieverPort;

        [ProtoBeforeSerialization]
        private void Serialize()
        {
            senderAddress = (SenderAddress as IPEndPoint).Address.Address;
            senderPort = (SenderAddress as IPEndPoint).Port;

            recieverAddress = (RecieverAddress as IPEndPoint).Address.Address;
            recieverPort = (RecieverAddress as IPEndPoint).Port;
        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            SenderAddress = new IPEndPoint(senderAddress, senderPort);
            RecieverAddress = new IPEndPoint(recieverAddress, recieverPort);
        }
    }





}

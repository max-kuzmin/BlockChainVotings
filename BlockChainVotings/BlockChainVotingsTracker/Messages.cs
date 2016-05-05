using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsTracker
{
    [ProtoContract]
    [ProtoInclude(100, typeof(PeerHashMessage))]
    [ProtoInclude(101, typeof(PeerDisconnectMessage))]
    [ProtoInclude(102, typeof(PeersMessage))]
    [ProtoInclude(103, typeof(RequestPeersMessage))]
    [ProtoInclude(106, typeof(ToPeerMessage))]
    [ProtoInclude(107, typeof(ConnectToPeerWithTrackerMessage))]
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
            peerPort = (PeerAddress as IPEndPoint).Port;
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
        public List<EndPoint> PeersAdresses;

        public PeersMessage(List<EndPoint> peersAdresses)
        {
            this.Type = MessageType.Peers;
            this.PeersAdresses = peersAdresses;
        }


        //
        public PeersMessage() { }

        [ProtoMember(2)]
        int[] peersPorts;
        [ProtoMember(3)]
        long[] peersAddresses;

        [ProtoBeforeSerialization]
        private void Serialize()
        {
            peersPorts = new int[PeersAdresses.Count];
            peersAddresses = new long[PeersAdresses.Count];

            for (int i = 0; i < PeersAdresses.Count; i++)
            {
                peersAddresses[i] = (PeersAdresses[i] as IPEndPoint).Address.Address;
                peersPorts[i] = (PeersAdresses[i] as IPEndPoint).Port;
            }

        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            PeersAdresses = new List<EndPoint>();
            for (int i = 0; i < peersPorts.Length; i++)
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


    //public class RequestBlocksMessage : Message
    //{
    //    public List<string> Hashes { get; }

    //    public RequestBlocksMessage(List<string> hashes)
    //    {
    //        this.type = MessageType.RequestBlocks;
    //        this.Hashes = hashes;
    //    }
    //}

    //public class RequestTransactionsMessage : Message
    //{
    //    public List<string> Hashes { get; }

    //    public RequestTransactionsMessage(List<string> hashes)
    //    {
    //        this.type = MessageType.RequestTransactions;
    //        this.Hashes = hashes;
    //    }
    //}


    [ProtoContract]
    public class ToPeerMessage : Message
    {
        public EndPoint SenderAddress;
        public EndPoint RecieverAddress;
        [ProtoMember(6)]
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


    //public class TransactionsMessage : Message
    //{
    //    public TransactionsMessage()
    //    {
    //        this.type = MessageType.Transactions;
    //    }
    //}

    //public class BlocksMessage : Message
    //{
    //    public BlocksMessage()
    //    {
    //        this.type = MessageType.Transactions;
    //    }
    //}


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

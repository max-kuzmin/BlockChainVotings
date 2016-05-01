using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;
using System.Net;
using NetworkCommsDotNet.Connections.TCP;

namespace BlockChainVotings
{
    public class Peer
    {
        Tracker tracker;

        //события прихода сообщений для обработки вне пира
        public event EventHandler<MessageEventArgs> OnRequestBlocksMessage;
        public event EventHandler<MessageEventArgs> OnRequestTransactionsMessage;
        public event EventHandler<MessageEventArgs> OnBlocksMessage;
        public event EventHandler<MessageEventArgs> OnTransactionsMessage;


        public EndPoint Address { get; }
        public Connection Connection { get; set; }
        public string Hash { get; set; }
        public int SendToOthersCount { get; set; }
        public PeerStatus Status { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public int ErrorsCount { get; set; }

        List<Peer> allPeers;
        static PeerComparer peerComparer = new PeerComparer();


        public Peer(EndPoint address, List<Peer> allPeers, Tracker tracker = null)
        {
            this.Address = address;
            this.allPeers = allPeers;
            this.tracker = tracker;
            this.Status = PeerStatus.Disconnected;

            Connect();
        }

        public void Connect()
        {
            if (Connection != null) return;

            //пытаемся подключиться напрямую
            try {
                ConnectionInfo connInfo = new ConnectionInfo(Address);
                Connection newTCPConn = TCPConnection.GetConnection(connInfo);
                newTCPConn.EstablishConnection();
                ConnectionType = ConnectionType.Direct;
                Status = PeerStatus.NoHashRecieved;
                Connection = newTCPConn;

                //обработчики приходящих сообщений внутри пира
                Connection.AppendShutdownHandler((c) => DisconnectDirect());

                Connection.AppendIncomingPacketHandler<PeerHashMessage>(MessageType.PeerHash.ToString(), 
                    (p, c, m)  => OnPeerHashMessageDirect(m));

                Connection.AppendIncomingPacketHandler<RequestPeersMessage>(MessageType.PeerHash.ToString(), 
                    (p, c, m) => OnRequestPeersMessageDirect(m));

                //вызов внешних событий
                Connection.AppendIncomingPacketHandler<RequestBlocksMessage>(MessageType.RequestBlocks.ToString(), 
                    (p, c, m) => OnRequestBlocksMessage(this, new MessageEventArgs(m, Hash)));

                Connection.AppendIncomingPacketHandler<RequestTransactionsMessage>(MessageType.RequestTransactions.ToString(),
                    (p, c, m) => OnRequestTransactionsMessage(this, new MessageEventArgs(m, Hash)));

                Connection.AppendIncomingPacketHandler<BlocksMessage>(MessageType.Blocks.ToString(),
                    (p, c, m) => OnBlocksMessage(this, new MessageEventArgs(m, Hash)));

                Connection.AppendIncomingPacketHandler<TransactionsMessage>(MessageType.Transactions.ToString(),
                    (p, c, m) => OnTransactionsMessage(this, new MessageEventArgs(m, Hash)));


                RequestPeerHash();
            }
            catch (CommsException ex)
            {
                //если трекер не задан, то ошибка
                if (tracker == null)
                {
                    ErrorsCount++;
                    Status = PeerStatus.Disconnected;
                }
                //пытаемся подключиься через трекер
                else
                {
                    try
                    {
                        tracker.ConnectPeerToPeer(this);

                        ConnectionType = ConnectionType.WithTracker;
                        Status = PeerStatus.NoHashRecieved;

                        //подписка на сообщения с трекера
                        tracker.OnDisconnectPeer += OnDisconnectPeerWithTracker;
                        tracker.OnPeerHashMessage += OnPeerHashMessageWithTracker;
                        tracker.OnRequestPeersMessage += OnRequestPeersMessageWithTracker;

                        RequestPeerHash();

                    }
                    //если не удалось через трекер, то ошибка
                    catch (CommsException ex2)
                    {
                        ErrorsCount++;
                        Status = PeerStatus.Disconnected;
                    }
                }
            }


            //если более трех ошибок подключения, то удаляем пир из списка
            if (ErrorsCount>=3 && Status == PeerStatus.Disconnected)
            {
                allPeers.Remove(this);
            }
        }

        private void OnRequestPeersMessageWithTracker(object sender, MessageEventArgs e)
        {
            if (e.SenderHash == Hash)
            {
                var message = e.Message as RequestPeersMessage;

                var peers = allPeers.ToList();
                peers.Sort(peerComparer);

                var peersToSend = peers.Where(peer => peer.Status == PeerStatus.Connected);
                peersToSend = peersToSend.Take(message.Count);
                var peersAddresses = peersToSend.Select(peer => peer.Address);
                var messageToSend = new PeersMessage(peersAddresses.ToList());

                tracker.SendMessageToPeer(message, this);

                foreach (var peer in peersToSend)
                {
                    peer.SendToOthersCount++;
                }
            }
        }

        private void OnPeerHashMessageWithTracker(object sender, MessageEventArgs e)
        {
            var message = e.Message as PeerHashMessage;

            if (e.SenderHash == Hash && message.PeerHash != string.Empty)
            {
                Hash = message.PeerHash;
                Status = PeerStatus.Connected;

                if (message.NeedResponse == true)
                {
                    var messageToSend = new PeerHashMessage(Hash, false);
                    tracker.SendMessageToPeer(message, this);
                }
            }
        }

        private void OnDisconnectPeerWithTracker(object sender, MessageEventArgs e)
        {
            var message = e.Message as PeerDisconnectMessage;

            if (message.PeerHash == Hash)
            {
                Status = PeerStatus.Disconnected;
                allPeers.Remove(this);
            }
        }

        private void OnRequestPeersMessageDirect(RequestPeersMessage m)
        {
            var peers = allPeers.ToList();
            peers.Sort(peerComparer);

            var peersToSend = peers.Where(peer => peer.Status == PeerStatus.Connected);
            peersToSend = peersToSend.Take(m.Count);

            var peersAddresses = peersToSend.Select(peer => peer.Address);
            var message = new PeersMessage(peersAddresses.ToList());
            Connection.SendObject(message.Type.ToString(), message);


            foreach (var peer in peersToSend)
            {
                peer.SendToOthersCount++;
            }
        }


        public void SendMessage(Message message)
        {
            if (Status == PeerStatus.Connected)
            {
                if (ConnectionType == ConnectionType.Direct)
                {
                    Connection.SendObject(message.Type.ToString(), message);
                }
                else
                {
                    tracker.SendMessageToPeer(message, this);
                }
            }
            else
            {
                Connect();
            }
        }

        public void RequestPeers(int count)
        {
            if (Status == PeerStatus.Connected)
            {
                var message = new RequestPeersMessage(count);
                if (ConnectionType == ConnectionType.Direct)
                {
                    Connection.SendObject(message.Type.ToString(), message);
                }
                else
                {
                    tracker.SendMessageToPeer(message, this);
                }
            }
            else
            {
                Connect();
            }
        }

        public void DisconnectDirect()
        {
            if (ConnectionType == ConnectionType.Direct && Connection != null)
            {
                var message = new PeerDisconnectMessage(Hash);
                Connection.SendObject(message.Type.ToString(), message);

                Status = PeerStatus.Disconnected;
                Connection.Dispose();
                Connection = null;
                allPeers.Remove(this);
            }
        }

        private void OnPeerHashMessageDirect(PeerHashMessage message)
        {
            if (message.PeerHash != string.Empty)
            {
                Hash = message.PeerHash;
                Status = PeerStatus.Connected;

                if (message.NeedResponse == true)
                    {
                    var messageToSend = new PeerHashMessage(Hash, false);
                    Connection.SendObject(message.Type.ToString(), messageToSend);
                }
            }
        }

        private void RequestPeerHash()
        {

            if (Status == PeerStatus.Connected)
            {
                var message = new PeerHashMessage(Hash, true);
                if (ConnectionType == ConnectionType.Direct)
                {
                    Connection.SendObject(message.Type.ToString(), message);
                }
                else
                {
                    tracker.SendMessageToPeer(message, this);
                }
            }
            else
            {
                Connect();
            }
        }

    }
}

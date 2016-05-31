using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;
using System.Net;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;
using System.Reflection;
using System.Threading;

namespace BlockChainVotingsAndroid
{
    public class Peer
    {
        Tracker tracker;

        //события прихода сообщений для обработки вне пира
        public event EventHandler<MessageEventArgs> OnRequestBlocksMessage;
        public event EventHandler<MessageEventArgs> OnRequestTransactionsMessage;
        public event EventHandler<MessageEventArgs> OnBlocksMessage;
        public event EventHandler<MessageEventArgs> OnTransactionsMessage;
        public event EventHandler<MessageEventArgs> OnPeersMessage;


        public EndPoint Address { get; private set; }
        public Connection Connection { get; private set; }
        public string Hash { get; private set; }
        public int SendToOthersCount { get; private set; }
        public PeerStatus Status { get; private set; }
        public ConnectionMode ConnectionMode { get; private set; }
        public int ErrorsCount { get; private set; }
        public int PeersRequestsCount { get; private set; }

        List<Peer> allPeers;
        static PeerComparer peerComparer = new PeerComparer();


        public Peer(EndPoint address, List<Peer> allPeers, Tracker tracker = null)
        {
            this.Address = address;
            this.allPeers = allPeers;
            this.tracker = tracker;
            this.Status = PeerStatus.Disconnected;

        }



        public void Connect(bool withTracker = false)
        {
            //111withTracker = true;
            if (Status == PeerStatus.NoHashRecieved)
            {
                RequestPeerHash();
                return;
            }
            else if (Status == PeerStatus.Connected)
            {
                return;
            }
            //попытка подключения сразу через трекер (используется если поступил запрос от трекера)
            else if (withTracker)
                ConnectWithTracker();
            else
            {
                //пытаемся подключиться напрямую
                try
                {
                    ConnectionInfo connInfo = new ConnectionInfo(Address);
                    TCPConnection newTCPConn = TCPConnection.GetConnection(connInfo);


                    ConnectionMode = ConnectionMode.Direct;
                    Status = PeerStatus.NoHashRecieved;
                    Connection = newTCPConn;

                    //обработчики приходящих сообщений внутри пира
                    //Connection.AppendShutdownHandler((c) => DisconnectDirect(false));
                    if (!Connection.IncomingPacketHandlerExists(typeof(PeerDisconnectMessage).Name))
                        Connection.AppendIncomingPacketHandler<PeerDisconnectMessage>(typeof(PeerDisconnectMessage).Name,
                            (p, c, m) => DisconnectDirect(false));

                    if (!Connection.IncomingPacketHandlerExists(typeof(PeerHashMessage).Name))
                        Connection.AppendIncomingPacketHandler<PeerHashMessage>(typeof(PeerHashMessage).Name,
                            (p, c, m) => OnPeerHashMessageDirect(m));

                    if (!Connection.IncomingPacketHandlerExists(typeof(RequestPeersMessage).Name))
                        Connection.AppendIncomingPacketHandler<RequestPeersMessage>(typeof(RequestPeersMessage).Name,
                            (p, c, m) => OnRequestPeersMessageDirect(m));


                    //вызов внешних событий
                    if (!Connection.IncomingPacketHandlerExists(typeof(RequestBlocksMessage).Name))
                        Connection.AppendIncomingPacketHandler<RequestBlocksMessage>(typeof(RequestBlocksMessage).Name,
                            (p, c, m) => {
                                OnRequestBlocksMessage?.Invoke(this, new MessageEventArgs(m, Hash, Address));
                            });

                    if (!Connection.IncomingPacketHandlerExists(typeof(RequestTransactionsMessage).Name))
                        Connection.AppendIncomingPacketHandler<RequestTransactionsMessage>(typeof(RequestTransactionsMessage).Name,
                            (p, c, m) => {
                                OnRequestTransactionsMessage?.Invoke(this, new MessageEventArgs(m, Hash, Address));
                            });

                    if (!Connection.IncomingPacketHandlerExists(typeof(BlocksMessage).Name))
                        Connection.AppendIncomingPacketHandler<BlocksMessage>(typeof(BlocksMessage).Name,
                            (p, c, m) => {
                                OnBlocksMessage?.Invoke(this, new MessageEventArgs(m, Hash, Address));
                            });

                    if (!Connection.IncomingPacketHandlerExists(typeof(TransactionsMessage).Name))
                        Connection.AppendIncomingPacketHandler<TransactionsMessage>(typeof(TransactionsMessage).Name,
                            (p, c, m) => {
                                OnTransactionsMessage?.Invoke(this, new MessageEventArgs(m, Hash, Address));
                            });

                    if (!Connection.IncomingPacketHandlerExists(typeof(PeersMessage).Name))
                        Connection.AppendIncomingPacketHandler<PeersMessage>(typeof(PeersMessage).Name,
                            (p, c, m) => {
                                OnPeersMessage?.Invoke(this, new MessageEventArgs(m, Hash, Address));
                            });

                    Thread.Sleep(CommonHelpers.MessagesInterval);

                    RequestPeerHash();
                }
                catch 
                {
                    Connection = null;

                    //если трекер не задан, то ошибка
                    if (tracker == null)
                    {
                        ErrorsCount++;
                        Status = PeerStatus.Disconnected;
                    }
                    //пытаемся подключиться через трекер
                    else
                    {
                        ConnectWithTracker();
                    }
                }
            }


            //если более трех ошибок подключения, то удаляем пир из списка
            if (ErrorsCount>=3 && Status == PeerStatus.Disconnected)
            {
                DisconnectDirect();
            }
        }


        private void ConnectWithTracker()
        {

                //при удалении трекера из списка отключаем пир
                tracker.OnTrackerDelete += RemoveTracker;

                //подписка на сообщения с трекера
                tracker.OnDisconnectPeer += OnDisconnectPeerWithTracker;
                tracker.OnPeerHashMessage += OnPeerHashMessageWithTracker;
                tracker.OnRequestPeersMessage += OnRequestPeersMessageWithTracker;


                ConnectionMode = ConnectionMode.WithTracker;
                Status = PeerStatus.NoHashRecieved;

                tracker.ConnectPeerToPeer(this);


                RequestPeerHash();

        }

        private void RemoveTracker(object sender, EventArgs e)
        {
            tracker = null;

            if (/*Status == PeerStatus.Connected &&*/ ConnectionMode == ConnectionMode.WithTracker)
            {
                Status = PeerStatus.Disconnected;
                ConnectionMode = ConnectionMode.Direct;
                Connect();
            }
        }

        private void OnRequestPeersMessageWithTracker(object sender, MessageEventArgs e)
        {
            if (e.SenderAddress.Equals(Address))
            {
                var message = e.Message as RequestPeersMessage;

                var peers = allPeers.ToList();
                peers.Sort(peerComparer);

                var peersToSend = peers.Where(peer => peer.Status == PeerStatus.Connected && peer.Hash != Hash);
                peersToSend = peersToSend.Take(message.Count);
                var peersAddresses = peersToSend.Select(peer => peer.Address);
                var messageToSend = new PeersMessage(peersAddresses.ToList());

                tracker.SendMessageToPeer(messageToSend, this);

                foreach (var peer in peersToSend)
                {
                    peer.SendToOthersCount++;
                }
            }
        }


        public void CheckConnection()
        {
            if (Status == PeerStatus.Connected && ConnectionMode == ConnectionMode.Direct)
            {
                bool alive = false;

                try
                {
                    alive = Connection.ConnectionAlive();
                }
                catch { }

                if (!alive)
                {
                    Status = PeerStatus.Disconnected;
                    ErrorsCount++;

                    //если более трех ошибок подключения, то удаляем пир из списка
                    if (ErrorsCount >= 3)
                    {
                        allPeers.Remove(this);
                    }
                }
            }
            else
            {
                Connect();
            }
        }

        private void OnPeerHashMessageWithTracker(object sender, MessageEventArgs e)
        {
            var message = e.Message as PeerHashMessage;

            if (e.SenderAddress.Equals(Address) && message.PeerHash != string.Empty)
            {
                Hash = message.PeerHash;
                Status = PeerStatus.Connected;

                CommonHelpers.LogPeers(allPeers);

                if (message.NeedResponse == true)
                {
                    var messageToSend = new PeerHashMessage(Hash, false);
                    tracker.SendMessageToPeer(messageToSend, this);
                }
            }
        }

        private void OnDisconnectPeerWithTracker(object sender, MessageEventArgs e)
        {
            var message = e.Message as PeerDisconnectMessage;

            if (message.PeerAddress.Equals(Address))
            {
                Status = PeerStatus.Disconnected;
                allPeers.Remove(this);

                CommonHelpers.LogPeers(allPeers);
            }
        }



        private void OnRequestPeersMessageDirect(RequestPeersMessage m)
        {
            var peers = allPeers.ToList();
            peers.Sort(peerComparer);

            var peersToSend = peers.Where(peer => peer.Status == PeerStatus.Connected && peer.Hash != Hash);
            peersToSend = peersToSend.Take(m.Count);

            var peersAddresses = peersToSend.Select(peer => peer.Address);
            var message = new PeersMessage(peersAddresses.ToList());
            Connection.SendObject(typeof(PeersMessage).Name, message);


            foreach (var peer in peersToSend)
            {
                peer.SendToOthersCount++;
            }
        }


        public void SendMessage(Message message)
        {
            if (Status == PeerStatus.Connected)
            {
                if (ConnectionMode == ConnectionMode.Direct)
                {
                    //проверка на дисконнект
                    try
                    {
                        Connection.SendObject(message.GetType().Name, message);
                    }
                    catch
                    {
                        Status = PeerStatus.Disconnected;
                        Connect();
                    }
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
                if (ConnectionMode == ConnectionMode.Direct)
                {
                    //проверка на дисконнект
                    try
                    {
                        Connection.SendObject(message.GetType().Name, message);
                    }
                    catch
                    {
                        Status = PeerStatus.Disconnected;
                        Connect();
                    }
                }
                else
                {
                    tracker.SendMessageToPeer(message, this);
                }
                PeersRequestsCount++;
            }
            else
            {
                Connect();
            }
        }

        public void DisconnectDirect(bool sendMessage = true)
        {
            allPeers.Remove(this);

            CommonHelpers.LogPeers(allPeers);

            if (ConnectionMode == ConnectionMode.Direct)
            {

                try {
                    if (sendMessage)
                    {
                        var message = new PeerDisconnectMessage(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort));
                        Connection.SendObject(message.GetType().Name, message);
                    }

                    Connection.Dispose();
                    Connection = null;
                }
                catch { }
                
            }

            Status = PeerStatus.Disconnected;
        }

        private void OnPeerHashMessageDirect(PeerHashMessage message)
        {
            if (message.PeerHash != string.Empty && message.PeerHash != null)
            {
                Hash = message.PeerHash;
                Status = PeerStatus.Connected;

                CommonHelpers.LogPeers(allPeers);

                //возможно стоит отключить повторную отправку сообщения, чтобы они не дублировались
                if (message.NeedResponse == true)
                    {
                    var messageToSend = new PeerHashMessage(VotingsUser.PublicKey, false);
                    Connection.SendObject(messageToSend.GetType().Name, messageToSend); 
                }
            }
        }



        private void RequestPeerHash()
        {

            if (Status == PeerStatus.NoHashRecieved)
            {
                var message = new PeerHashMessage(VotingsUser.PublicKey, true);
                if (ConnectionMode == ConnectionMode.Direct)
                {
                    //проверка на дисконнект
                    try
                    {
                        Connection.SendObject(message.GetType().Name, message);
                    }
                    catch
                    {
                        Status = PeerStatus.Disconnected;
                        Connect();
                    }
                }
                else
                {
                    tracker.SendMessageToPeer(message, this);
                }
            }
            else if (Status == PeerStatus.Disconnected)
            {
                Connect();
            }
        }

    }
}

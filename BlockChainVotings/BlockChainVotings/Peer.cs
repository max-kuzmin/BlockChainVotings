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
    public class Peer: IDisposable
    {
        public Tracker Tracker { get; }

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
            this.Tracker = tracker;
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

                //обработчики приходящих сообщений !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Connection.AppendShutdownHandler((c) => DisconnectDirect());
                Connection.AppendIncomingPacketHandler<PeerHashMessage>(MessageType.PeerHash.ToString(), (p, c, m)  => OnPeerHashMessageDirect(m));

                RequestPeerHashDirect();
            }
            catch (CommsException ex)
            {
                //если трекер не задан, то ошибка
                if (Tracker == null)
                {
                    ErrorsCount++;
                    Status = PeerStatus.Disconnected;
                }
                //пытаемся подключиься через трекер
                else
                {
                    try
                    {
                        Tracker.ConnectPeerToPeer(this);

                        ConnectionType = ConnectionType.WithTracker;
                        Status = PeerStatus.NoHashRecieved;

                        //подписка на сообщения сервера
                        Tracker.OnMessageRecieved += OnMessageRecievedFromTracker;

                        RequestPeerHashWithTracker();

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

        private void RequestPeerHashWithTracker()
        {
            var message = new PeerHashMessage(Hash, true);
            Tracker.SendMessageToPeer(message, this);
        }

        private void OnMessageRecievedFromTracker(object sender, MessageRecievedEventArgs e)
        {
            ////////////////////обработка разных сообщений трекера
            throw new NotImplementedException();
        }


        public void DisconnectDirect()
        {
            if (ConnectionType == ConnectionType.Direct && Connection != null)
            {
                var message = new PeerDisconnectMessage(Hash);
                Connection.SendObject(MessageType.PeerDisconnect.ToString(), message);

                Status = PeerStatus.Disconnected;

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
                    var messageToSend = new PeerHashMessage(string.Empty, false);
                    Connection.SendObject(MessageType.PeerHash.ToString(), messageToSend);
                }
            }
        }

        private void RequestPeerHashDirect()
        {
            var message = new PeerHashMessage(Hash, true);
            Connection.SendObject(MessageType.PeerHash.ToString(), message);
        }

        public void Dispose()
        {
            if (Connection!=null) Connection.Dispose();
        }
    }
}

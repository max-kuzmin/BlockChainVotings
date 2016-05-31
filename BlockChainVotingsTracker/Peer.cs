using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;
using System.Threading;

namespace BlockChainVotingsTracker
{
    public class Peer
    {
        public EndPoint Address { get; private set; }
        public string Hash { get; set; }
        public int SendToOthersCount { get; set; }
        public List<Peer> ConnectedPeers { get; private set; }
        public PeerStatus Status { get; set; }

        public Connection Connection { get; private set; }

        public int ErrorsCount { get; set; }

        List<Peer> allPeers;
        static PeerComparer peerComparer = new PeerComparer();

        System.Timers.Timer t;

        public void SetupConnection(Connection con)
        {
            this.Connection = con;

            //обработчики приходящих сообщений для подключения
            //this.Connection.AppendShutdownHandler((c) => Disconnect());
            if (!Connection.IncomingPacketHandlerExists(typeof(PeerDisconnectMessage).Name))
                this.Connection.AppendIncomingPacketHandler<PeerDisconnectMessage>(typeof(PeerDisconnectMessage).Name,
                                    (p, c, m) => Disconnect());

            if (!Connection.IncomingPacketHandlerExists(typeof(PeerHashMessage).Name))
                this.Connection.AppendIncomingPacketHandler<PeerHashMessage>(typeof(PeerHashMessage).Name, OnPeerHashMessage);

            if (!Connection.IncomingPacketHandlerExists(typeof(RequestPeersMessage).Name))
                this.Connection.AppendIncomingPacketHandler<RequestPeersMessage>(typeof(RequestPeersMessage).Name, OnRequestPeersMessage);

            if (!Connection.IncomingPacketHandlerExists(typeof(ConnectToPeerWithTrackerMessage).Name))
                this.Connection.AppendIncomingPacketHandler<ConnectToPeerWithTrackerMessage>(typeof(ConnectToPeerWithTrackerMessage).Name, OnConnectToPeerWithTrackerMessage);

            if (!Connection.IncomingPacketHandlerExists(typeof(ToPeerMessage).Name))
                this.Connection.AppendIncomingPacketHandler<ToPeerMessage>(typeof(ToPeerMessage).Name, OnToPeerMessage);

            Thread.Sleep(CommonHelpers.MessagesInterval);


            RequestPeerForHash();
        }


        public Peer(Connection connection, List<Peer> allPeers, System.Timers.Timer t)
        {
            this.ConnectedPeers = new List<Peer>();
            //this.Connection = connection;
            this.Address = connection.ConnectionInfo.RemoteEndPoint;
            this.allPeers = allPeers;

            this.Status = PeerStatus.NoHashRecieved;

            this.t = t;
            t.Elapsed += CheckConnection;


            SetupConnection(connection);


        }



        private void OnToPeerMessage(PacketHeader packetHeader, Connection connection, ToPeerMessage incomingObject)
        {
            NetworkComms.Logger.Warn("Recieved message of type " + incomingObject.Message.Type.ToString());
            if (Address.Equals(incomingObject.SenderAddress))
            {
                Peer reciever = ConnectedPeers.FirstOrDefault(peer => peer.Address.Equals(incomingObject.RecieverAddress));
                if (reciever != null && reciever.ConnectedPeers.Contains(this))
                {
                    try
                    {
                        reciever.Connection.SendObject(incomingObject.GetType().Name, incomingObject);
                    }
                    catch
                    {
                        reciever.OnError();
                        //OnConnectedPeerError(reciever.Address);
                    }
                }
                else
                {
                    OnConnectedPeerError(incomingObject.RecieverAddress);
                }
            }

        }


        public void OnError()
        {
            ErrorsCount++;
            if (ErrorsCount >= 3)
            {
                Disconnect();
            }
        }

        public void OnConnectedPeerError(EndPoint address)
        {
            var message = new PeerDisconnectMessage(address);
            try
            {
                Connection.SendObject(message.GetType().Name, message);
            }
            catch
            {
                OnError();
            }
        }


        public void CheckConnection(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool alive = false;
            try
            {
                alive = Connection.ConnectionAlive();
            }
            catch { }

            if (!alive)
            {
                OnError();
            }
        }


        private void OnConnectToPeerWithTrackerMessage(PacketHeader packetHeader, Connection connection, ConnectToPeerWithTrackerMessage incomingObject)
        {


            Peer peerToConnect = allPeers.FirstOrDefault(peer => peer.Address.Equals(incomingObject.RecieverAddress));

            if (peerToConnect != null)
            {
                if (!ConnectedPeers.Contains(peerToConnect))
                {
                    ConnectedPeers.Add(peerToConnect);
                }
                if (!peerToConnect.ConnectedPeers.Contains(this))
                {
                    peerToConnect.ConnectedPeers.Add(this);

                    try
                    {
                        peerToConnect.Connection.SendObject(incomingObject.GetType().Name, incomingObject);
                    }
                    catch
                    {
                        peerToConnect.OnError();
                        //OnConnectedPeerError(peerToConnect.Address);
                    }
                }

            }
            //если трекер не нашел пир адресат то отправляем отправителю дисконнект адресата
            else
            {
                var message = new PeerDisconnectMessage(incomingObject.SenderAddress);

                Connection.SendObject(message.GetType().Name, message);
            }


        }

        private void OnRequestPeersMessage(PacketHeader packetHeader, Connection connection, RequestPeersMessage incomingObject)
        {
            var peers = allPeers.ToList();
            peers.Sort(peerComparer);

            var peersToSend = peers.Where(peer => peer.Status == PeerStatus.Connected);
            peersToSend = peersToSend.Except(ConnectedPeers);
            peersToSend = peersToSend.Take(incomingObject.Count);

            var peersAddresses = peersToSend.Select(peer => peer.Address);
            var message = new PeersMessage(peersAddresses.ToList());

            Connection.SendObject(message.GetType().Name, message);


            foreach (var peer in peersToSend)
            {
                peer.SendToOthersCount++;
            }
        }

        private void OnPeerHashMessage(PacketHeader packetHeader, Connection connection, PeerHashMessage incomingObject)
        {
            Hash = incomingObject.PeerHash;
            Status = PeerStatus.Connected;

            CommonHelpers.LogPeers(allPeers);
        }

        private void RequestPeerForHash()
        {
            //отправить пусой хеш и ожидать его хеш
            var message = new PeerHashMessage(string.Empty, true);

            try
            {
                Connection.SendObject(message.GetType().Name, message);
            }
            catch { }
        }

        public void Disconnect()
        {
            t.Elapsed -= CheckConnection;
            allPeers.Remove(this);

            var ConnectedPeersCopy = new List<Peer>(ConnectedPeers);

            foreach (var peer in ConnectedPeersCopy)
            {


                //удалить это пир из списка того пира
                peer.ConnectedPeers.Remove(this);

                //отправить тому пиру сообщение об оключении
                var message = new PeerDisconnectMessage(Address);
                try
                {
                    peer.Connection.SendObject(message.GetType().Name, message);
                }
                catch
                {
                    peer.OnError();
                }
            }

            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }

            Status = PeerStatus.Disconnected;



            CommonHelpers.LogPeers(allPeers);
        }

    }

}

using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;

namespace BlockChainVotingsTracker
{
    public class Peer
    {
        public EndPoint Address { get; }
        public Connection Connection { get; set; }
        public string Hash { get; set; }
        public int SendToOthersCount { get; set; }
        public List<Peer> ConnectedPeers { get; }
        public PeerStatus Status { get; set; }

        public int ErrorsCount { get; set; }

        List<Peer> allPeers;
        static PeerComparer peerComparer = new PeerComparer();



        public Peer(Connection connection, List<Peer> allPeers)
        {
            this.ConnectedPeers = new List<Peer>();
            this.Connection = connection;
            this.Address = connection.ConnectionInfo.RemoteEndPoint;
            this.allPeers = allPeers;

            this.Status = PeerStatus.NoHashRecieved;

            //обработчики приходящих сообщений
            //this.Connection.AppendShutdownHandler((c) => Disconnect());
            Connection.AppendIncomingPacketHandler<PeerDisconnectMessage>(typeof(PeerDisconnectMessage).Name,
                        (p, c, m) => Disconnect());
            this.Connection.AppendIncomingPacketHandler<PeerHashMessage>(typeof(PeerHashMessage).Name, OnPeerHashMessage);
            this.Connection.AppendIncomingPacketHandler<RequestPeersMessage>(typeof(RequestPeersMessage).Name, OnRequestPeersMessage);
            this.Connection.AppendIncomingPacketHandler<ConnectToPeerWithTrackerMessage>(typeof(ConnectToPeerWithTrackerMessage).Name, OnConnectToPeerWithTrackerMessage);
            this.Connection.AppendIncomingPacketHandler<ToPeerMessage>(typeof(ToPeerMessage).Name, OnToPeerMessage);

            RequestPeerForHash();
        }

        private void OnToPeerMessage(PacketHeader packetHeader, Connection connection, ToPeerMessage incomingObject)
        {
            if (Address == incomingObject.SenderAddress)
            {
                Peer reciever = ConnectedPeers.FirstOrDefault(peer => peer.Address.Equals(incomingObject.RecieverAddress));
                if (reciever != null && reciever.ConnectedPeers.Contains(this))
                {
                    //if (reciever.Connection.ConnectionAlive())
                        reciever.Connection.SendObject(incomingObject.GetType().Name, incomingObject);
                    //else reciever.OnError();
                }
            }

        }


        //public void OnError()
        //{
        //    ErrorsCount++;
        //    if (ErrorsCount>=3)
        //    {
        //        Disconnect();
        //    }
        //}


        private void OnConnectToPeerWithTrackerMessage(PacketHeader packetHeader, Connection connection, ConnectToPeerWithTrackerMessage incomingObject)
        {
            var peerToConnect = allPeers.FirstOrDefault(peer => peer.Address.Equals(incomingObject.RecieverAddress));

            if (peerToConnect != null)
            {
                if (!ConnectedPeers.Contains(peerToConnect))
                {
                    ConnectedPeers.Add(peerToConnect);
                }
                if (!peerToConnect.ConnectedPeers.Contains(this))
                {
                    peerToConnect.ConnectedPeers.Add(this);

                    //if (peerToConnect.Connection.ConnectionAlive())
                    peerToConnect.Connection.SendObject(incomingObject.GetType().Name, incomingObject);
                    //else peerToConnect.OnError();
                }



            }
            //если трекер не нашел пир адресат то отправляем отправителю дисконнект адресата
            else
            {
                var message = new PeerDisconnectMessage(peerToConnect.Address);

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
        }

        private void RequestPeerForHash()
        {
            //отправить пусой хеш и ожидать его хеш
            var message = new PeerHashMessage(string.Empty, true);

            //if (Connection.ConnectionAlive())
                Connection.SendObject(message.GetType().Name, message);
            //else OnError();
        }

        public void Disconnect()
        {

            allPeers.Remove(this);

            foreach (Peer peer in ConnectedPeers)
            {
                //удалить это пир из списка того пира
                peer.ConnectedPeers.Remove(this);

                //отправить тому пиру сообщение об оключении
                var message = new PeerDisconnectMessage(Address);
                var shell = new ToPeerMessage(Address, peer.Address, message);
                peer.Connection.SendObject(shell.GetType().Name, shell);
            }

            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }

            Status = PeerStatus.Disconnected;
        }

    }

}

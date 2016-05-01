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
    public class Peer: IDisposable
    {
        public EndPoint Address { get; }
        public Connection Connection { get; }
        public string Hash { get; set; }
        public int SendToOthersCount { get; set; }
        public List<Peer> ConnectedPeers { get; }
        public PeerStatus Status { get; set; }

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
            this.Connection.AppendShutdownHandler((c) => Disconnect());
            this.Connection.AppendIncomingPacketHandler<PeerHashMessage>(MessageType.PeerHash.ToString(), OnPeerHashMessage);
            this.Connection.AppendIncomingPacketHandler<RequestPeersMessage>(MessageType.RequestPeers.ToString(), OnRequestPeersMessage);
            this.Connection.AppendIncomingPacketHandler<ConnectToPeerWithTrackerMessage>(MessageType.ConnectToPeerWithTracker.ToString(), OnConnectToPeerWithTrackerMessage);
            this.Connection.AppendIncomingPacketHandler<ToPeerMessage>(MessageType.MessageToPeer.ToString(), OnToPeerMessage);

            RequestPeerForHash();
        }

        private void OnToPeerMessage(PacketHeader packetHeader, Connection connection, ToPeerMessage incomingObject)
        {
            if (Address == incomingObject.SenderAddress)
            {
                Peer reciever = ConnectedPeers.First(peer => peer.Address == incomingObject.RecieverAddress);
                if (reciever != null && reciever.ConnectedPeers.Contains(this))
                {
                    reciever.Connection.SendObject(MessageType.MessageToPeer.ToString(), incomingObject);
                }
            }

        }

        private void OnConnectToPeerWithTrackerMessage(PacketHeader packetHeader, Connection connection, ConnectToPeerWithTrackerMessage incomingObject)
        {
            var peerToConnect = allPeers.First(peer => peer.Address == incomingObject.RecieverAddress);

            if (peerToConnect != null)
            {
                if (!ConnectedPeers.Contains(peerToConnect))
                {
                    ConnectedPeers.Add(peerToConnect);
                }
                if (!peerToConnect.ConnectedPeers.Contains(this))
                {
                    peerToConnect.ConnectedPeers.Add(this);
                }
            }


        }

        private void OnRequestPeersMessage(PacketHeader packetHeader, Connection connection, RequestPeersMessage incomingObject)
        {
            allPeers.Sort(peerComparer);

            var peersToSend = allPeers.Where(peer => peer.Status == PeerStatus.Connected);
            peersToSend = peersToSend.Except(ConnectedPeers);
            peersToSend = peersToSend.Take(incomingObject.Count);

            var peersHashes = peersToSend.Select(peer => peer.Address);
            var message = new PeersMessage(peersHashes.ToList());
            Connection.SendObject(MessageType.Peers.ToString(), message);


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
            Connection.SendObject(MessageType.PeerHash.ToString(), message);
        }

        public void Disconnect()
        {
            foreach (Peer peer in ConnectedPeers)
            {
                //удалить это пир из списка того пира
                peer.ConnectedPeers.Remove(this);

                //отправить тому пиру сообщение об оключении
                var message = new PeerDisconnectMessage(Hash);
                peer.Connection.SendObject(MessageType.PeerDisconnect.ToString(), message);

                Status = PeerStatus.Disconnected;
            }
        }

        public void Dispose()
        {
            if (Connection != null) Connection.Dispose();
        }
    }

}

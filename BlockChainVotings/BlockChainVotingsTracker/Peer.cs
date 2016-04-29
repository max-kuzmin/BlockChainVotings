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
        public string Address { get; }
        public Connection Connection { get; }
        public string Hash { get; set; }
        public int SendToOthersCount { get; set; }
        public List<Peer> ConnectedPeers { get; }
        public PeerStatus Status { get; set; }

        public event EventHandler<RequestPeersEventArgs> OnRequestPeers;


        public Peer(Connection connection)
        {
            this.ConnectedPeers = new List<Peer>();
            this.Connection = connection;
            this.Address = connection.ConnectionInfo.RemoteEndPoint.ToString();

            this.Status = PeerStatus.NoHashRecieved;

            //обработчики приходящих сообщений
            this.Connection.AppendShutdownHandler(OnDisconnect);
            this.Connection.AppendIncomingPacketHandler<PeerHashMessage>(MessageType.PeerHash.ToString(), OnPeerHashMessage);
            this.Connection.AppendIncomingPacketHandler<RequestPeersMessage>(MessageType.RequestPeers.ToString(), OnRequestPeersMessage);

            AskPeerForHash();
        }

        public void SendPeers(List<Peer> peers)
        {
            var peersHashes = peers.Select(peer => peer.Hash);
            var message = new PeersMessage(peersHashes.ToList());

            Connection.SendObject(MessageType.Peers.ToString(), message);
        }


        private void OnRequestPeersMessage(PacketHeader packetHeader, Connection connection, RequestPeersMessage incomingObject)
        {
            var e = new RequestPeersEventArgs(incomingObject.Count, ConnectedPeers);
            OnRequestPeers(this, e);
        }

        private void OnPeerHashMessage(PacketHeader packetHeader, Connection connection, PeerHashMessage incomingObject)
        {
            Hash = incomingObject.PeerHash;
            Status = PeerStatus.Connected;
        }

        private void OnDisconnect(Connection connection)
        {
            Disconnect();
        }

        private void AskPeerForHash()
        {
            //отправить пусой хеш и ожидаь его хеш
            var message = new PeerHashMessage(string.Empty);
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
            Connection.Dispose();
        }
    }

}

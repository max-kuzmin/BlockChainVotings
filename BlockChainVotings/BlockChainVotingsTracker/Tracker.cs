using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsTracker
{
    public class Tracker:IDisposable
    {
        public List<Peer> Peers { get; }
        public int Port { get; }
        PeerComparer peerComparer;


        public Tracker()
        {
            Port = 10101;
            this.Peers = new List<Peer>();
            this.peerComparer = new PeerComparer;

            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnectPeer);
        }

        private void OnConnectPeer(Connection connection)
        {
            var peer = new Peer(connection);
            peer.OnRequestPeers += SendPeers;

            Peers.Add(peer);
        }

        private void SendPeers(object sender, RequestPeersEventArgs e)
        {
            Peers.Sort(peerComparer);

            var peersToSend = Peers.Where(peer => peer.Status == PeerStatus.Connected);
            peersToSend = peersToSend.Except(e.NotForSendingPeers);
            peersToSend = peersToSend.Take(e.Count);

            if (sender is Peer)
            {
                (sender as Peer).SendPeers(peersToSend.ToList());
            }
        }

        public void Start()
        {
            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Port));
        }

        public void Stop()
        {
            Connection.StopListening();
            foreach (Peer peer in Peers)
            {
                peer.Disconnect();
            }

        }

        public void Dispose()
        {
            foreach (Peer peer in Peers)
            {
                peer.Dispose();
            }
            NetworkComms.Shutdown();
        }


    }
}

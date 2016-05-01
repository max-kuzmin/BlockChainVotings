using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using NetworkCommsDotNet.Tools;

namespace BlockChainVotingsTracker
{
    public class Tracker:IDisposable
    {
        public List<Peer> Peers { get; }
        public int Port { get; }
        


        public Tracker()
        {
            Port = 10101;
            this.Peers = new List<Peer>();


            SetupLogging();

            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnectPeer);
        }

        private void OnConnectPeer(Connection connection)
        {
            var peer = new Peer(connection, Peers);

            Peers.Add(peer);
        }


        public void Start()
        {
            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Port));
            NetworkComms.Logger.Warn("Tracker started");
        }

        public void Stop()
        {
            Connection.StopListening();
            foreach (Peer peer in Peers)
            {
                peer.Disconnect();
            }
            NetworkComms.Logger.Warn("Tracker stopped");

        }

        public void Dispose()
        {
            foreach (Peer peer in Peers)
            {
                peer.Dispose();
            }
            NetworkComms.Shutdown();
        }


        private void SetupLogging()
        {
            LiteLogger logger = new LiteLogger(LiteLogger.LogMode.ConsoleAndLogFile, "log.txt");
            NetworkComms.EnableLogging(logger);

            NetworkComms.Logger.Warn("==================== Initialisation ====================");


        }


    }

}

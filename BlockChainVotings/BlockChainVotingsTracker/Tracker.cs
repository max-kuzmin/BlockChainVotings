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
    public class Tracker
    {
        public List<Peer> Peers { get; }
        public int Port { get; }
        public TrackerStatus Status { get; set; }

        public Tracker()
        {
            Port = 10101;
            this.Peers = new List<Peer>();
            this.Status = TrackerStatus.Stopped;

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
            if (Status == TrackerStatus.Stopped)
            {
                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Port));
                NetworkComms.Logger.Warn("Tracker started");
                Status = TrackerStatus.Started;
            }
        }

        public void Stop()
        {
            if (Status == TrackerStatus.Started)
            {
                Connection.StopListening();
                foreach (Peer peer in Peers)
                {
                    peer.Disconnect();
                }
                NetworkComms.Shutdown();
                NetworkComms.Logger.Warn("Tracker stopped");
                Status = TrackerStatus.Stopped;
            }

        }



        private void SetupLogging()
        {
            LiteLogger logger = new LiteLogger(LiteLogger.LogMode.ConsoleAndLogFile, "log.txt");
            NetworkComms.EnableLogging(logger);

            NetworkComms.Logger.Warn("==================== Initialisation ====================");


        }


    }

}

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
using System.Net.Sockets;
using System.Net.NetworkInformation;
using NetworkCommsDotNet.Connections.TCP;
using System.Timers;

namespace BlockChainVotingsTracker
{
    public class Tracker
    {
        public List<Peer> Peers { get; }
        public TrackerStatus Status { get; set; }

        Timer t;

        public Tracker()
        {
            this.Peers = new List<Peer>();
            this.Status = TrackerStatus.Stopped;

            t = new Timer(CommonHelpers.CheckAliveInterval);

            SetupLogging();

            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnectPeer);
        }

        private void OnConnectPeer(Connection connection)
        {
            var existPeer = Peers.FirstOrDefault(p => p.Address.Equals(connection.ConnectionInfo.RemoteEndPoint));

            if (existPeer == null)
            {
                var peer = new Peer(connection, Peers);

                t.Elapsed += (s, e) => peer.CheckConnection();

                Peers.Add(peer);
            }
            else
            {
                existPeer.Connection = connection;
            }
        }


        public void Start()
        {
            if (Status == TrackerStatus.Stopped)
            {
                TCPConnection.StartListening(CommonHelpers.GetLocalEndPoint(CommonHelpers.TrackerPort), false);
                Status = TrackerStatus.Started;

                NetworkComms.Logger.Warn("Tracker started");

                t.Start();


            }
        }

        public void Stop()
        {
            if (Status == TrackerStatus.Started)
            {
                t.Stop();

                while (Peers.Count>0)
                {
                    var peer = Peers.First();
                    peer.Disconnect();
                }
                Connection.StopListening();
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

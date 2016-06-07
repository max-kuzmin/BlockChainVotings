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
using System.IO;

namespace BlockChainVotingsTracker
{
    public class Tracker
    {
        public List<Peer> Peers { get; private set; }
        public TrackerStatus Status { get; set; }

        Timer t;

        public Tracker()
        {
            this.Peers = new List<Peer>();
            this.Status = TrackerStatus.Stopped;

            t = new Timer(CommonHelpers.CheckAliveInterval);

            NetworkComms.DisableLogging();
            if (File.Exists("BlockChainVotingsTracker_log.txt"))
                File.Delete("BlockChainVotingsTracker_log.txt");
            LiteLogger logger = new LiteLogger(LiteLogger.LogMode.ConsoleAndLogFile, "BlockChainVotingsTracker_log.txt");
            NetworkComms.EnableLogging(logger);

            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnectPeer);
        }

        private void OnConnectPeer(Connection connection)
        {
            var existPeer = Peers.FirstOrDefault(p => p.Address.Equals(connection.ConnectionInfo.RemoteEndPoint));

            if (existPeer == null && (connection.ConnectionInfo.RemoteEndPoint as IPEndPoint).Port != CommonHelpers.TrackerPort)
            {
                var peer = new Peer(connection, Peers, t);

                Peers.Add(peer);
            }
            else
            {
                existPeer.SetupConnection(connection);
            }
        }


        public void Start()
        {
            if (Status == TrackerStatus.Stopped)
            {
                try
                {
                    TCPConnection.StartListening(CommonHelpers.GetLocalEndPoint(CommonHelpers.TrackerPort), false);
                    Status = TrackerStatus.Started;
                }
                catch
                {
                    NetworkComms.Logger.Error("Can't start listener on this IP: " + CommonHelpers.GetLocalEndPoint(CommonHelpers.TrackerPort).ToString());
                }

                NetworkComms.Logger.Warn("===== Tracker started =====");

                t.Start();


            }
        }

        public void Stop()
        {
            if (Status == TrackerStatus.Started)
            {
                t.Stop();

                while (Peers.Count > 0)
                {
                    var peer = Peers.First();
                    peer.Disconnect();
                }
                Connection.StopListening();
                NetworkComms.Shutdown();
                NetworkComms.Logger.Warn("===== Tracker stopped =====");
                Status = TrackerStatus.Stopped;

            }

        }




    }

}

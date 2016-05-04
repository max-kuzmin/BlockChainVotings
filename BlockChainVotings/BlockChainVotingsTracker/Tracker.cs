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

namespace BlockChainVotingsTracker
{
    public class Tracker
    {
        public List<Peer> Peers { get; }
        static public int Port { get { return 10101; } }
        public TrackerStatus Status { get; set; }

        public Tracker()
        {
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
                Connection.StartListening(ConnectionType.TCP, GetLocalEndPoint());
                Status = TrackerStatus.Started;

                NetworkComms.Logger.Warn("Tracker started");
            }
        }

        public void Stop()
        {
            if (Status == TrackerStatus.Started)
            {
                foreach (Peer peer in Peers)
                {
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

        static public EndPoint GetLocalEndPoint()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            var address = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).OrderByDescending(addr => addr.Address).First();
            EndPoint endPoint = new IPEndPoint(address, Port);
            return endPoint;
        }


    }

}

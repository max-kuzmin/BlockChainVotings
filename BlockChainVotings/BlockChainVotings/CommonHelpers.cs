using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public static class CommonHelpers
    {
        static public int PeerPort { get { return 10101; } }
        static public int TrackerPort { get { return 10102; } }
        static public int DiscoveryPort { get { return 10001; } }
        static public int CheckAliveInterval { get { return 60000; } }

        static public string LocalHash = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());


        static public IPEndPoint GetLocalEndPoint(int port)
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            var address = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).OrderByDescending(addr => addr.Address).First();
            IPEndPoint endPoint = new IPEndPoint(address, port);
            return endPoint;
        }

        static public void LogPeers(List<Peer> peers)
        {
            NetworkComms.Logger.Warn("Peers: connected - " + peers.Count(p => p.Status == PeerStatus.Connected) +
                ", noHashRecieved - " + peers.Count(p => p.Status == PeerStatus.NoHashRecieved) +
                ", disconnected - " + peers.Count(p => p.Status == PeerStatus.Disconnected));
        }

    }
}

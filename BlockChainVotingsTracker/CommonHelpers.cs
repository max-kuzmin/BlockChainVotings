using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsTracker
{
    public static class CommonHelpers
    {
        static public int PeerPort { get { return 10101; } }
        static public int TrackerPort { get { return 10102; } }
        static public int DiscoveryPort { get { return 10001; } }
        static public int CheckAliveInterval { get { return 60000; } }
        static public int MessagesInterval { get { return 1000; } }

        static public string LocalHash = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());


        static IPAddress lanLocalAddr = null;

        static public IPEndPoint GetLocalEndPoint(int port)
        {

            if (lanLocalAddr == null)
            {

                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                string addressString = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                    .Select(ip => ip.ToString())
                    .First(ip => ip.Contains("192."));

                lanLocalAddr = IPAddress.Parse(addressString);
            }


            return new IPEndPoint(lanLocalAddr, port);

        }

        static public void LogPeers(List<Peer> peers)
        {
            NetworkComms.Logger.Warn("Peers: connected - " + peers.Count(p => p.Status == PeerStatus.Connected) +
                ", noHashRecieved - " + peers.Count(p => p.Status == PeerStatus.NoHashRecieved) +
                ", disconnected - " + peers.Count(p => p.Status == PeerStatus.Disconnected));
        }

    }
}

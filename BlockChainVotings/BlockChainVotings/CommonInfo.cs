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
    public static class CommonInfo
    {
        static public int PeerPort { get { return 10101; } }
        static public int TrackerPort { get { return 10102; } }
        static public int DiscoveryPort { get { return 10001; } }
        static public string LocalHash = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());


        static public EndPoint GetLocalEndPoint(bool forPeerDiscovery = false)
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            var address = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).OrderByDescending(addr => addr.Address).First();
            EndPoint endPoint = forPeerDiscovery ? (new IPEndPoint(address, DiscoveryPort)) : (new IPEndPoint(address, PeerPort));
            return endPoint;
        }

    }
}

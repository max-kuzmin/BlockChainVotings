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
        static public int Port { get { return 10101; } }
        static public string LocalHash = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());


        static public EndPoint GetLocalEndPoint(bool forPeerDiscovery = false)
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            var address = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).OrderByDescending(addr => addr.Address).First();
            EndPoint endPoint = forPeerDiscovery ? (new IPEndPoint(address, 10001)) : (new IPEndPoint(address, Port));
            return endPoint;
        }

    }
}

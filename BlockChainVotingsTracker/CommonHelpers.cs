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


        static IPAddress localAddr = null;

        static public IPEndPoint GetLocalEndPoint(int port)
        {
            if (localAddr == null)
            {
                try
                {
                    var client = new UdpClient("8.8.8.8", 80);
                    client.Client.ReceiveTimeout = 2000;
                    client.Client.SendTimeout = 2000;
                    localAddr = ((IPEndPoint)client.Client.LocalEndPoint).Address;
                }
                catch
                {
                    return null;
                }
            }
            IPEndPoint endPoint = new IPEndPoint(localAddr, port);
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

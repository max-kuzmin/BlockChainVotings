using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Virgil.Crypto;
using Virgil.Crypto.Foundation;

namespace BlockChainVotingsAndroid
{
    public static class CommonHelpers
    {
        static public int PeerPort { get { return 10101; } }
        static public int TrackerPort { get { return 10102; } }
        static public int DiscoveryPort { get { return 10001; } }
        static public int PeersCheckInterval { get { return 60000; } }
        static public int WaitAfterStartInterval { get { return 5000; } }
        static public int MessagesInterval { get { return 1000; } }

        static TimeSpan? dateDelta;
        public static int TransactionsInBlock { get { return 10; } }


        static public event EventHandler<IntEventArgs> PeersCountChanged;
        static public event EventHandler<IntEventArgs> TrackersCountChanged;


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

            if (PeersCountChanged != null)
                PeersCountChanged(null, new IntEventArgs(peers.Count(p => p.Status == PeerStatus.Connected)));
        }

        static public void LogTrackers(List<Tracker> trackers)
        {
            NetworkComms.Logger.Warn("Trackers: connected - " + trackers.Count(p => p.Status == TrackerStatus.Connected) +
                ", disconnected - " + trackers.Count(p => p.Status == TrackerStatus.Disconnected));

            if (TrackersCountChanged != null)
                TrackersCountChanged(null, new IntEventArgs(trackers.Count(p => p.Status == TrackerStatus.Connected)));
        }



        static public string CalcHash(string data)
        {
            byte[] binData = Encoding.UTF8.GetBytes(data);
            byte[] result = VirgilHash.Sha256().Hash(binData);
            return Convert.ToBase64String(result);
        }



        static public string[] GetPublicPrivateKeys()
        {
            VirgilKeyPair pair = VirgilKeyPair.Generate(VirgilKeyPair.Type.EC_SECP256K1);
            var keys = new string[2];
            
            keys[0] = Encoding.UTF8.GetString(pair.PublicKey())
                .Replace("-----BEGIN PUBLIC KEY-----", "")
                .Replace("-----END PUBLIC KEY-----", "")
                .Replace("\n", "");
            keys[1] = Encoding.UTF8.GetString(pair.PrivateKey())
                .Replace("-----BEGIN EC PRIVATE KEY-----", "")
                .Replace("-----END EC PRIVATE KEY-----", "")
                .Replace("\n", "");

            return keys;
        }


        static public bool CheckKeys(string publicKey, string privateKey) 
        {
            try
            {
                return VirgilKeyPair.IsKeyPairMatch(Convert.FromBase64String(publicKey), Convert.FromBase64String(privateKey));
            }
            catch
            {
                return false;
            }
        }


        static public string SignData(string data, string privateKey)
        {
            var key = Convert.FromBase64String(privateKey);
            return CryptoHelper.Sign(data, key);
        }

        static public bool VerifyData(string data, string signature, string publicKey)
        {
            var key = Convert.FromBase64String(publicKey);
            return CryptoHelper.Verify(data, signature, key);
        }


        static public DateTime GetTime()
        {
            if (dateDelta==null)
            {
                DateTime time = DateTime.Now;

                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        var client = new TcpClient("129.6.15.30", 13);
                        client.ReceiveTimeout = 2000;
                        client.SendTimeout = 2000;
                        using (var streamReader = new StreamReader(client.GetStream()))
                        {
                            var response = streamReader.ReadToEnd();
                            var utcDateTimeString = response.Substring(7, 17);
                            time = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                            break;
                        }
                    }
                    catch { }

                }

                dateDelta = time - DateTime.Now;
            }

            return (DateTime)(DateTime.Now + dateDelta);
        }



        


    }
}

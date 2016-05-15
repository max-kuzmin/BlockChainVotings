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

namespace BlockChainVotings
{
    public static class CommonHelpers
    {
        static public int PeerPort { get { return 10101; } }
        static public int TrackerPort { get { return 10102; } }
        static public int DiscoveryPort { get { return 10001; } }
        static public int CheckAliveInterval { get { return 60000; } }


        static TimeSpan? dateDelta;
        public static int TransactionsInBlock { get { return 10; } }

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



        static public string CalcHash(string data)
        {
            byte[] binData = Encoding.UTF8.GetBytes(data);
            byte[] result = VirgilHash.Sha256().Hash(binData);
            return Convert.ToBase64String(result);
        }



        static public string[] GetPublicPrivateKeys()
        {
            VirgilKeyPair pair = CryptoHelper.GenerateKeyPair();
            var keys = new string[2];
            keys[0] = Convert.ToBase64String(pair.PublicKey());
            keys[1] = Convert.ToBase64String(pair.PrivateKey());
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
                dateDelta = GetInternetTime() - DateTime.Now;
            }

            return (DateTime)(DateTime.Now + dateDelta);
        }

        static DateTime GetInternetTime()
        {
            DateTime localDateTime = DateTime.Now;

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var client = new TcpClient("time.nist.gov", 13);
                    using (var streamReader = new StreamReader(client.GetStream()))
                    {
                        var response = streamReader.ReadToEnd();
                        var utcDateTimeString = response.Substring(7, 17);
                        localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                        break;
                    }
                }
                catch { }

            }

            return localDateTime;
        }

    }
}

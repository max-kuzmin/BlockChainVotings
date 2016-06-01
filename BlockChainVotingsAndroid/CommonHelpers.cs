using NetworkCommsDotNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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

        static public bool RootChecked = false;


        static public event EventHandler<IntEventArgs> PeersCountChanged;
        static public event EventHandler<IntEventArgs> TrackersCountChanged;


        static IPAddress lanLocalAddr = null;
        static IPAddress wanLocalAddr = null;

        static public IPEndPoint GetLocalEndPoint(int port, bool forSending = false)
        {

            if (lanLocalAddr == null)
            {

                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                string addressString = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                    .Select(ip => ip.ToString())
                    .First(ip => ip.Contains("192."));

                lanLocalAddr = IPAddress.Parse(addressString);
            }

            if (wanLocalAddr == null && !VotingsUser.UseLanLocalIP)
            {

                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        var req = HttpWebRequest.Create("http://api.ipify.org/?format=json");
                        req.Timeout = 1000;
                        var res = req.GetResponse();
                        using (var streamReader = new StreamReader(res.GetResponseStream()))
                        {
                            var response = streamReader.ReadToEnd();
                            wanLocalAddr = IPAddress.Parse(JObject.Parse(response)["ip"].Value<string>());
                            break;
                        }
                    }
                    catch { }
                }

            }


            if (forSending || VotingsUser.UseLanLocalIP || wanLocalAddr == null)
                return new IPEndPoint(lanLocalAddr, port);
            else
                return new IPEndPoint(wanLocalAddr, port);
        }



        static public void LogPeers(List<Peer> peers)
        {
            NetworkComms.Logger.Warn("Peers: connected - " + peers.Count(p => p.Status == PeerStatus.Connected) +
                ", noHashRecieved - " + peers.Count(p => p.Status == PeerStatus.NoHashRecieved) +
                ", disconnected - " + peers.Count(p => p.Status == PeerStatus.Disconnected));

            PeersCountChanged?.Invoke(null, new IntEventArgs(peers.Count(p => p.Status == PeerStatus.Connected)));
        }

        static public void LogTrackers(List<Tracker> trackers)
        {
            NetworkComms.Logger.Warn("Trackers: connected - " + trackers.Count(p => p.Status == TrackerStatus.Connected) +
                ", disconnected - " + trackers.Count(p => p.Status == TrackerStatus.Disconnected));

            TrackersCountChanged?.Invoke(null, new IntEventArgs(trackers.Count(p => p.Status == TrackerStatus.Connected)));
        }



        static public string CalcHash(string data)
        {
            string normalized = Regex.Replace(data, "(?<!\r)\n", "\r\n");

            byte[] binData = Encoding.UTF8.GetBytes(normalized);
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
            string normalized = Regex.Replace(data, "(?<!\r)\n", "\r\n");

            var key = Convert.FromBase64String(privateKey);
            return CryptoHelper.Sign(normalized, key);
        }

        static public bool VerifyData(string data, string signature, string publicKey)
        {
            string normalized = Regex.Replace(data, "(?<!\r)\n", "\r\n");

            var key = Convert.FromBase64String(publicKey);
            return CryptoHelper.Verify(normalized, signature, key);
        }


        static public DateTime GetTime()
        {
            if (dateDelta == null)
            {
                DateTime time = DateTime.Now;

                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        var client = new TcpClient();
                        client.ReceiveTimeout = 1000;
                        client.SendTimeout = 1000;
                        client.Connect("129.6.15.30", 13);
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

using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Virgil.Crypto;
using Virgil.Crypto.Foundation;
using System.Net;

namespace BlockChainVotings
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ////поиск пиров
            //PeerDiscovery.OnPeerDiscovered += PeerDiscovered;
            //PeerDiscovery.EnableDiscoverable(PeerDiscovery.DiscoveryMethod.UDPBroadcast);
            //PeerDiscovery.DiscoverPeersAsync(PeerDiscovery.DiscoveryMethod.UDPBroadcast);

            ////создать серв
            //NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", PrintIncomingMessage);
            //Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, 10000));


            ////создать соединение и отправить сообщение
            //ConnectionInfo connInfo = new ConnectionInfo("192.168.0.36", 10000);
            //Connection newTCPConn = TCPConnection.GetConnection(connInfo);
            //newTCPConn.SendObject<string>("Message", "it works");

            


            //подписать-проверить файл
            VirgilKeyPair pair = CryptoHelper.GenerateKeyPair();
            string sign = CryptoHelper.Sign("hello world", pair.PrivateKey());
            bool res = CryptoHelper.Verify("hello world", sign, pair.PublicKey());
            MessageBox.Show(Convert.ToBase64String(pair.PublicKey()) + "\n\n\n" + Convert.ToBase64String(pair.PrivateKey()) + "\n\n\n" + sign + "\n\n\n" + res.ToString());
        }

        //когда нашли пир
        private void PeerDiscovered(ShortGuid peerIdentifier, Dictionary<ConnectionType, List<EndPoint>> discoveredListenerEndPoints)
        {
            MessageBox.Show("\nEndpoints discovered for peer with networkIdentifier " + peerIdentifier);
            
        }

        //обработка входящего сообщения
        private void PrintIncomingMessage(PacketHeader packetHeader, Connection connection, string incomingObject)
        {
            MessageBox.Show("\nA message was received from " + connection.ToString() + " which said '" + incomingObject + "'.");
        }

        //хеш
        public string CalcSHA256(byte[] data)
        {
            byte[] result = VirgilHash.Sha256().Hash(data);
            return Convert.ToBase64String(result);
        }

    }
}

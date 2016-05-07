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

        Network net;

        public MainForm()
        {
            InitializeComponent();


            ////подписать-проверить файл
            //VirgilKeyPair pair = CryptoHelper.GenerateKeyPair();
            //string sign = CryptoHelper.Sign("hello world", pair.PrivateKey());
            //bool res = CryptoHelper.Verify("hello world", sign, pair.PublicKey());
            //MessageBox.Show(Convert.ToBase64String(pair.PublicKey()) + "\n\n\n" + Convert.ToBase64String(pair.PrivateKey()) + "\n\n\n" + sign + "\n\n\n" + res.ToString());
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Task.Run( ()=> net.Connect(textBoxTrackers.Lines) );
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Task.Run( () => net.Disconnect() );
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConsoleToTextBoxWriter writer = new ConsoleToTextBoxWriter(textBoxConsole);
            Console.SetOut(writer);

            if (CommonInfo.GetLocalEndPoint() == null)
            {
                MessageBox.Show("Для продолжения необходимо подключение к интернету");
            }

            net = new Network();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Run(() => net.Disconnect());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => net.RequestPeers());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            list.Add("123526326");
            Task.Run(() => net.SendMessageToPeer(new RequestBlocksMessage(list), new IPEndPoint(0xC0A8004D, CommonInfo.PeerPort)));

            Task.Run(() => net.SendMessageToPeer(new RequestTransactionsMessage(list), new IPEndPoint(0xC0A8004D, CommonInfo.PeerPort)));

            //Task.Run(() => net.SendMessageToPeer(new TransactionsMessage(new List<Transaction>()), new IPEndPoint(0x2a00a8c0, 10001)));
            //Task.Run(() => net.SendMessageToPeer(new BlocksMessage(new List<Block>()), new IPEndPoint(0x2a00a8c0, 10001)));
        }


        ////хеш
        //public string CalcSHA256(byte[] data)
        //{
        //    byte[] result = VirgilHash.Sha256().Hash(data);
        //    return Convert.ToBase64String(result);
        //}

    }
}

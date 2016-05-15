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
        BlockChainVotings blockChain;

        public MainForm()
        {
            InitializeComponent();

            (new CreateUserForm(new BlockChainVotings())).Show();
 
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

            if (CommonHelpers.GetLocalEndPoint(1) == null)
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
            Task.Run(() => net.SendMessageToPeer(new RequestBlocksMessage(list), new IPEndPoint(0x4D00A8C0, CommonHelpers.PeerPort)));
        }

    }
}

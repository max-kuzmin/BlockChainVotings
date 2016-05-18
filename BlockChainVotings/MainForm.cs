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

        //Network net;
        BlockChainVotings blockChain;
        RegisterLoginForm regForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Task.Run( ()=> blockChain.net.Connect(textBoxTrackers.Lines) );
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Task.Run( () => blockChain.net.Disconnect() );
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConsoleToTextBoxWriter writer = new ConsoleToTextBoxWriter(textBoxConsole);
            Console.SetOut(writer);

            regForm = new RegisterLoginForm();
            regForm.SuccssesLogin += RegForm_SuccssesLogin;
            regForm.FormClosed += (s, a) =>
            {
                Close();
            };

            regForm.Show();

            this.WindowState = FormWindowState.Minimized;
            this.Enabled = false;

            blockChain = new BlockChainVotings();
            (new CreateUserForm(blockChain)).Show();
            (new CreateVotingForm(blockChain)).Show();
            //(new RegisterLoginForm()).Show();
        }

        private void RegForm_SuccssesLogin(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Run(() => blockChain.net.Disconnect());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => blockChain.net.RequestPeers());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            list.Add("123526326");
            Task.Run(() => blockChain.net.SendMessageToPeer(new RequestBlocksMessage(list), new IPEndPoint(0x4D00A8C0, CommonHelpers.PeerPort)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            blockChain.CheckRoot();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            blockChain.MakeBlock();
        }
    }
}

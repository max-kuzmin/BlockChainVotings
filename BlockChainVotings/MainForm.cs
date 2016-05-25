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
using MaterialSkin;
using MaterialSkin.Controls;

namespace BlockChainVotings
{
    public partial class MainForm : MaterialForm
    {

        BlockChainVotings blockChain;
        RegisterLoginForm regForm;

        public MainForm()
        {
            InitializeComponent();

            //MaterialSkinManager.Instance.Theme = new DarkTheme();
            MaterialSkinManager.Instance.AddFormToManage(this);


            this.Text = Properties.Resources.votingSoftware;
            materialLabelAbout.Text = Properties.Resources.about;
            materialLabelBlocks.Text = Properties.Resources.blocks;
            materialLabelConnectedTrackers.Text = Properties.Resources.connectedTrackers;
            materialLabelConsole.Text = Properties.Resources.console;
            materialLabelHello.Text = Properties.Resources.hello;
            materialLabelNetwork.Text = Properties.Resources.netConnection;
            materialLabelPeers.Text = Properties.Resources.connectedPeers;
            materialLabelStatistics.Text = Properties.Resources.netStatistic;
            materialLabelTrackers.Text = Properties.Resources.trackers;
            materialLabelTransactions.Text = Properties.Resources.transactions;
            materialLabelUsers.Text = Properties.Resources.users;
            materialCheckBoxCreateBlocks.Text = Properties.Resources.createBlocks;
            materialRaisedButtonBanUser.Text = Properties.Resources.banUser;
            materialRaisedButtonCreateUser.Text = Properties.Resources.createUser;
            materialRaisedButtonCreateVoting.Text = Properties.Resources.createVoting;
            materialRaisedButtonMyStatistic.Text = Properties.Resources.myStatistic;
            materialRaisedButtonTheme.Text = Properties.Resources.changeTheme;
            materialRaisedButtonUserStatistic.Text = Properties.Resources.usersStatistics;
            materialRaisedButtonVote.Text = Properties.Resources.vote;
            materialRaisedButtonVotingStatistic.Text = Properties.Resources.votingsStatistics;
            tabPageMain.Text = Properties.Resources.main;
            tabPageOptions.Text = Properties.Resources.options;
            buttonStart.Text = Properties.Resources.start;
            buttonStop.Text = Properties.Resources.stop;
            notifyIcon1.Text = Properties.Resources.votingSoftware;



        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Task.Run( ()=> blockChain.Start() );

            buttonStart.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Task.Run(() => blockChain.Stop() );

            buttonStart.Enabled = true;
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
            this.ShowInTaskbar = false;

            blockChain = new BlockChainVotings();


            if (blockChain.Started)
                buttonStart.Enabled = false;
            else
                buttonStart.Enabled = true;

        }

        private void RegForm_SuccssesLogin(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Enabled = true;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;

            materialLabelStatistics.Font = new Font("Arial", 10, FontStyle.Bold);
            materialLabelHello.Font = new Font("Arial", 10, FontStyle.Bold);


            //=============


            if (VotingsUser.PublicKey == VotingsUser.RootPublicKey)
            {
                materialRaisedButtonBanUser.Show();
                materialRaisedButtonCreateUser.Show();
                materialRaisedButtonCreateVoting.Show();
                materialRaisedButtonVote.Hide();
            }
            else
            {
                materialRaisedButtonBanUser.Hide();
                materialRaisedButtonCreateUser.Hide();
                materialRaisedButtonCreateVoting.Hide();
                materialRaisedButtonVote.Show();
            }

            materialCheckBoxCreateBlocks.Checked = VotingsUser.CreateOwnBlocks;
            textBoxTrackers.Text = VotingsUser.Trackers;
            textBoxTrackers.Select(0, 0);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Run(() => blockChain.Stop());
        }


        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            VotingsUser.Theme++;
            if (VotingsUser.Theme > 3) VotingsUser.Theme = 0;

            CommonHelpers.ChangeTheme(VotingsUser.Theme);

            VotingsUser.ChangeSetting("theme", VotingsUser.Theme.ToString());
        }


        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void materialLabelAbout_VisibleChanged(object sender, EventArgs e)
        {
            materialLabelAbout.Font = new Font("Arial", 8);
            materialLabelAbout.ForeColor = Color.Gray;
        }

        private void materialRaisedButtonVote_Click(object sender, EventArgs e)
        {
            var form = new SendVoteForm(blockChain);
            form.Show();
        }

        private void materialRaisedButtonCreateVoting_Click(object sender, EventArgs e)
        {
            var form = new CreateVotingForm(blockChain);
            form.Show();
        }

        private void materialRaisedButtonCreateUser_Click(object sender, EventArgs e)
        {
            var form = new CreateUserForm(blockChain);
            form.Show();
        }

        private void materialRaisedButtonBanUser_Click(object sender, EventArgs e)
        {
            var form = new BanUserForm(blockChain);
            form.Show();
        }

        private void materialRaisedButtonVotingStatistic_Click(object sender, EventArgs e)
        {
            var form = new VotingsStatisticForm(blockChain);
            form.Show();
        }

        private void materialRaisedButtonUserStatistic_Click(object sender, EventArgs e)
        {
            var form = new UsersStatisticsForm(blockChain, false);
            form.Show();
        }

        private void materialRaisedButtonMyStatistic_Click(object sender, EventArgs e)
        {
            var form = new UsersStatisticsForm(blockChain, true);
            form.Show();
        }

        private void materialCheckBoxCreateBlocks_CheckedChanged(object sender, EventArgs e)
        {

            VotingsUser.CreateOwnBlocks = materialCheckBoxCreateBlocks.Checked;
            VotingsUser.ChangeSetting("createOwnBlocks", materialCheckBoxCreateBlocks.Checked.ToString());
        }

        private void textBoxTrackers_TextChanged(object sender, EventArgs e)
        {
            VotingsUser.Trackers = textBoxTrackers.Text;
            VotingsUser.ChangeSetting("trackers", textBoxTrackers.Text.ToString());
        }
    }
}

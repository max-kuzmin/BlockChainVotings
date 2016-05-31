using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;

namespace BlockChainVotings
{
    public partial class MainForm : MaterialForm
    {

        BlockChainVotings blockChain;
        RegisterLoginForm regForm;


        bool helloStatus = false;

        public MainForm()
        {
            InitializeComponent();

            //MaterialSkinManager.Instance.Theme = new DarkTheme();
            MaterialSkinManager.Instance.AddFormToManage(this);

            MaterialSkinManager.Instance.ROBOTO_MEDIUM_9 = new Font("Arial", 9);

            this.Text = Properties.Resources.votingSoftware;
            materialLabelAbout.Text = Properties.Resources.about;
            materialLabelBlocks.Text = Properties.Resources.blocks;
            materialLabelConnectedTrackers.Text = Properties.Resources.connectedTrackers;
            materialLabelConsole.Text = Properties.Resources.console;
            materialLabelHello.Text = Properties.Resources.hello + ", " + Properties.Resources.user;
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
            materialLabelVotings.Text = Properties.Resources.votings;
            materialCheckBoxCreateBlocks.Text = Properties.Resources.createBlocks;
            materialCheckBoxPeerDiscovery.Text = Properties.Resources.peerDiscovery;

            Icon = Properties.Resources.votingIcon;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Task.Run(() => blockChain.Start());

            buttonStart.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Task.Run(() => blockChain.Stop());

            buttonStart.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConsoleToTextBoxWriter writer = new ConsoleToTextBoxWriter(textBoxConsole);
            Console.SetOut(writer);

            regForm = new RegisterLoginForm();
            regForm.SuccsessLogin += RegForm_SuccssesLogin;
            regForm.FormClosed += (s, a) =>
            {
                Invoke(new Action(() => Close()));
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
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;

            
            blockChain.CheckRoot();


            this.Enabled = true;


            //=============


            if (VotingsUser.PublicKey == VotingsUser.RootPublicKey)
            {
                materialRaisedButtonBanUser.Show();
                materialRaisedButtonCreateUser.Show();
                materialRaisedButtonCreateVoting.Show();
                materialRaisedButtonVote.Hide();
                materialLabelAvaliableVotings.Hide();
            }
            else
            {
                materialRaisedButtonBanUser.Hide();
                materialRaisedButtonCreateUser.Hide();
                materialRaisedButtonCreateVoting.Hide();
                materialRaisedButtonVote.Show();
                materialLabelAvaliableVotings.Show();
            }

            materialCheckBoxCreateBlocks.Checked = VotingsUser.CreateOwnBlocks;
            materialCheckBoxPeerDiscovery.Checked = VotingsUser.PeerDiscovery;
            textBoxTrackers.Text = VotingsUser.Trackers;
            textBoxTrackers.Select(0, 0);


            //============


            //обработчики событий изменения БД
            blockChain.NewBlock += (s, a) =>
            {
                Invoke(new Action(() =>
                {
                    materialLabelBlocksVal.Text = a.Data.ToString();
                }));
            };

            blockChain.NewTransaction += (s, a) =>
            {
                //обновляем имя и количество транзакций
                materialLabelTransactionsVal.Text = a.Data.ToString();


                string name2 = null;
                if (helloStatus == false)
                {
                    name2 = blockChain.GetMyName();

                    if (name2!=null)
                        Invoke(new Action(() =>
                        {

                            if (helloStatus == false)
                            {
                                materialLabelHello.Text = Properties.Resources.hello + ", " + name2;
                                helloStatus = true;
                            }
                        }));
                }


            };

            blockChain.NewUser += (s, a) =>
            {
                Invoke(new Action(() =>
                {
                    materialLabelUsersVal.Text = a.Data.ToString();
                }));

            };

            blockChain.NewVoting += (s, a) =>
            {

                Invoke(new Action(() =>
                {
                    materialLabelAvaliableVotings.Text = Properties.Resources.avaliableN + " " + blockChain.GetOpenedVotings().Count
                + " " + Properties.Resources.nVotings;

                    materialLabelVotingsVal.Text = blockChain.GetVotings().Count.ToString();

                    var notify = new NotifyForm(blockChain.GetVotingName(a.Data));
                    notify.ButtonPressed += (s2, a2) => notifyIcon1_Click(s2, a2);
                    notify.Show();
                }));

            };

            CommonHelpers.PeersCountChanged += (s, a) =>
            {
                Invoke(new Action(() =>
                {
                    materialLabelPeersVal.Text = a.Data.ToString();
                }));
            };

            CommonHelpers.TrackersCountChanged += (s, a) =>
            {
                Invoke(new Action(() =>
                {
                    materialLabelTrackersVal.Text = a.Data.ToString();
                }));
            };


            //Задаем начальные значения
            materialLabelBlocksVal.Text = blockChain.GetBlocksCount().ToString();
            materialLabelTransactionsVal.Text = blockChain.GetTransactionsCount().ToString();
            materialLabelUsersVal.Text = blockChain.GetUsersCount().ToString();
            materialLabelAvaliableVotings.Text = Properties.Resources.avaliableN + " " + blockChain.GetOpenedVotings().Count
                + " " + Properties.Resources.nVotings;
            materialLabelPeersVal.Text = 0.ToString();
            materialLabelTrackersVal.Text = 0.ToString();
            materialLabelVotingsVal.Text = blockChain.GetVotings().Count.ToString();

            string name = blockChain.GetMyName();

            if (name != null)
            {
                materialLabelHello.Text = Properties.Resources.hello + ", " + name;
                helloStatus = true;
            }
            else
                materialLabelHello.Text = Properties.Resources.hello + ", " + Properties.Resources.user;



            ChangeLabelsFont();


            Task.Run(() => blockChain.Start());
            buttonStart.Enabled = false;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            Task.Run(() =>
            {
                blockChain.Stop();
                Thread.Sleep(CommonHelpers.MessagesInterval);
                Application.Exit();
            });

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


            ChangeLabelsFont();
        }

        private void materialLabelAbout_VisibleChanged(object sender, EventArgs e)
        {
            ChangeLabelsFont();
        }


        void ChangeLabelsFont()
        {
            materialLabelAbout.Font = new Font("Arial", 8);
            materialLabelAbout.ForeColor = Color.Gray;

            materialLabelStatistics.Font = new Font("Arial", 10, FontStyle.Bold);
            materialLabelHello.Font = new Font("Arial", 10, FontStyle.Bold);
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

        private void materialCheckBoxPeerDiscovery_CheckedChanged(object sender, EventArgs e)
        {
            VotingsUser.PeerDiscovery = materialCheckBoxPeerDiscovery.Checked;
            VotingsUser.ChangeSetting("peerDiscovery", materialCheckBoxPeerDiscovery.Checked.ToString());
        }

    }
}

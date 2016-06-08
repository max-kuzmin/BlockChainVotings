using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text;
using NetworkCommsDotNet;
using System.Threading.Tasks;
using Android.Graphics;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BlockChainVotingsAndroid
{
    [Activity(/*Label = "BlockChainVotingsAndroid",*/ MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        //public BlockChainServiceBinder ServiceBinder;
        ConsoleToTextViewWriter writer = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetTitle(Resource.String.blockChainVoting);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            //SetTheme(Android.Resource.Style.ThemeHoloLight);

            writer = new ConsoleToTextViewWriter(RunOnUiThread);
            Console.SetOut(writer);

            StartService(new Intent(this, typeof(BlockChainService)));
            //BindService(new Intent(this, typeof(BlockChainService)), new BlockChainServiceConnection(this), Bind.Important);


            if (VotingsUser.PrivateKey != null && VotingsUser.PublicKey != null)
            {
                CreateVotingSettingStatisticTabs();
            }
            else
            {
                CreateRegisterLoginTabs();
            }

        }

        private void CreateRegisterLoginTabs()
        {
            ActionBar.RemoveAllTabs();

            var tabReg = ActionBar.NewTab();
            tabReg.SetText(Resource.String.register);
            tabReg.TabSelected += TabReg_TabSelected;

            var tabLogin = ActionBar.NewTab();
            tabLogin.SetText(Resource.String.login);

            if (VotingsUser.CheckUserExists())
            {
                VotingsUser.GetKeysFromConfig();
                tabLogin.TabSelected += TabLogin_TabSelected;

                ActionBar.AddTab(tabLogin);
                ActionBar.AddTab(tabReg);
                tabLogin.Select();
            }
            else
            {
                tabLogin.TabSelected += (s, e) => { };

                ActionBar.AddTab(tabReg);
                ActionBar.AddTab(tabLogin);
                tabReg.Select();
            }

        }

        private void TabLogin_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Login);

            Button buttonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            buttonLogin.Click += ButtonLogin_Click;

            EditText editTextPublicKey = FindViewById<EditText>(Resource.Id.editTextPublicKeyLogin);
            editTextPublicKey.Text = VotingsUser.PublicKey;
            editTextPublicKey.Enabled = false;
        }

        private void TabReg_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Register);

            Button buttonReg = FindViewById<Button>(Resource.Id.buttonReg);
            buttonReg.Click += ButtonReg_Click;
        }

        private void CreateVotingSettingStatisticTabs()
        {

            InitBlockChain();


            ActionBar.RemoveAllTabs();

            var tabVoting = ActionBar.NewTab();
            tabVoting.SetText(Resource.String.voting);
            tabVoting.TabSelected += TabVoting_TabSelected;

            var tabStatistics = ActionBar.NewTab();
            tabStatistics.SetText(Resource.String.statistics);
            tabStatistics.TabSelected += TabStatistics_TabSelected;

            var tabSetting = ActionBar.NewTab();
            tabSetting.SetText(Resource.String.setting);
            tabSetting.TabSelected += TabSetting_TabSelected;

            tabVoting.Select();
            ActionBar.AddTab(tabVoting);
            ActionBar.AddTab(tabStatistics);
            ActionBar.AddTab(tabSetting);

        }

        private void InitBlockChain()
        {
            if (BlockChainService.BlockChain == null)
            {
                BlockChainService.BlockChain = new BlockChainVotings();

                BlockChainService.BlockChain.CheckRoot();

                Task.Run(() =>
                {
                    BlockChainService.BlockChain.Start();
                });

                BlockChainService.BlockChain.NewVoting += (s, a) =>
                {
                    RunOnUiThread(() =>
                    {
                        var notificationManager = GetSystemService(NotificationService) as NotificationManager;
                        PendingIntent contentIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);

                        var builder = new Notification.Builder(this);
                        builder.SetAutoCancel(true);
                        builder.SetContentTitle(Resources.GetString(Resource.String.newVoting));
                        builder.SetContentText(BlockChainService.BlockChain.GetVotingName(a.Data));
                        builder.SetSmallIcon(Resource.Drawable.Icon);
                        builder.SetContentIntent(contentIntent);
                        var notification = builder.Build();

                        notificationManager.Notify(1, notification);
                    });
                };
            }
        }

        private void TabStatistics_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Statistics);

            TextView textViewTransactions = FindViewById<TextView>(Resource.Id.textViewTransactions);
            TextView textViewBlocks = FindViewById<TextView>(Resource.Id.textViewBlocks);
            TextView textViewUsers = FindViewById<TextView>(Resource.Id.textViewUsers);
            TextView textViewVotings = FindViewById<TextView>(Resource.Id.textViewVotings);
            TextView textViewPeers = FindViewById<TextView>(Resource.Id.textViewPeers);
            TextView textViewTrackers = FindViewById<TextView>(Resource.Id.textViewTrackers);


            BlockChainService.BlockChain.NewTransaction += (s, a) =>
            {
                RunOnUiThread(() =>
                {
                    textViewTransactions.Text = a.Data.ToString();
                });
            };

            BlockChainService.BlockChain.NewBlock += (s, a) =>
            {
                RunOnUiThread(() =>
                {
                    textViewBlocks.Text = a.Data.ToString();
                });
            };

            BlockChainService.BlockChain.NewUser += (s, a) =>
            {
                RunOnUiThread(() =>
                {
                    textViewUsers.Text = a.Data.ToString();
                });
            };

            BlockChainService.BlockChain.NewVoting += (s, a) =>
            {
                RunOnUiThread(() =>
                {
                    textViewVotings.Text = BlockChainService.BlockChain.GetVotings().Count.ToString();
                });
            };

            CommonHelpers.PeersCountChanged += (s, a) =>
            {
                RunOnUiThread(() =>
                {
                    textViewPeers.Text = a.Data.ToString();
                });
            };

            CommonHelpers.TrackersCountChanged += (s, a) =>
            {
                RunOnUiThread(() =>
                {
                    textViewTrackers.Text = a.Data.ToString();
                });
            };


            textViewTransactions.Text = BlockChainService.BlockChain.GetTransactionsCount().ToString();
            textViewBlocks.Text = BlockChainService.BlockChain.GetBlocksCount().ToString();
            textViewUsers.Text = BlockChainService.BlockChain.GetUsersCount().ToString();
            textViewVotings.Text = BlockChainService.BlockChain.GetVotings().Count.ToString();
            textViewPeers.Text = BlockChainService.BlockChain.PeersCount.ToString();
            textViewTrackers.Text = BlockChainService.BlockChain.TrackersCount.ToString();
        }

        private void TabSetting_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Setting);

            Button buttonStart = FindViewById<Button>(Resource.Id.buttonStart);
            Button buttonStop = FindViewById<Button>(Resource.Id.buttonStop);
            CheckBox checkBoxCreateBlocks = FindViewById<CheckBox>(Resource.Id.checkBoxCreateBlocks);
            CheckBox checkBoxDiscovery = FindViewById<CheckBox>(Resource.Id.checkBoxPeerDiscovery);
            CheckBox checkBoxLocalIP = FindViewById<CheckBox>(Resource.Id.checkBoxUseLanLocalIP);
            EditText editTextTrackers = FindViewById<EditText>(Resource.Id.editTextTrackers);

            buttonStart.Enabled = !(BlockChainService.BlockChain.Started);

            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
            checkBoxCreateBlocks.Click += CheckBoxCreateBlocks_Click;
            checkBoxDiscovery.Click += CheckBoxDiscovery_Click;
            checkBoxLocalIP.Click += CheckBoxLocalIP_Click;
            editTextTrackers.TextChanged += EditTextTrackers_TextChanged;

            checkBoxCreateBlocks.Checked = VotingsUser.CreateOwnBlocks;
            checkBoxDiscovery.Checked = VotingsUser.PeerDiscovery;
            checkBoxLocalIP.Checked = VotingsUser.UseLanLocalIP;
            editTextTrackers.Text = VotingsUser.Trackers;

            //обработка вывода лога в консоль
            TextView textViewConsole = FindViewById<TextView>(Resource.Id.textViewConsole);
            textViewConsole.Text = ConsoleToTextViewWriter.Text;
            writer.textView = textViewConsole;

        }

        private void CheckBoxLocalIP_Click(object sender, EventArgs e)
        {
            CheckBox checkBoxLocalIP = FindViewById<CheckBox>(Resource.Id.checkBoxUseLanLocalIP);

            VotingsUser.UseLanLocalIP = checkBoxLocalIP.Checked;
            VotingsUser.ChangeSetting("useLanLocalIP", checkBoxLocalIP.Checked.ToString());
        }

        private void CheckBoxDiscovery_Click(object sender, EventArgs e)
        {
            CheckBox checkBoxDiscovery = FindViewById<CheckBox>(Resource.Id.checkBoxPeerDiscovery);

            VotingsUser.PeerDiscovery = checkBoxDiscovery.Checked;
            VotingsUser.ChangeSetting("peerDiscovery", checkBoxDiscovery.Checked.ToString());
        }

        private void EditTextTrackers_TextChanged(object sender, EventArgs e)
        {
            EditText editTextTrackers = FindViewById<EditText>(Resource.Id.editTextTrackers);

            VotingsUser.Trackers = editTextTrackers.Text;
            VotingsUser.ChangeSetting("trackers", editTextTrackers.Text.ToString());
        }

        private void CheckBoxCreateBlocks_Click(object sender, EventArgs e)
        {
            CheckBox checkBoxCreateBlocks = FindViewById<CheckBox>(Resource.Id.checkBoxCreateBlocks);

            VotingsUser.CreateOwnBlocks = checkBoxCreateBlocks.Checked;
            VotingsUser.ChangeSetting("createOwnBlocks", checkBoxCreateBlocks.Checked.ToString());
        }

        private void TabVoting_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Voting);

            Button voteButton = FindViewById<Button>(Resource.Id.buttonVote);
            CheckBox agreeCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxAgree);
            voteButton.Enabled = false;
            agreeCheckBox.Enabled = false;


            //установка имени
            TextView textViewHello = FindViewById<TextView>(Resource.Id.textViewHello);
            string name = BlockChainService.BlockChain.GetMyName();
            if (name == null)
            {
                textViewHello.Text = Resources.GetString(Resource.String.hello) + ", " + Resources.GetString(Resource.String.user);
            }
            else
            {
                textViewHello.Text = Resources.GetString(Resource.String.hello) + ", " + name;
            }

            BlockChainService.BlockChain.NewTransaction += (s, ee) =>
             {
                 string name2 = BlockChainService.BlockChain.GetMyName();
                 if (name2 != null)
                 {
                     RunOnUiThread(() =>
                     {
                         textViewHello.Text = Resources.GetString(Resource.String.hello) + ", " + name2;
                     });
                 }
             };


            voteButton.Click += VoteButton_Click;

            //заполняем голосования
            Spinner votingsSpiner = FindViewById<Spinner>(Resource.Id.spinnerVoting);

            var transactions = BlockChainService.BlockChain.GetOpenedVotings();
            var list = new List<SpinerItem>();

            foreach (var item in transactions)
            {
                try
                {
                    var info = JObject.Parse(item.Info);
                    string line = "№" + item.VotingNumber + " " + info["name"] + " " + Resources.GetString(Resource.String.from) + " " + item.Date0.ToShortDateString();
                    list.Add(new SpinerItem(line, item));
                }
                catch { }
            }

            var arrayAdapter = new ArrayAdapter<SpinerItem>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, list);
            votingsSpiner.Adapter = arrayAdapter;

            votingsSpiner.ItemSelected += VotingsSpiner_ItemSelected;

        }

        private void VoteButton_Click(object sender, EventArgs e)
        {
            CheckBox agreeCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxAgree);
            if (agreeCheckBox.Checked)
            {
                Spinner candidatesSpiner = FindViewById<Spinner>(Resource.Id.spinnerCandidates);
                Spinner votingsSpiner = FindViewById<Spinner>(Resource.Id.spinnerVoting);

                var voting = (votingsSpiner.SelectedItem as SpinerItem).Value;
                var candidate = (candidatesSpiner.SelectedItem as SpinerItem).Value;

                Task.Run(() =>
                {
                    BlockChainService.BlockChain.CreateVote(candidate.RecieverHash, voting.Hash);
                });

                var toast = Toast.MakeText(this, Resource.String.voteComplete, ToastLength.Long);
                toast.SetGravity(GravityFlags.Center, 0, 0);
                toast.Show();

                CreateVotingSettingStatisticTabs();
            }
        }

        private void VotingsSpiner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            CheckBox agreeCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxAgree);
            agreeCheckBox.Checked = false;


            //заполняем кандидатов
            Spinner candidatesSpiner = FindViewById<Spinner>(Resource.Id.spinnerCandidates);
            Spinner votingsSpiner = FindViewById<Spinner>(Resource.Id.spinnerVoting);

            var voting = (votingsSpiner.Adapter.GetItem(e.Position) as SpinerItem).Value;
            var transactions = BlockChainService.BlockChain.GetCandidates(voting);
            var list = new List<SpinerItem>();

            //пустая строка
            if (transactions == null)
            {
                list.Add(new SpinerItem(Resources.GetString(Resource.String.noCandidates), null));
            }
            else
            {
                list.Add(new SpinerItem("-", null));
                foreach (var item in transactions)
                {
                    try
                    {
                        var info = JObject.Parse(item.Info);
                        string line = info["name"] + ", " + Resources.GetString(Resource.String.snils) + " " + info["id"];
                        list.Add(new SpinerItem(line, item));
                    }
                    catch { }
                }
            }

            var arrayAdapter = new ArrayAdapter<SpinerItem>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, list);
            candidatesSpiner.Adapter = arrayAdapter;

            candidatesSpiner.ItemSelected += CandidatesSpiner_ItemSelected;



        }

        private void CandidatesSpiner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            CheckBox agreeCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxAgree);
            Spinner candidatesSpiner = FindViewById<Spinner>(Resource.Id.spinnerCandidates);

            if ((candidatesSpiner.SelectedItem as SpinerItem).Value == null)
                agreeCheckBox.Enabled = false;
            else
                agreeCheckBox.Enabled = true;

            agreeCheckBox.Checked = false;

            Button voteButton = FindViewById<Button>(Resource.Id.buttonVote);
            voteButton.Enabled = true;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Button buttonStart = FindViewById<Button>(Resource.Id.buttonStart);

            Task.Run(() => BlockChainService.BlockChain.Stop());

            buttonStart.Enabled = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Button buttonStart = FindViewById<Button>(Resource.Id.buttonStart);

            Task.Run(() => BlockChainService.BlockChain.Start());

            buttonStart.Enabled = false;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            EditText editTextPass = FindViewById<EditText>(Resource.Id.editTextPassLogin);

            editTextPass.SetTextColor(Color.White);

            if (VotingsUser.Login(editTextPass.Text))
            {
                CreateVotingSettingStatisticTabs();
            }
            else
            {
                editTextPass.SetTextColor(Color.OrangeRed);
            }
        }

        private void ButtonReg_Click(object sender, EventArgs e)
        {
            EditText editTextPublicKey = FindViewById<EditText>(Resource.Id.editTextPublicKeyReg);
            EditText editTextPrivateKey = FindViewById<EditText>(Resource.Id.editTextPrivateKeyReg);
            EditText editTextPass1 = FindViewById<EditText>(Resource.Id.editTextPassReg);
            EditText editTextPass2 = FindViewById<EditText>(Resource.Id.editTextPass2Reg);


            editTextPass1.SetTextColor(Color.White);
            editTextPass2.SetTextColor(Color.White);
            editTextPublicKey.SetTextColor(Color.White);
            editTextPrivateKey.SetTextColor(Color.White);


            if (!CommonHelpers.CheckKeys(editTextPublicKey.Text, editTextPrivateKey.Text))
            {
                editTextPublicKey.SetTextColor(Color.OrangeRed);
                editTextPrivateKey.SetTextColor(Color.OrangeRed);
            }
            else if (editTextPass1.Text != editTextPass2.Text)
            {
                editTextPublicKey.SetTextColor(Color.OrangeRed);
                editTextPrivateKey.SetTextColor(Color.OrangeRed);
            }
            else
            {
                VotingsUser.ClearUserData();
                VotingsUser.Register(editTextPublicKey.Text, editTextPrivateKey.Text, editTextPass1.Text);
                VotingsUser.GetKeysFromConfig();

                if (VotingsUser.Login(editTextPass1.Text))
                {
                    CreateVotingSettingStatisticTabs();
                }
            }

        }
    }
}


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

namespace BlockChainVotingsAndroid
{
    [Activity(Label = "BlockChainVotingsAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        static BlockChainVotings blockChain = new BlockChainVotings();


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetTitle(Resource.String.blockChainVoting);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            CreateRegisterLoginTabs();

        }

        private void CreateRegisterLoginTabs()
        {
            ActionBar.RemoveAllTabs();

            var tabReg = ActionBar.NewTab();
            tabReg.SetText(Resource.String.register);
            tabReg.TabSelected += TabReg_TabSelected;

            var tabLogin = ActionBar.NewTab();
            tabLogin.SetText(Resource.String.login);
            tabLogin.TabSelected += TabLogin_TabSelected;

            tabReg.Select();
            ActionBar.AddTab(tabReg);
            ActionBar.AddTab(tabLogin);
        }

        private void TabLogin_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Login);

            Button buttonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            buttonLogin.Click += ButtonLogin_Click;


            if (VotingsUser.CheckUserExists())
            {
                VotingsUser.GetKeysFromConfig();
                EditText editTextPublicKey = FindViewById<EditText>(Resource.Id.editTextPublicKeyLogin);
                editTextPublicKey.Text = VotingsUser.PublicKey;
            }
        }

        private void TabReg_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Register);

            Button buttonReg = FindViewById<Button>(Resource.Id.buttonReg);
            buttonReg.Click += ButtonReg_Click;
        }

        private void CreateVotingSettingTabs()
        {
            ActionBar.RemoveAllTabs();
           
            //показ сообщения об ожидании================================================================
            //blockChain.CheckRoot();

            var tabVoting = ActionBar.NewTab();
            tabVoting.SetText(Resource.String.voting);
            tabVoting.TabSelected += TabVoting_TabSelected;

            var tabSetting = ActionBar.NewTab();
            tabSetting.SetText(Resource.String.login);
            tabSetting.TabSelected += TabSetting_TabSelected;

            tabVoting.Select();
            ActionBar.AddTab(tabVoting);
            ActionBar.AddTab(tabSetting);

        }

        private void TabSetting_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
            SetContentView(Resource.Layout.Setting);

            Button buttonStart = FindViewById<Button>(Resource.Id.buttonStart);
            Button buttonStop = FindViewById<Button>(Resource.Id.buttonStop);
            CheckBox checkBoxCreateBlocks = FindViewById<CheckBox>(Resource.Id.checkBoxCreateBlocks);
            EditText editTextTrackers = FindViewById<EditText>(Resource.Id.editTextTrackers);

            buttonStart.Enabled = false;

            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
            checkBoxCreateBlocks.Click += CheckBoxCreateBlocks_Click;
            editTextTrackers.Click += EditTextTrackers_Click;

            checkBoxCreateBlocks.Checked = VotingsUser.CreateOwnBlocks;
            editTextTrackers.Text = VotingsUser.Trackers;

            //вывод лога в консоль - не стоит вызывать каждый раз ====================================================
            TextView textViewConsole = FindViewById<TextView>(Resource.Id.textViewConsole);
            textViewConsole.Text = "";
            ConsoleToTextViewWriter writer = new ConsoleToTextViewWriter(textViewConsole, RunOnUiThread);
            Console.SetOut(writer);
        }

        private void EditTextTrackers_Click(object sender, EventArgs e)
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


        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Button buttonStart = FindViewById<Button>(Resource.Id.buttonStart);

            Task.Run(() => blockChain.Stop());

            buttonStart.Enabled = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Button buttonStart = FindViewById<Button>(Resource.Id.buttonStart);

            Task.Run(() => blockChain.Start());

            buttonStart.Enabled = false;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            EditText editTextPass = FindViewById<EditText>(Resource.Id.editTextPassLogin);

            editTextPass.SetTextColor(Color.White);

            if (VotingsUser.Login(editTextPass.Text))
            {
                CreateVotingSettingTabs();
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
                    CreateVotingSettingTabs();
                }
            }

        }
    }
}


using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChainVotings
{
    public partial class SendVoteForm : MaterialForm
    {

        BlockChainVotings blockchain;

        public SendVoteForm(BlockChainVotings blockchain)
        {
            this.blockchain = blockchain;
            InitializeComponent();

            MaterialSkinManager.Instance.AddFormToManage(this);


            this.Text = Properties.Resources.sendVote;
            labelCandidateInfo.Text = Properties.Resources.iVoteFor;
            labelChooseVoting.Text = Properties.Resources.chooseVoting;
            labelVotingInfo.Text = Properties.Resources.takePatrInVoting;
            checkBoxAgree.Text = Properties.Resources.agree;
            buttonVote.Text = Properties.Resources.vote;
            columnHeaderCandidateID.Text = Properties.Resources.userID;
            columnHeaderCandidateName.Text = Properties.Resources.userName;
            columnHeaderCandidateHash.Text = Properties.Resources.userHash;
            labelCandidate.Text = Properties.Resources.chooseCandidate;
        }

        private void SendVoteForm_Load(object sender, EventArgs e)
        {
            comboBoxVoting.Items.Clear();
            comboBoxVoting.Text = "";

            var list = blockchain.GetOpenedVotings();

            foreach (var item in list)
            {
                var info = JObject.Parse(item.Info);
                string line = item.VotingNumber + ". " + info["name"] + " (" + item.Date0.ToShortDateString() + ", hash: " + item.Hash + ")";

                comboBoxVoting.Items.Add(new ComboBoxItem(line, item));
            }

            buttonVote.Enabled = false;
        }

        private void comboBoxVoting_TextUpdate(object sender, EventArgs e)
        {
            listViewCandidates.Items.Clear();
            Transaction tr;

            if (comboBoxVoting.SelectedItem != null)
            {
                tr = ((comboBoxVoting.SelectedItem as ComboBoxItem).Value as Transaction);
                labelVotingName.Text = "№" + tr.VotingNumber + " " + JObject.Parse(tr.Info)["name"] + " (" + tr.Date0.ToShortDateString() + ")"; ;
            }
            else
            {
                labelVotingName.Text = "...";
                return;
            }


            var list = blockchain.GetCandidates(tr);

            if (list == null)
            {
                //MessageBox.Show("Для данного голосования загружены не все кандидаты.\nНеобходимо подождать синхронизации БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                labelCandidateName.Text = "Для голосования загружены не все кандидаты.Необходимо подождать синхронизации БД.";
                return;
            }
            else
            {
                foreach (var user in list)
                {
                    var jsonInfo = JObject.Parse(user.Info);

                    string[] str = new string[3];
                    str[2] = user.RecieverHash;
                    str[1] = jsonInfo["name"].Value<string>();
                    str[0] = jsonInfo["id"].Value<string>();

                    ListViewItem item = new ListViewItem(str);

                    listViewCandidates.Items.Add(item);
                }
            }
        }

        private void checkBoxAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (listViewCandidates.SelectedItems.Count == 1)
            {

                labelCandidateName.Text = listViewCandidates.SelectedItems[0].SubItems[1].Text+ " (ID ";
                labelCandidateName.Text += listViewCandidates.SelectedItems[0].SubItems[0].Text + ")";

            }

            if (checkBoxAgree.Checked && listViewCandidates.SelectedItems.Count == 1)
                buttonVote.Enabled = true;
            else
                buttonVote.Enabled = false;
        }

        private void listViewCandidates_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            checkBoxAgree_CheckedChanged(this, new EventArgs());
        }

        private void buttonVote_Click(object sender, EventArgs e)
        {
            var tr = ((comboBoxVoting.SelectedItem as ComboBoxItem).Value as Transaction);
            blockchain.CreateVote(listViewCandidates.SelectedItems[0].SubItems[2].Text, tr.Hash);

            comboBoxVoting.SelectedItem = null;
            checkBoxAgree.Checked = false;

            SendVoteForm_Load(this, new EventArgs());
        }
    }

}

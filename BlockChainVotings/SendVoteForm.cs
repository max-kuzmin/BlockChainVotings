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

            toolStripMenuItem1.Text = Properties.Resources.copyHash;
            toolStripMenuItem2.Text = Properties.Resources.copyHash;
        }

        private void SendVoteForm_Load(object sender, EventArgs e)
        {
            comboBoxVoting.Items.Clear();
            comboBoxVoting.Text = "";

            var list = blockchain.GetOpenedVotings();

            foreach (var item in list)
            {
                var info = JObject.Parse(item.Info);
                string line = "№" + item.VotingNumber + " " + info["name"] + " " + Properties.Resources.from + " " + item.Date0.ToShortDateString();

                comboBoxVoting.Items.Add(new ComboBoxItem(line, item));
            }

            buttonVote.Enabled = false;
        }

        private void comboBoxVoting_TextUpdate(object sender, EventArgs e)
        {
            listViewCandidates.Items.Clear();
            Transaction tr;

            labelVotingName.Text = "...";
            labelCandidateName.Text = "...";

            if (comboBoxVoting.SelectedItem != null)
            {
                tr = ((comboBoxVoting.SelectedItem as ComboBoxItem).Value as Transaction);
                labelVotingName.Text = "№" + tr.VotingNumber + " " + JObject.Parse(tr.Info)["name"] + "\n" + Properties.Resources.from + " " + tr.Date0.ToShortDateString() + ",\n" + tr.Hash;
            }
            else return;


            var list = blockchain.GetCandidates(tr);

            labelCandidateName.BackColor = Color.White;

            if (list == null)
            {
                labelCandidateName.Text = Properties.Resources.waitDB; 
                labelCandidateName.BackColor = Color.MistyRose;
                return;
            }
            else
            {
                foreach (var user in list)
                {
                    var jsonInfo = JObject.Parse(user.Info);

                    string[] str = new string[3];
                    str[0] = user.RecieverHash;
                    str[1] = jsonInfo["name"].Value<string>();
                    str[2] = jsonInfo["id"].Value<string>();

                    ListViewItem item = new ListViewItem(str);

                    listViewCandidates.Items.Add(item);
                }
            }
        }

        private void checkBoxAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (listViewCandidates.SelectedItems.Count == 1)
            {

                labelCandidateName.Text = listViewCandidates.SelectedItems[0].SubItems[1].Text + ",\n" + Properties.Resources.userID +" ";
                labelCandidateName.Text += listViewCandidates.SelectedItems[0].SubItems[2].Text + ",\n" + listViewCandidates.SelectedItems[0].SubItems[0].Text;

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

        private void SendVoteForm_Shown(object sender, EventArgs e)
        {
            labelCandidateInfo.Font = new Font("Arial", 12);
            labelVotingInfo.Font = new Font("Arial", 12); 
            labelVotingName.Font = new Font("Arial", 12, FontStyle.Bold);
            labelCandidateName.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (comboBoxVoting.SelectedItems.Count == 1)
            {
                Clipboard.SetText(((comboBoxVoting.SelectedItems[0] as ComboBoxItem).Value as Transaction).Hash);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listViewCandidates.SelectedItems.Count == 1)
            {
                Clipboard.SetText(listViewCandidates.SelectedItems[0].SubItems[0].Text);
            }
        }
    }

}

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
    public partial class VotingsStatisticForm : MaterialForm
    {
        BlockChainVotings blockChain;

        public VotingsStatisticForm(BlockChainVotings blockChain)
        {
            InitializeComponent();
            this.blockChain = blockChain;

            MaterialSkinManager.Instance.AddFormToManage(this);


            this.Text = Properties.Resources.votingsStatistics;
            labelChooseVoting.Text = Properties.Resources.chooseVoting;
            labelCandidates.Text = Properties.Resources.candidates;
            labelVotingInfo.Text = Properties.Resources.inVoting;
            labelCandidateInfo.Text = Properties.Resources.wons;
            columnHeaderHash.Text = Properties.Resources.userHash;
            columnHeaderName.Text = Properties.Resources.userName;
            columnHeaderID.Text = Properties.Resources.userID;
            columnHeaderVotes.Text = Properties.Resources.votesCount;
            materialLabelWithResult.Text = Properties.Resources.withResult;

            toolStripMenuItem1.Text = Properties.Resources.copyHash;
            toolStripMenuItem2.Text = Properties.Resources.copyHash;


            Icon = Properties.Resources.votingIcon;


        }



        private void comboBoxVoting_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewCandidates.Items.Clear();
            Transaction tr = null;
            Dictionary<Transaction, int> list = null;

            labelVotingName.Text = "...";
            labelCandidateName.Text = "...";
            materialLabelResult.Text = "...";

            labelCandidateName.BackColor = Color.White;

            if (comboBoxVoting.SelectedItem != null)
            {
                tr = ((comboBoxVoting.SelectedItem as ComboBoxItem).Value as Transaction);
                labelVotingName.Text = "№" + tr.VotingNumber + " " + JObject.Parse(tr.Info)["name"] + "\n" + Properties.Resources.from + " " + tr.Date0.ToShortDateString() + ",\n" + tr.Hash;
            }
            else return;


            int sum = 0;


            if (tr!=null)
                list = blockChain.GetCandidatesResults(tr);

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
                    var jsonInfo = JObject.Parse(user.Key.Info);

                    string[] str = new string[4];

                    str[0] = user.Key.RecieverHash;
                    str[1] = jsonInfo["name"].Value<string>();
                    str[2] = jsonInfo["id"].Value<string>();
                    str[3] = user.Value.ToString();


                    ListViewItem item = new ListViewItem(str);

                    listViewCandidates.Items.Add(item);

                    sum += user.Value;
                }

               
                string[] strSum = new string[4];

                strSum[3] = sum.ToString();
                strSum[2] = Properties.Resources.total;
                ListViewItem item2 = new ListViewItem(strSum);
                //item2.Font = new Font("Arial", 10, FontStyle.Bold);
                listViewCandidates.Items.Add(item2);

                
            }


            if (int.Parse(listViewCandidates.Items[0].SubItems[3].Text) > int.Parse(listViewCandidates.Items[1].SubItems[3].Text))
            {

                int persent = (int)(int.Parse(listViewCandidates.Items[0].SubItems[3].Text) / (double)sum * 100d);

                labelCandidateName.Text = listViewCandidates.Items[0].SubItems[1].Text + ",\n" + Properties.Resources.userID + " ";
                labelCandidateName.Text += listViewCandidates.Items[0].SubItems[2].Text + ",\n" + listViewCandidates.Items[0].SubItems[0].Text;

                materialLabelResult.Text = listViewCandidates.Items[0].SubItems[3].Text + " " + Properties.Resources.votes + ", " + persent + "%";
            }
            else
            {
                labelCandidateName.Text = "-";
                materialLabelResult.Text = "-";
            }
        }

        private void VotingsStatisticForm_Load(object sender, EventArgs e)
        {
            comboBoxVoting.Items.Clear();
            comboBoxVoting.Text = "";

            var list = blockChain.GetVotings();

            foreach (var item in list)
            {
                var info = JObject.Parse(item.Info);
                string line = "№" + item.VotingNumber + " " + info["name"] + " " + Properties.Resources.from + " " + item.Date0.ToShortDateString();

                comboBoxVoting.Items.Add(new ComboBoxItem(line, item));
            }
        }

        private void VotingsStatisticForm_Shown(object sender, EventArgs e)
        {
            labelCandidateInfo.Font = new Font("Arial", 12);
            labelVotingInfo.Font = new Font("Arial", 12);
            labelVotingName.Font = new Font("Arial", 12, FontStyle.Bold);
            labelCandidateName.Font = new Font("Arial", 12, FontStyle.Bold);
            materialLabelResult.Font = new Font("Arial", 12, FontStyle.Bold);
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

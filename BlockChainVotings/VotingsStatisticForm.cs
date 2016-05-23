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
            columnHeaderHash.Text = Properties.Resources.userID;
            columnHeaderName.Text = Properties.Resources.userName;
            columnHeaderID.Text = Properties.Resources.userHash;
            columnHeaderVotes.Text = Properties.Resources.votesCount;

        }

        private void ListViewCandidates_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void comboBoxVoting_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewCandidates.Items.Clear();
            Transaction tr;

            labelVotingName.Text = "...";
            labelCandidateName.Text = "...";

            if (comboBoxVoting.SelectedItem != null)
            {
                tr = ((comboBoxVoting.SelectedItem as ComboBoxItem).Value as Transaction);
                labelVotingName.Text = "№" + tr.VotingNumber + " " + JObject.Parse(tr.Info)["name"] + " (" + tr.Date0.ToShortDateString() + ")";
            }
            else return;


            var list = blockChain.GetCandidatesResults(tr);

            if (list == null)
            {
                //MessageBox.Show("Для данного голосования загружены не все кандидаты.\nНеобходимо подождать синхронизации БД.", 
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                labelCandidateName.Text = "Для голосования загружены не все кандидаты. Необходимо подождать синхронизации БД.";
                return;
            }
            else
            {
                int sum = 0;

                foreach (var user in list)
                {
                    var jsonInfo = JObject.Parse(user.Key.Info);

                    string[] str = new string[4];

                    str[3] = user.Value.ToString();
                    str[2] = user.Key.RecieverHash;
                    str[1] = jsonInfo["name"].Value<string>();
                    str[0] = jsonInfo["id"].Value<string>();

                    ListViewItem item = new ListViewItem(str);

                    listViewCandidates.Items.Add(item);

                    sum += user.Value;
                }

                if (list.First().Value > list.Skip(1).First().Value)
                {
                    labelCandidateName.Text = listViewCandidates.Items[0].SubItems[1].Text + " (ID ";
                    labelCandidateName.Text += listViewCandidates.Items[0].SubItems[0].Text + ")";
                }

                string[] strSum = new string[4];

                strSum[3] = sum.ToString();
                strSum[2] = "Всего";
                ListViewItem item2 = new ListViewItem(strSum);
                item2.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                listViewCandidates.Items.Add(item2);

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
                string line = item.VotingNumber + ". " + info["name"] + " (" + item.Date0.ToShortDateString() + ", hash: " + item.Hash + ")";

                comboBoxVoting.Items.Add(new ComboBoxItem(line, item));
            }
        }
    }
}

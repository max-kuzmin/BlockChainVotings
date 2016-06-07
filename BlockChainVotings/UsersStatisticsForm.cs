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
    public partial class UsersStatisticsForm : MaterialForm
    {
        BlockChainVotings blockChain;
        bool me;

        public UsersStatisticsForm(BlockChainVotings blockChain, bool me)
        {
            InitializeComponent();
            this.blockChain = blockChain;
            this.me = me;

            MaterialSkinManager.Instance.AddFormToManage(this);


            this.Text = Properties.Resources.usersStatistics;
            labelActivity.Text = Properties.Resources.lastActivity;
            labelDate.Text = Properties.Resources.regDate;
            labelHash.Text = Properties.Resources.userHash;
            labelId.Text = Properties.Resources.userID;
            labelName.Text = Properties.Resources.userName;
            labelNumVotes.Text = Properties.Resources.votingsCount;
            labelSearchUsers.Text = Properties.Resources.searchUser;
            labelStatus.Text = Properties.Resources.userStatus;
            labelUserInfo.Text = Properties.Resources.userInfo;
            labelUserVotings.Text = Properties.Resources.userVotings;
            materialLabelAsCandidate.Text = Properties.Resources.asCandidate;

            columnHeaderId.Text = Properties.Resources.userID;
            columnHeaderCandidateHash.Text = Properties.Resources.candidateHash;
            columnHeaderDate.Text = Properties.Resources.voteDate;
            columnHeaderVotingName.Text = Properties.Resources.votingName;
            columnHeaderVotingHash.Text = Properties.Resources.votingHash;
            columnHeaderCandidateName.Text = Properties.Resources.candidateName;
            columnHeaderHash.Text = Properties.Resources.userHash;
            columnHeaderName.Text = Properties.Resources.userName;



            toolStripMenuItemUser.Text = Properties.Resources.copyCandidate;
            toolStripMenuItem2.Text = Properties.Resources.copyHash;
            toolStripMenuItemVoting.Text = Properties.Resources.copyVoting;


            if (me)
            {
                textBoxSearchUsers.Text = VotingsUser.PublicKey;
                textBoxSearchUser_TextChanged(this, new EventArgs());
                listViewSearchUsers.Items[0].Selected = true;
                listViewSearchUsers_ItemSelectionChanged(this, new ListViewItemSelectionChangedEventArgs(listViewSearchUsers.Items[0], 0, true));
            }

            Icon = Properties.Resources.votingIcon;

        }

        private void textBoxSearchUser_TextChanged(object sender, EventArgs e)
        {
            listViewSearchUsers.Items.Clear();

            ClearUserInfo();

            if (textBoxSearchUsers.Text.Length >= 3)
            {
                var users = blockChain.SearchUsers(textBoxSearchUsers.Text);

                foreach (var user in users)
                {
                    var jsonInfo = JObject.Parse(user.Info);

                    string[] str = new string[3];
                    str[0] = user.RecieverHash;
                    str[1] = jsonInfo["name"].Value<string>();
                    str[2] = jsonInfo["id"].Value<string>();

                    ListViewItem item = new ListViewItem(str);

                    listViewSearchUsers.Items.Add(item);
                }
            }
        }

        private void listViewSearchUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ClearUserInfo();

            if (listViewSearchUsers.SelectedItems.Count != 0)
            {
                var userHash = listViewSearchUsers.SelectedItems[0].SubItems[0].Text;
                var votings = blockChain.GetUserVotesAndVotings(userHash);

                foreach (var voting in votings)
                {
                    var jsonInfoVoting = JObject.Parse(voting.Key.Info);

                    var candidate = blockChain.GetUserCreation(voting.Value.RecieverHash);
                    var jsonInfoCandidate = JObject.Parse(candidate.Info);

                    string[] str = new string[5];
                    str[0] = "№" + voting.Key.VotingNumber + " " + jsonInfoVoting["name"];
                    str[1] = voting.Key.Hash;
                    str[2] = jsonInfoCandidate["name"] + "" /*+ ","+ Properties.Resources.userID + " " + jsonInfoCandidate["id"]*/;
                    str[3] = candidate.RecieverHash;
                    str[4] = voting.Value.Date0.ToString();

                    ListViewItem item = new ListViewItem(str);

                    listViewVotings.Items.Add(item);
                }

                var user = blockChain.GetUserCreation(userHash);
                var ban = blockChain.GetUserBan(userHash);
                var lastVote = votings.OrderBy(tr => tr.Value.Date).LastOrDefault().Value;


                labelDateVal.Text = user.Date0.ToString();
                labelIdVal.Text = JObject.Parse(user.Info)["id"].Value<string>();
                labelNameVal.Text = JObject.Parse(user.Info)["name"].Value<string>();
                labelNumVotesVal.Text = votings.Count.ToString();
                labelHashVal.Text = userHash;
                labelActivityVal.Text = lastVote == null ? "-" : lastVote.Date0.ToString();
                materialLabelAsCandidateVal.Text = blockChain.GetUserAsCandiddateCount(userHash).ToString();

                if (ban == null)
                    labelStatusVal.Text = Properties.Resources.active;
                else
                    labelStatusVal.Text = Properties.Resources.banned + " " + ban.Date0.ToString() + ". " + Properties.Resources.reason + ": " + JObject.Parse(ban.Info)["cause"].Value<string>();
            }

        }

        private void ClearUserInfo()
        {
            listViewVotings.Items.Clear();

            labelDateVal.Text = "...";
            labelIdVal.Text = "...";
            labelNameVal.Text = "...";
            labelNumVotesVal.Text = "...";
            labelHashVal.Text = "...";
            labelActivityVal.Text = "...";
            labelStatusVal.Text = "...";
            materialLabelAsCandidateVal.Text = "...";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listViewSearchUsers.SelectedItems.Count == 1)
            {
                Clipboard.SetText(listViewSearchUsers.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewVotings.SelectedItems.Count == 1)
            {
                Clipboard.SetText(listViewVotings.SelectedItems[0].SubItems[3].Text);
            }
        }

        private void UsersStatisticsForm_Shown(object sender, EventArgs e)
        {
            labelUserInfo.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void toolStripMenuItemVoting_Click(object sender, EventArgs e)
        {
            if (listViewVotings.SelectedItems.Count == 1)
            {
                Clipboard.SetText(listViewVotings.SelectedItems[0].SubItems[1].Text);
            }
        }
    }
}

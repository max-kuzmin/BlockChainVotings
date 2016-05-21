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
    public partial class CreateVotingForm : Form
    {
        BlockChainVotings blockChain;

        public CreateVotingForm(BlockChainVotings blockChain)
        {
            InitializeComponent();
            this.blockChain = blockChain;
        }

        private void textBoxVotingName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxVotingName.Text.Length >= 3 && textBoxVotingName.Text.Length <= 50)
            {
                textBoxVotingName.BackColor = Color.Honeydew;
            }
            else
            {
                textBoxVotingName.BackColor = Color.MistyRose;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBoxVotingName.BackColor == Color.Honeydew &&
                listViewCandidates.Items.Count>=2)
            {
                var candidates = new List<string>();


                foreach (ListViewItem item in listViewCandidates.Items)
                {
                    candidates.Add(item.SubItems[0].Text);
                }


                blockChain.CreateVoting(candidates, textBoxVotingName.Text);

                textBoxVotingName.Text = "";
                textBoxSearchUser.Text = "";
            }

            //if (listViewCandidates.Items.Count < 2)
            //{
            //    MessageBox.Show("Must be at least 2 candidates in voting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private void textBoxSearchUser_TextChanged(object sender, EventArgs e)
        {
            listViewSearchUsers.Items.Clear();

            if (textBoxSearchUser.Text.Length>=3)
            {
                var users = blockChain.SearchUsers(textBoxSearchUser.Text);

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

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewSearchUsers.SelectedItems)
            {
                bool contains = false;

                foreach (ListViewItem item2 in listViewCandidates.Items)
                {
                    if (item2.SubItems[0].Text == item.SubItems[0].Text)
                        contains = true;
                }

                if (!contains)
                    listViewCandidates.Items.Add((ListViewItem)item.Clone());
            }

            CheckCandidatesList();
        }

        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCandidates.SelectedItems)
            {
                listViewCandidates.Items.Remove(item);
            }

            CheckCandidatesList();
        }



        void CheckCandidatesList()
        {
            if (listViewCandidates.Items.Count < 2)
            {
                listViewCandidates.BackColor = Color.MistyRose;
            }
            else
            {
                listViewCandidates.BackColor = Color.Honeydew;
            }
        }

        private void CreateVotingForm_Load(object sender, EventArgs e)
        {
            CheckCandidatesList();
        }
    }
}

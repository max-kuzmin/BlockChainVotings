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
    public partial class BanUserForm : MaterialForm
    {
        BlockChainVotings blockChain;

        public BanUserForm(BlockChainVotings blockChain)
        {
            InitializeComponent();
            this.blockChain = blockChain;
            buttonBan.Enabled = false;

            MaterialSkinManager.Instance.AddFormToManage(this);

        }

        private void textBoxSearchUser_TextChanged(object sender, EventArgs e)
        {
            listViewSearchUsers.Items.Clear();

            if (textBoxSearchUser.Text.Length >= 3)
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

        private void buttonBan_Click(object sender, EventArgs e)
        {
            if (listViewSearchUsers.SelectedItems.Count  == 1 && textBoxCause.BackColor == Color.Honeydew)
            {
                blockChain.BanUser(listViewSearchUsers.SelectedItems[0].SubItems[0].Text, textBoxCause.Text);
                textBoxCause.Text = "";
            }
        }

        private void textBoxCause_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCause.Text.Length >= 3 && textBoxCause.Text.Length <= 50)
            {
                textBoxCause.BackColor = Color.Honeydew;
            }
            else
            {
                textBoxCause.BackColor = Color.MistyRose;
            }
        }

        private void listViewSearchUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewSearchUsers.SelectedItems.Count == 1)
                buttonBan.Enabled = true;
            else
                buttonBan.Enabled = false;
        }
    }
}

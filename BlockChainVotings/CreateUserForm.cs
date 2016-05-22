using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class CreateUserForm : MaterialForm
    {
        BlockChainVotings blockChain;

        public CreateUserForm(BlockChainVotings blockChain)
        {
            InitializeComponent();
            this.blockChain = blockChain;

            MaterialSkinManager.Instance.AddFormToManage(this);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var keys = CommonHelpers.GetPublicPrivateKeys();
            textBoxPublicKey.Text = keys[0];
            textBoxPrivateKey.Text = keys[1];
        }

        private void textBoxPublicKey_TextChanged(object sender, EventArgs e)
        {
            if (CommonHelpers.CheckKeys(textBoxPublicKey.Text, textBoxPrivateKey.Text))
            {
                textBoxPrivateKey.BackColor = Color.Honeydew;
                textBoxPublicKey.BackColor = Color.Honeydew;
            }
            else
            {
                textBoxPrivateKey.BackColor = Color.MistyRose;
                textBoxPublicKey.BackColor = Color.MistyRose;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length<3 || textBoxName.Text.Length>50)
                textBoxName.BackColor = Color.MistyRose;
            else
                textBoxName.BackColor = Color.Honeydew;
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            long id;
            if (textBoxID.Text.Length < 3 || textBoxID.Text.Length > 15
                || !long.TryParse(textBoxID.Text, out id))
                textBoxID.BackColor = Color.MistyRose;
            else
                textBoxID.BackColor = Color.Honeydew;
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            if (textBoxID.BackColor == Color.Honeydew &&
                textBoxName.BackColor == Color.Honeydew &&
                textBoxPrivateKey.BackColor == Color.Honeydew &&
                textBoxPublicKey.BackColor == Color.Honeydew)
            {
                blockChain.CreateUser(textBoxPublicKey.Text, textBoxName.Text, textBoxID.Text);

                textBoxPublicKey.Text = "";
                textBoxName.Text = "";
                textBoxPrivateKey.Text = "";
                textBoxID.Text = "";
            }
        }


    }
}

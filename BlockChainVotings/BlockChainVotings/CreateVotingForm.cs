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
            if (textBoxVotingName.BackColor == Color.Honeydew)
            {
                blockChain.CreateVoting(new List<string>(), textBoxVotingName.Name);
            }
        }
    }
}

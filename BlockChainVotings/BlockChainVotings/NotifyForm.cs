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
    public partial class NotifyForm : MaterialSkin.Controls.MaterialForm
    {
        public event EventHandler ButtonPressed;

        public NotifyForm(string votingInfo)
        {
            InitializeComponent();

            ShowInTaskbar = false;

            this.Text = Properties.Resources.avaliableNewVoting;
            materialRaisedButtonShow.Text = Properties.Resources.show;

            labelNewVoting.Text = votingInfo;

            Icon = Properties.Resources.votingIcon;
        }

        Timer t;
        private void NotifyForm_Shown(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 10000;
            t.Tick += (s, a) => Close();
            t.Start();

            labelNewVoting.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void NotifyForm_Load(object sender, EventArgs e)
        {
            SetDesktopLocation(Screen.PrimaryScreen.WorkingArea.Right - Size.Width, Screen.PrimaryScreen.WorkingArea.Bottom - Size.Height);
        }

        private void materialRaisedButtonShow_Click(object sender, EventArgs e)
        {
            if (ButtonPressed!=null)
            {
                ButtonPressed(this, new EventArgs());
                Close();
            }
        }
    }
}

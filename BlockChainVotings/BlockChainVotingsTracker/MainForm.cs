using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChainVotingsTracker
{
    public partial class MainForm : Form
    {

        Tracker tracker;

        public MainForm()
        {
            InitializeComponent();

            ConsoleToTextBoxWriter writer = new ConsoleToTextBoxWriter(textBoxConsole);
            Console.SetOut(writer);

            tracker = new Tracker();


            if (Tracker.GetLocalEndPoint() == null)
            {
                MessageBox.Show("Для продолжения необходимо подключение к интернету");
            }

        }
        

        private void buttonStopTracker_Click(object sender, EventArgs e)
        {
            tracker.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tracker.Stop();
        }

        private void buttonStartTracker_Click(object sender, EventArgs e)
        {
            tracker.Start();
        }
    }

}

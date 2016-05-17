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
        }
        
        private void buttonStopTracker_Click(object sender, EventArgs e)
        {
            Task.Run(() => tracker.Stop());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Run(() => tracker.Stop());
        }

        private void buttonStartTracker_Click(object sender, EventArgs e)
        {
            Task.Run(() => tracker.Start());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConsoleToTextBoxWriter writer = new ConsoleToTextBoxWriter(textBoxConsole);
            Console.SetOut(writer);

            tracker = new Tracker();
        }
    }

}

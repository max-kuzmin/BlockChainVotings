using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Virgil.Crypto;
using Virgil.Crypto.Foundation;
using System.Net;

namespace BlockChainVotings
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            


            ////подписать-проверить файл
            //VirgilKeyPair pair = CryptoHelper.GenerateKeyPair();
            //string sign = CryptoHelper.Sign("hello world", pair.PrivateKey());
            //bool res = CryptoHelper.Verify("hello world", sign, pair.PublicKey());
            //MessageBox.Show(Convert.ToBase64String(pair.PublicKey()) + "\n\n\n" + Convert.ToBase64String(pair.PrivateKey()) + "\n\n\n" + sign + "\n\n\n" + res.ToString());
        }

        ////хеш
        //public string CalcSHA256(byte[] data)
        //{
        //    byte[] result = VirgilHash.Sha256().Hash(data);
        //    return Convert.ToBase64String(result);
        //}

    }
}

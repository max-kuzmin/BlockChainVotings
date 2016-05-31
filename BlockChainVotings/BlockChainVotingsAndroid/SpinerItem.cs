using BlockChainVotingsAndroid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsAndroid
{
    public class SpinerItem: Java.Lang.Object
    {
        public string Text { get; set; }
        public Transaction Value { get; set; }

        public SpinerItem(string text, Transaction value)
        {
            this.Value = value;
            this.Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}

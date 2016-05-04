using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChainVotings
{
    public class ConsoleToTextBoxWriter : TextWriter
    {
        TextBox textBox = null;

        public ConsoleToTextBoxWriter(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public override void Write(char value)
        {
            base.Write(value);
            textBox.AppendText(value.ToString());
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}

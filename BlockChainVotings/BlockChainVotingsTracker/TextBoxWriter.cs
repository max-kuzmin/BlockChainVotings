using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChainVotingsTracker
{
    public class ConsoleToTextBoxWriter : TextWriter
    {
        TextBox textBox = null;

        public ConsoleToTextBoxWriter(TextBox textBox)
        {
            this.textBox = textBox;
        }

        string line = "";

        public override void Write(char value)
        {
            base.Write(value);

            line += value;

            if (value == '\n')
            {
                if (!line.Contains("Trace]"))
                    try
                    {
                        textBox.Invoke(new Action(() => textBox.AppendText(line)));
                    }
                    catch { }
                line = "";
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}

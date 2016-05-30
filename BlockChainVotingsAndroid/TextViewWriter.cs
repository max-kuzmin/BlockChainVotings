using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Android.App;

namespace BlockChainVotingsAndroid
{
    public class ConsoleToTextViewWriter : TextWriter
    {
        TextView textView = null;
        Action<Action> runOnUi;

        public ConsoleToTextViewWriter(TextView textView, Action<Action> runOnUiThread)
        {
            this.textView = textView;
            this.runOnUi = runOnUiThread;
        }


        string line = "";

        public override void Write(char value)
        {
            base.Write(value);

            runOnUi(new Action(() =>
            {
                line += value;

                if (value == '\n')
                {
                    if (!line.Contains("Trace]"))
                    {
                        try
                        {
                            textView.Text += line;
                        }
                        catch { }
                    }
                    line = "";
                }

            }));
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}

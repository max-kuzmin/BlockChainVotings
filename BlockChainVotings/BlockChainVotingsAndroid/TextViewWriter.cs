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

        public static string Text = "";
        string line = "";

        public override void Write(char value)
        {
            base.Write(value);

                line += value;

                if (value == '\n')
                {
                    if (!line.Contains("Trace]"))
                    {
                        Text += line;
                        try
                        {
                            runOnUi(new Action(() =>
                            {
                                textView.Text = Text;
                            }));
                        }
                        catch { }
                    }
                    line = "";
                }
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}

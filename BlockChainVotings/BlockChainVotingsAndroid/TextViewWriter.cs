using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Android.App;
using System.Timers;

namespace BlockChainVotingsAndroid
{
    public class ConsoleToTextViewWriter : TextWriter, IDisposable
    {
        public TextView textView = null;
        Action<Action> runOnUi;
        Timer t;

        public ConsoleToTextViewWriter(Action<Action> runOnUiThread)
        {
            this.runOnUi = runOnUiThread;

            t = new Timer();
            t.Elapsed += T_Elapsed;
            t.Interval = CommonHelpers.MessagesInterval;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (textView != null)
                try
                {
                    runOnUi(new Action(() =>
                    {
                        if (Text.Length > 10000)
                        {
                            Text = Text.Substring(Text.Length - 10000);
                            textView.Text = Text;
                        }
                        else
                        {
                            textView.Text = Text;
                        }
                    }));
                }
                catch { }
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
                }
                line = "";
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            t.Stop();
            t.Dispose();
        }
    }
}

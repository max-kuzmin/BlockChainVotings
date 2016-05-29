using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Virgil.Crypto;
using System.Text;
using NetworkCommsDotNet;

namespace BlockChainVotingsAndroid
{
    [Activity(Label = "BlockChainVotingsAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            //button.Click += (s, e) =>
            //{
            //    button.Text = Encoding.UTF8.GetString(CryptoHelper.GenerateKeyPair().PublicKey());
            //};

            button.Click += (s, e) =>
            {
                
                button.Text = NetworkComms.TotalNumConnections().ToString();
            };
        }
    }
}


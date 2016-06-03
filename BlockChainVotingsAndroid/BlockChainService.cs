using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BlockChainVotingsAndroid
{
    [Service]
    public class BlockChainService : Service
    {

        static public BlockChainVotings BlockChain = null;

        public override IBinder OnBind(Intent intent)
        {
            return new Binder();
        }

    }

}
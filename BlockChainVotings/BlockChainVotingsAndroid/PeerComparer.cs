using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsAndroid
{
    public class PeerComparer : IComparer<Peer>
    {
        public int Compare(Peer x, Peer y)
        {
            if (x.SendToOthersCount < y.SendToOthersCount) return -1;
            else if (x.SendToOthersCount > y.SendToOthersCount) return 1;
            else return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotingsTracker
{
    public class PeerComparer : IComparer<Peer>
    {
        public int Compare(Peer x, Peer y)
        {
            if (x.SendToOthersCount < y.SendToOthersCount) return -1;
            else if (x.SendToOthersCount > y.SendToOthersCount) return 1;
            else
            {
                if (x.ConnectedPeers.Count < y.ConnectedPeers.Count) return -1;
                else if (x.ConnectedPeers.Count > y.ConnectedPeers.Count) return 1;
                else return 0;
            }
        }
    }
}

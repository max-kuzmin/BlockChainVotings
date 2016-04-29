using System;
using System.Collections.Generic;

namespace BlockChainVotingsTracker
{
    public class RequestPeersEventArgs: EventArgs
    {
        public int Count { get; }
        public List<Peer> NotForSendingPeers { get; }

        public RequestPeersEventArgs(int count, List<Peer> notForSendingPeers)
        {
            this.Count = count;
            this.NotForSendingPeers = new List<Peer>(notForSendingPeers);
        }
    }
}
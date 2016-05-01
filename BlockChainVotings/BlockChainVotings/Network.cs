using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public class Network
    {
        //static public EndPoint LocalAddress;
        public List<Peer> Peers { get; }
        public List<Tracker> Trackers { get; }
    }
}

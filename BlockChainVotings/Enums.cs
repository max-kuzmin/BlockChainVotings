using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public enum PeerStatus
    {
        Disconnected,
        NoHashRecieved,
        Connected,
    }

    public enum ConnectionType
    {
        Direct,
        WithTracker
    }

    public enum MessageType
    {
        None,
        RequestPeers,
        Peers,
        RequestBlocks,
        Blocks,
        RequestTransactions,
        Transactions,
        ConnectToPeerWithTracker,
        MessageToPeer,
        PeerDisconnect,
        PeerHash
    }
}

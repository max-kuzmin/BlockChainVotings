using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{

    public enum TransactionStatus
    {
        Free,
        InBlock,
        InPendingBlock
    }


    public enum PeerStatus
    {
        Disconnected,
        NoHashRecieved,
        Connected,
    }

    public enum ConnectionMode
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

    public enum TrackerStatus
    {
        Disconnected,
        Connected
    }

    public enum TransactionType
    {
        None = 0,
        CreateUser,
        BanUser,
        Vote,
        StartVoting,
        ChangeRootUser
    }
}

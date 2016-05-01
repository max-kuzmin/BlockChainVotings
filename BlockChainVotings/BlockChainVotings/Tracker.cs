using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public class Tracker
    {
        
        public EndPoint Address { get; }
        public Connection Connection { get; set; }

        //события на приход сообщений для обработки в пире
        public event EventHandler<MessageEventArgs> OnDisconnectPeer;
        public event EventHandler<MessageEventArgs> OnPeerHashMessage;
        public event EventHandler<MessageEventArgs> OnRequestPeersMessage;

        public event EventHandler<MessageEventArgs> OnPeersMessageFromPeer; //получение пиров от пира через трекер
        public event EventHandler<MessageEventArgs> OnPeersMessageFromTracker; //получение пиров от трекера

        //события на приход сообщений для обработки вне
        public event EventHandler<MessageEventArgs> OnRequestBlocksMessage;
        public event EventHandler<MessageEventArgs> OnRequestTransactionsMessage;
        public event EventHandler<MessageEventArgs> OnBlocksMessage;
        public event EventHandler<MessageEventArgs> OnTransactionsMessage;

        public void SendMessageToPeer(Message message, Peer peer)
        {
            if (Connection != null)
            {
                var shellMessage = new ToPeerMessage(Connection.ConnectionInfo.LocalEndPoint, peer.Address, message);
                Connection.SendObject(message.Type.ToString(), shellMessage);
            }
        }

        public void ConnectPeerToPeer(Peer peerToConnect)
        {
            if (Connection != null)
            {
                var message = new ConnectToPeerWithTrackerMessage(Connection.ConnectionInfo.LocalEndPoint, peerToConnect.Address);
                Connection.SendObject(message.Type.ToString(), message);
            }
        }

    }

}

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
        public List<Peer> Peers { get; }
        public List<Tracker> Trackers { get; }

        public EndPoint Address { get; }
        public Connection Connection { get; set; }

        public event EventHandler<MessageRecievedEventArgs> OnMessageRecieved;

        public void SendMessageToPeer(Message message, Peer peer)
        {
            if (Connection != null && Connection.ConnectionAlive())
            {
                var shellMessage = new ToPeerMessage(Network.LocalAddress, peer.Address, message);
                Connection.SendObject(MessageType.MessageToPeer.ToString(), shellMessage);
            }
        }

        public void ConnectPeerToPeer(Peer peerToConnect)
        {
            if (Connection != null && Connection.ConnectionAlive())
            {
                var message = new ConnectToPeerWithTrackerMessage(Network.LocalAddress, peerToConnect.Address);
                Connection.SendObject(MessageType.ConnectToPeerWithTracker.ToString(), message);
            }
        }

    }

}

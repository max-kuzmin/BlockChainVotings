using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public class Tracker
    {

        public EndPoint Address { get; private set; }
        public Connection Connection { get; private set; }

        public int ErrorsCount { get; private set; }
        List<Tracker> allTrackers;


        public TrackerStatus Status { get; private set; }
        public int PeersRequestsCount { get; private set; }

        //события на приход сообщений для обработки в пире
        public event EventHandler<MessageEventArgs> OnDisconnectPeer;
        public event EventHandler<MessageEventArgs> OnPeerHashMessage;
        public event EventHandler<MessageEventArgs> OnRequestPeersMessage;

        //получение пиров от пира через трекер
        public event EventHandler<MessageEventArgs> OnPeersMessageFromPeer;
        //получение пиров от трекера
        public event EventHandler<MessageEventArgs> OnPeersMessageFromTracker;
        //запрос на подключение через трекер
        public event EventHandler<MessageEventArgs> OnConnectToPeerWithTrackerMessage;

        //события на приход сообщений для обработки вне
        public event EventHandler<MessageEventArgs> OnRequestBlocksMessage;
        public event EventHandler<MessageEventArgs> OnRequestTransactionsMessage;
        public event EventHandler<MessageEventArgs> OnBlocksMessage;
        public event EventHandler<MessageEventArgs> OnTransactionsMessage;

        //событие при ошибке трекера
        public event EventHandler OnTrackerDelete;


        public Tracker(EndPoint address, List<Tracker> allTrackers)
        {
            this.Address = address;
            this.Status = TrackerStatus.Disconnected;
            this.allTrackers = allTrackers;
        }

        public void SendMessageToPeer(Message message, Peer peer)
        {
            if (Status == TrackerStatus.Connected)
            {
                NetworkComms.Logger.Warn("Sent message of type " + message.Type.ToString());

                var shellMessage = new ToPeerMessage(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort), peer.Address, message);
                try {
                    Connection.SendObject(shellMessage.GetType().Name, shellMessage); }
                catch
                {
                    Status = TrackerStatus.Disconnected;
                    Connect();
                }
            }
            else Connect();
        }

        public void ConnectPeerToPeer(Peer peerToConnect)
        {
            if (Status == TrackerStatus.Connected)
            {
                var message = new ConnectToPeerWithTrackerMessage(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort), peerToConnect.Address);
                try
                {
                    Connection.SendObject(message.GetType().Name, message);
                }
                catch
                {
                    Status = TrackerStatus.Disconnected;
                    Connect();
                }
            }
            else Connect();
        }


        public void Connect()
        {
            if (Status == TrackerStatus.Disconnected)
            {
                try
                {
                    ConnectionInfo connInfo = new ConnectionInfo(Address);
                    Connection newTCPConn = TCPConnection.GetConnection(connInfo);

                    Status = TrackerStatus.Connected;
                    Connection = newTCPConn;

                    if (!Connection.IncomingPacketHandlerExists(typeof(ToPeerMessage).Name))
                        Connection.AppendIncomingPacketHandler<ToPeerMessage>(typeof(ToPeerMessage).Name, OnToPeerMessage);

                    if (!Connection.IncomingPacketHandlerExists(typeof(PeerHashMessage).Name))
                        Connection.AppendIncomingPacketHandler<PeerHashMessage>(typeof(PeerHashMessage).Name, OnPeerHashMessageFromTracker);

                    if (!Connection.IncomingPacketHandlerExists(typeof(PeersMessage).Name))
                        Connection.AppendIncomingPacketHandler<PeersMessage>(typeof(PeersMessage).Name,
                            (p, c, m) =>
                            {
                                OnPeersMessageFromTracker?.Invoke(this, new MessageEventArgs(m, null, Address));
                            });

                    if (!Connection.IncomingPacketHandlerExists(typeof(ConnectToPeerWithTrackerMessage).Name))
                        Connection.AppendIncomingPacketHandler<ConnectToPeerWithTrackerMessage>(typeof(ConnectToPeerWithTrackerMessage).Name,
                            (p, c, m) =>
                            {
                                OnConnectToPeerWithTrackerMessage?.Invoke(this, new MessageEventArgs(m, null, Address));
                            });

                    if (!Connection.IncomingPacketHandlerExists(typeof(PeerDisconnectMessage).Name))
                        Connection.AppendIncomingPacketHandler<PeerDisconnectMessage>(typeof(PeerDisconnectMessage).Name,
                            (p, c, m) =>
                            {
                                OnDisconnectPeer?.Invoke(this, new MessageEventArgs(m, null, Address));
                            });

                    Thread.Sleep(CommonHelpers.MessagesInterval);

                }
                catch 
                {
                    ErrorsCount++;
                    Status = TrackerStatus.Disconnected;

                    if (ErrorsCount >= 3)
                    {
                        allTrackers.Remove(this);

                        OnTrackerDelete?.Invoke(this, new EventArgs());
                    }
                }


                CommonHelpers.LogTrackers(allTrackers);
            }
        }

        private void OnPeerHashMessageFromTracker(PacketHeader packetHeader, Connection connection, PeerHashMessage incomingObject)
        {
            var messageToSend = new PeerHashMessage(VotingsUser.PublicKey, false);
            Connection.SendObject(messageToSend.GetType().Name, messageToSend);
        }



        private void OnToPeerMessage(PacketHeader packetHeader, Connection connection, ToPeerMessage incomingObject)
        {

            NetworkComms.Logger.Warn("Recieved message of type " + incomingObject.Message.Type.ToString());

            if (incomingObject.RecieverAddress.Equals(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort)))
            {
                var eventArgs = new MessageEventArgs(incomingObject.Message, null, incomingObject.SenderAddress);

                if (incomingObject.Message is PeerHashMessage)
                {
                    OnPeerHashMessage?.Invoke(this, eventArgs);
                }
                else if (incomingObject.Message is RequestPeersMessage)
                {
                    OnRequestPeersMessage?.Invoke(this, eventArgs);
                }
                else if (incomingObject.Message is PeersMessage)
                {
                    OnPeersMessageFromPeer?.Invoke(this, eventArgs);
                }
                else if (incomingObject.Message is RequestBlocksMessage)
                {
                    OnRequestBlocksMessage?.Invoke(this, eventArgs);
                }
                else if (incomingObject.Message is RequestTransactionsMessage)
                {
                    OnRequestTransactionsMessage?.Invoke(this, eventArgs);
                }
                else if (incomingObject.Message is BlocksMessage)
                {
                    OnBlocksMessage?.Invoke(this, eventArgs);
                }
                else if (incomingObject.Message is TransactionsMessage)
                {
                    OnTransactionsMessage?.Invoke(this, eventArgs);
                }              
            }
        }

        public void Disconnect()
        {
            allTrackers.Remove(this);

            if (Status == TrackerStatus.Connected)
            {

                var message = new PeerDisconnectMessage(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort));
                try {
                    Connection.SendObject(message.GetType().Name, message);
                }
                catch { }

            }

            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }

            Status = TrackerStatus.Disconnected;

            OnTrackerDelete?.Invoke(this, new EventArgs());

            CommonHelpers.LogTrackers(allTrackers);
        }


        public void RequestPeersFromTracker(int count)
        {
            if (Status == TrackerStatus.Connected)
            {
                var message = new RequestPeersMessage(count);
                try
                { 
                    Connection.SendObject(message.GetType().Name, message);
                }
                catch
                {
                    Status = TrackerStatus.Disconnected;
                    Connect();
                }
            }
            else Connect();
        }
    }

}

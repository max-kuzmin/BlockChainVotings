using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
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


        public Tracker(EndPoint address, List<Tracker> allTrackers)
        {
            this.Address = address;
            this.Status = TrackerStatus.Disconnected;
            this.allTrackers = allTrackers;


            //Connect();
        }

        public void SendMessageToPeer(Message message, Peer peer)
        {
            if (Connection != null && Status == TrackerStatus.Connected)
            {
                var shellMessage = new ToPeerMessage(Connection.ConnectionInfo.LocalEndPoint, peer.Address, message);
                Connection.SendObject(message.GetType().Name, shellMessage);
            }
            else Connect();
        }

        public void ConnectPeerToPeer(Peer peerToConnect)
        {
            if (Connection != null && Status == TrackerStatus.Connected)
            {
                var message = new ConnectToPeerWithTrackerMessage(Connection.ConnectionInfo.LocalEndPoint, peerToConnect.Address);
                Connection.SendObject(message.GetType().Name, message);
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
                    //newTCPConn.EstablishConnection();
                    Status = TrackerStatus.Connected;
                    Connection = newTCPConn;


                    Connection.AppendIncomingPacketHandler<ToPeerMessage>(typeof(ToPeerMessage).Name, OnToPeerMessage);

                    Connection.AppendIncomingPacketHandler<PeersMessage>(typeof(PeersMessage).Name,
                        (p, c, m) => OnPeersMessageFromTracker(this, new MessageEventArgs(m, null, Address)));
                }
                catch (CommsException ex)
                {
                    ErrorsCount++;
                    Status = TrackerStatus.Disconnected;

                    if (ErrorsCount >= 3)
                    {
                        allTrackers.Remove(this);
                    }
                }
            }
        }

        private void OnToPeerMessage(PacketHeader packetHeader, Connection connection, ToPeerMessage incomingObject)
        {
            if (incomingObject.RecieverAddress == Connection.ConnectionInfo.LocalEndPoint)
            {
                var eventArgs = new MessageEventArgs(incomingObject.Message, null, incomingObject.SenderAddress);

                //при получении сообщения для пира, ивлекаем его из обертки и вызываем соотвествующее событие
                if (incomingObject.Message is PeerDisconnectMessage)
                {
                    OnDisconnectPeer(this, eventArgs);
                }
                else if (incomingObject.Message is PeerHashMessage)
                {
                    OnPeerHashMessage(this, eventArgs);
                }
                else if (incomingObject.Message is RequestPeersMessage)
                {
                    OnRequestPeersMessage(this, eventArgs);
                }
                else if (incomingObject.Message is PeersMessage)
                {
                    OnPeersMessageFromPeer(this, eventArgs);
                }
                else if (incomingObject.Message is RequestBlocksMessage)
                {
                    OnRequestBlocksMessage(this, eventArgs);
                }
                else if (incomingObject.Message is RequestTransactionsMessage)
                {
                    OnRequestTransactionsMessage(this, eventArgs);
                }
                else if (incomingObject.Message is BlocksMessage)
                {
                    OnBlocksMessage(this, eventArgs);
                }
                else if (incomingObject.Message is TransactionsMessage)
                {
                    OnTransactionsMessage(this, eventArgs);
                }
                else if (incomingObject.Message is ConnectToPeerWithTrackerMessage)
                {
                    OnConnectToPeerWithTrackerMessage(this, eventArgs);
                }
            }
        }

        public void Disconnect()
        {
            if (Status == TrackerStatus.Connected)
            {

                var message = new PeerDisconnectMessage(Connection.ConnectionInfo.LocalEndPoint);
                Connection.SendObject(message.GetType().Name, message);

                if (Connection != null) Connection.Dispose();
                Status = TrackerStatus.Disconnected;
                Connection = null;
            }
        }


        public void RequestPeersFromTracker(int count)
        {
            if (Status == TrackerStatus.Connected && Connection != null)
            {
                var message = new RequestPeersMessage(count);
                Connection.SendObject(message.GetType().Name, message);
            }
            else Connect();
        }
    }

}

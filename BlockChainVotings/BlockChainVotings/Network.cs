using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet.Connections;
using System.Timers;
using NetworkCommsDotNet;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace BlockChainVotings
{
    public class Network
    {
        public List<Peer> Peers { get; }
        public List<Tracker> Trackers { get; }
        static public int Port { get { return 10101; } }

        int normalPeersCount = 10;

        Timer t;

        public event EventHandler<MessageEventArgs> OnRequestBlocksMessage;
        public event EventHandler<MessageEventArgs> OnRequestTransactionsMessage;
        public event EventHandler<MessageEventArgs> OnBlocksMessage;
        public event EventHandler<MessageEventArgs> OnTransactionsMessage;



        public Network(string[] trackers)
        {

            Trackers = new List<Tracker>();
            Peers = new List<Peer>();

            SetupLogging();

            FillTrackers(trackers);


            t = new Timer(10000);
            t.Elapsed += (s, e) => RequestPeers();
            t.Elapsed += (s, e) => ConnectToPeers();
            t.Elapsed += (s, e) => ConnectToTrackers();

            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnectPeerDirect);

        }




        private void OnConnectPeerDirect(Connection connection)
        {
            if (connection.ConnectionInfo.ServerSide)
            {
                var peer = new Peer(connection, Peers);
                Peers.Add(peer);
            }
        }


        void FillTrackers(string[] addresses)
        {
            foreach (var line in addresses)
            {
                var parts = line.Split(':');

                IPAddress addr = new IPAddress(0);
                /*int port = 0;*/
                if (parts.Length >= 1 && IPAddress.TryParse(parts[0], out addr) /*&& int.TryParse(parts[1], out port)*/)
                {
                    EndPoint endPoint = new IPEndPoint(addr, Port);

                    Tracker tracker = new Tracker(endPoint, Trackers);

                    //перенаправляем события трекера вне
                    tracker.OnRequestBlocksMessage += (s, e) => OnRequestBlocksMessage(s, e);
                    tracker.OnRequestTransactionsMessage += (s, e) => OnRequestTransactionsMessage(s, e);
                    tracker.OnBlocksMessage += (s, e) => OnBlocksMessage(s, e);
                    tracker.OnRequestTransactionsMessage += (s, e) => OnRequestTransactionsMessage(s, e);

                    //получение пиров
                    tracker.OnPeersMessageFromPeer += OnPeersMessage;
                    tracker.OnPeersMessageFromTracker += OnPeersMessage;

                    //коннект через трекер
                    tracker.OnConnectToPeerWithTrackerMessage += OnConnectToPeerWithTrackerMessage;

                    Trackers.Add(tracker);


                }
            }

        }

        private void OnConnectToPeerWithTrackerMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as ConnectToPeerWithTrackerMessage;

            var peerToConnect = Peers.First(peer => peer.Address == message.SenderAddress);
            //если пира нет в списке, то добавляем его и подключаемся прямо через трекер
            if (peerToConnect == null)
            {
                AddPeer(message.SenderAddress, (sender as Tracker), true);
            }
            //если пир есть в списке, то просто подключаемся через трекер
            else if (peerToConnect.Status != PeerStatus.Connected)
            {
                peerToConnect.Connect(true);
            }
        }

        private void OnPeersMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message as PeersMessage;

            //добавляем пир и если сообщение пришло от трекера, то указываем трекер
            foreach (var address in message.PeersAdresses)
            {
                AddPeer(address, (sender is Tracker) ? (sender as Tracker) : null);
            }
        }

        public void SendMessageToPeer(Message message, EndPoint address)
        {
            var peerReciever = Peers.First(peer => peer.Address == address);
            if (peerReciever != null)
            {
                peerReciever.SendMessage(message);
            }
        }

        public void SendMessageToAllPeers(Message message)
        {
            foreach (var peer in Peers)
            {
                peer.SendMessage(message);
            }
        }

        private void PeerDiscovered(ShortGuid peerIdentifier, Dictionary<NetworkCommsDotNet.Connections.ConnectionType, List<EndPoint>> discoveredListenerEndPoints)
        {
            var address = discoveredListenerEndPoints[NetworkCommsDotNet.Connections.ConnectionType.TCP].First();

            AddPeer(address);
        }

        private void AddPeer(EndPoint address, Tracker tracker = null, bool withTracker = false)
        {
            if (!Peers.Any(peer => peer.Address == address))
            {
                var peer = new Peer(address, Peers, tracker);
                Peers.Add(peer);

                //перенаправляем события пира
                peer.OnRequestBlocksMessage += (s, e) => OnRequestBlocksMessage(s, e);
                peer.OnRequestTransactionsMessage += (s, e) => OnRequestTransactionsMessage(s, e);
                peer.OnBlocksMessage += (s, e) => OnBlocksMessage(s, e);
                peer.OnRequestTransactionsMessage += (s, e) => OnRequestTransactionsMessage(s, e);


                peer.Connect(withTracker);
            }
        }

        private void RequestPeers()
        {
            //считаем сколько нужно пиров
            int needPeersCount = normalPeersCount - Peers.Where(peer => peer.Status == PeerStatus.Connected).Count();
            if (needPeersCount <= 0) return;


            //сначала ищем пиры без трекера
            PeerDiscovery.DiscoverPeersAsync(PeerDiscovery.DiscoveryMethod.UDPBroadcast);



            //пиры подключенные прямо (сортируем по кол-ву запросов)
            var connectedPeersDirect = Peers.Where(peer => peer.Status == PeerStatus.Connected && peer.ConnectionType == ConnectionType.Direct)
                .OrderBy(peer => peer.PeersRequestsCount);

            //подключенные трекеры (сортируем по кол-ву запросов)
            var connectedTrackers = Trackers.Where(tracker => tracker.Status == TrackerStatus.Connected)
                .OrderBy(tracker => tracker.PeersRequestsCount);

            //пиры подключенные через трекер (сортируем по кол-ву запросов)
            var connectedPeersWithTracker = Peers.Where(peer => peer.Status == PeerStatus.Connected && peer.ConnectionType == ConnectionType.WithTracker)
                .OrderBy(peer => peer.PeersRequestsCount); ;

            //если есть подключенные пиры и трекеры
            if (connectedPeersDirect.Any() && connectedTrackers.Any())
            {
                var firstPeerDirect = connectedPeersDirect.First();
                var firstTracker = connectedTrackers.First();

                //запрашиваем у первого прямого пира, если к нему было меньше запросов чем к первому трекеру
                if (firstPeerDirect.PeersRequestsCount <= firstTracker.PeersRequestsCount)
                {
                    firstPeerDirect.RequestPeers(needPeersCount);
                }
                //если есть подключенные через трекеры пиры
                else if (connectedPeersWithTracker.Any())
                {
                    var firstPeerWithTracker = connectedPeersWithTracker.First();

                    //запрашиваем у первого трекера, если к нему было меньше запросов чем к первому подключенному через трекер пиру
                    if (firstTracker.PeersRequestsCount <= firstPeerWithTracker.PeersRequestsCount)
                        firstTracker.RequestPeersFromTracker(needPeersCount);
                    else
                        firstPeerWithTracker.RequestPeers(needPeersCount);

                }
                else
                {
                    firstTracker.RequestPeersFromTracker(needPeersCount);
                }

            }
            else if (connectedPeersDirect.Any())
            {
                var firstPeerDirect = connectedPeersDirect.First();
                firstPeerDirect.RequestPeers(needPeersCount);
            }
            else if (connectedTrackers.Any())
            {
                var firstTracker = connectedTrackers.First();
                firstTracker.RequestPeersFromTracker(needPeersCount);
            }
        }



        private void ConnectToTrackers()
        {
            foreach (var tracker in Trackers)
            {
                if (tracker.Status == TrackerStatus.Disconnected) tracker.Connect();
            }
        }

        private void ConnectToPeers()
        {
            foreach (var peer in Peers)
            {
                if (peer.Status != PeerStatus.Connected) peer.Connect();
            }
        }

        public void Disconnect()
        {
            foreach (var peer in Peers)
            {
                peer.DisconnectDirect();
            }
            foreach (var tracker in Trackers)
            {
                tracker.Disconnect();
            }

            t.Stop();

            Connection.StopListening();
            NetworkComms.Shutdown();

            NetworkComms.Logger.Warn("Client stopped");
        }

        public void Connect()
        {

            if (GetLocalEndPoint() != null)
            {
                PeerDiscovery.OnPeerDiscovered += PeerDiscovered;
                PeerDiscovery.EnableDiscoverable(PeerDiscovery.DiscoveryMethod.UDPBroadcast, GetLocalEndPoint());
            }

            Connection.StartListening(NetworkCommsDotNet.Connections.ConnectionType.TCP, GetLocalEndPoint());


            NetworkComms.Logger.Warn("Client started");

            //только для дебага !!!!!!
            ConnectToTrackers();
            RequestPeers();
            ConnectToPeers();
            //t.Start();
        }

        private void SetupLogging()
        {
            LiteLogger logger = new LiteLogger(LiteLogger.LogMode.ConsoleAndLogFile, "log.txt");
            NetworkComms.EnableLogging(logger);

            NetworkComms.Logger.Warn("==================== Initialisation ====================");


        }


        static public EndPoint GetLocalEndPoint()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return null;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            EndPoint endPoint = new IPEndPoint(host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork), Port);
            return endPoint;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkCommsDotNet;
using BlockChainVotings;
using NetworkCommsDotNet.Connections.TCP;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class UnitTestClientTracker
    {
        [TestMethod]
        public void TestMethodClientTracker()
        {
            NetworkComms.EnableLogging();
            NetworkComms.Shutdown();

            int myPort = CommonHelpers.PeerPort + 2;
            VotingsUser.PeerDiscovery = true;

            Tracker tracker1 = null;
            TCPConnection our = null;
            List<Tracker> allTrackers = null;


            int connToPeer = 0;
            int toPeer = 0;
            int reqPeers = 0;
            int peersEvent = 0;
            int blocksEvent = 0;



            //============

            //прослушиваем 2 порта
            TCPConnection.StartListening(CommonHelpers.GetLocalEndPoint(myPort, true)); //мы
            TCPConnection.StartListening(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort, true)); //они


            allTrackers = new List<Tracker>();
            tracker1 = new Tracker(CommonHelpers.GetLocalEndPoint(myPort), allTrackers);
            allTrackers.Add(tracker1);

            //получаем подключение пира к нам
            NetworkComms.AppendGlobalConnectionEstablishHandler((c) =>
            {
                our = c as TCPConnection;
            });

            //определяем, что сообщения пришли

            NetworkComms.AppendGlobalIncomingPacketHandler<ConnectToPeerWithTrackerMessage>(typeof(ConnectToPeerWithTrackerMessage).Name, (p, c, i) =>
            {
                connToPeer++;
            });

            NetworkComms.AppendGlobalIncomingPacketHandler<ToPeerMessage>(typeof(ToPeerMessage).Name, (p, c, i) =>
            {
                toPeer++;
            });


            NetworkComms.AppendGlobalIncomingPacketHandler<RequestPeersMessage>(typeof(RequestPeersMessage).Name, (p, c, i) =>
            {
                reqPeers++;
            });



            tracker1.OnBlocksMessage += (s, e) =>
            {
                blocksEvent++;
            };



            tracker1.OnRequestPeersMessage += (s, e) =>
            {
                peersEvent++;
            };



            //============


            //подключаемся к пиру
            tracker1.Connect();
            w();
            Assert.IsTrue(tracker1.Status == TrackerStatus.Connected);



            //запрашиваем пиры у нас
            tracker1.RequestPeersFromTracker(10);
            w();
            Assert.IsTrue(reqPeers == 1);


            //отправляем сообщение нам
            tracker1.SendMessageToPeer(
                new RequestBlocksMessage(new List<string>()),
                new Peer(new IPEndPoint(0, 0),
                new List<Peer>()));
            w();
            Assert.IsTrue(toPeer == 1);

            //запрашиваем пиры у пира
            our.SendObject<ToPeerMessage>(
                typeof(ToPeerMessage).Name, 
                new ToPeerMessage(new IPEndPoint(0, 0), 
                CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort, true), new RequestPeersMessage(10)));
            w();
            Assert.IsTrue(peersEvent == 1);



            //отправляем блоки пиру
            our.SendObject<ToPeerMessage>(
                typeof(ToPeerMessage).Name, 
                new ToPeerMessage(new IPEndPoint(0, 0), 
                CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort, true), new BlocksMessage()));
            w();
            Assert.IsTrue(blocksEvent == 1);


            //отправляем подключение к пиру нам
            tracker1.ConnectPeerToPeer(new Peer(new IPEndPoint(0, 0), new List<Peer>()));
            w();
            Assert.IsTrue(connToPeer == 1);


            //дисконнект от трекера
            tracker1.Disconnect();
            w();
            Assert.IsTrue(allTrackers.Count == 0);
        }

        void w()
        {
            Thread.Sleep(3000);
        }
    }
}

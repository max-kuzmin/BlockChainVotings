using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainVotings;
using System.Collections.Generic;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using System.Threading;
using System.Net;
using NetworkCommsDotNet.Tools;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class UnitTestClientPeer
    {


        [TestMethod]
        public void TestMethodClientPeer()
        {
            NetworkComms.EnableLogging();
            NetworkComms.Shutdown();

            int theirPort = CommonHelpers.PeerPort + 2;
            string hash = "hash1";
            VotingsUser.PeerDiscovery = true;

            Peer peer1 = null;
            TCPConnection our = null;
            List<Peer> allPeers = null;


            int reqHash = 0;
            int reqPeers = 0;
            int reqBlocks = 0;
            int respPeers = 0;
            int blocksEvent = 0;
            int trsEvent = 0;
            int blocksReqEvent = 0;
            int trsReqEvent = 0;


            //============

            //прослушиваем 2 порта
            TCPConnection.StartListening(CommonHelpers.GetLocalEndPoint(CommonHelpers.PeerPort, true)); //мы
            TCPConnection.StartListening(CommonHelpers.GetLocalEndPoint(theirPort, true)); //они


            allPeers = new List<Peer>();
            peer1 = new Peer(CommonHelpers.GetLocalEndPoint(theirPort, true), allPeers);
            allPeers.Add(peer1);

            //получаем подключение пира к нам
            NetworkComms.AppendGlobalConnectionEstablishHandler((c) =>
            {
                our = c as TCPConnection;
            });



            //определяем, что сообщения пришли
            NetworkComms.AppendGlobalIncomingPacketHandler<PeerHashMessage>(typeof(PeerHashMessage).Name, (p, c, i) =>
            {
                reqHash++;
            });

            NetworkComms.AppendGlobalIncomingPacketHandler<RequestPeersMessage>(typeof(RequestPeersMessage).Name, (p, c, i) =>
            {
                reqPeers++;
            });

            NetworkComms.AppendGlobalIncomingPacketHandler<RequestBlocksMessage>(typeof(RequestBlocksMessage).Name, (p, c, i) =>
            {
                reqBlocks++;
            });

            NetworkComms.AppendGlobalIncomingPacketHandler<PeersMessage>(typeof(PeersMessage).Name, (p, c, i) =>
            {
                respPeers++;
            });


            peer1.OnBlocksMessage += (s, e) =>
            {
                blocksEvent++;
            };

            peer1.OnTransactionsMessage += (s, e) =>
            {
                trsEvent++;
            };

            peer1.OnRequestBlocksMessage += (s, e) =>
            {
                blocksReqEvent++;
            };

            peer1.OnRequestTransactionsMessage += (s, e) =>
            {
                trsReqEvent++;
            };


            //============


            //подключаемся к пиру
            peer1.Connect();
            w();
            Assert.IsTrue(peer1.Status == PeerStatus.NoHashRecieved);
            Assert.IsTrue(reqHash == 1);


            //отправляем хеш пиру
            our.SendObject<PeerHashMessage>(typeof(PeerHashMessage).Name, new PeerHashMessage(hash, false));
            w();
            Assert.IsTrue(peer1.Hash == hash);
            Assert.IsTrue(peer1.Status == PeerStatus.Connected);

            //отправляем сообщение нам
            peer1.SendMessage(new RequestBlocksMessage(new List<string>()));
            w();
            Assert.IsTrue(reqBlocks == 1);

            //проверяем подключение
            peer1.CheckConnection();
            w();
            Assert.IsTrue(peer1.ErrorsCount == 0);

            //запрашиваем пиры у нас
            peer1.RequestPeers(10);
            w();
            Assert.IsTrue(reqPeers == 1);


            //запрашиваем пиры у пира
            our.SendObject<RequestPeersMessage>(typeof(RequestPeersMessage).Name, new RequestPeersMessage(10));
            w();
            Assert.IsTrue(reqPeers == 2);
            Assert.IsTrue(respPeers == 1);

            //отправляем блоки пиру
            our.SendObject<BlocksMessage>(typeof(BlocksMessage).Name, new BlocksMessage());
            w();
            Assert.IsTrue(blocksEvent == 1);

            //отправляем транзакции пиру
            our.SendObject<TransactionsMessage>(typeof(TransactionsMessage).Name, new TransactionsMessage());
            w();
            Assert.IsTrue(trsEvent == 1);

            //запрашиваем транзакции у пира
            our.SendObject<RequestTransactionsMessage>(typeof(RequestTransactionsMessage).Name, new RequestTransactionsMessage());
            w();
            Assert.IsTrue(trsReqEvent == 1);

            //запрашиваем транзакции у пира
            our.SendObject<RequestBlocksMessage>(typeof(RequestBlocksMessage).Name, new RequestBlocksMessage());
            w();
            Assert.IsTrue(blocksReqEvent == 1);


            //отключаемся от пира
            peer1.DisconnectAny();
            w();
            Assert.IsTrue(allPeers.Count == 0);
        }

        void w()
        {
            Thread.Sleep(3000);
        }

    }
}

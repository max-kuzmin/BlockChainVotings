using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainVotings;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet;
using System.Threading;
using System.Net;
using System.Collections.Generic;


namespace Tests
{
    [TestClass]
    public class UnitTestNetworkAndTracker
    {
        [TestMethod]
        public void TestMethodNetworkAndTracker()
        {
            VotingsUser.Trackers = CommonHelpers.GetLocalEndPoint(CommonHelpers.TrackerPort, true).Address.ToString();
            VotingsUser.PeerDiscovery = false;

            //создаем трекер
            var tr = new BlockChainVotingsTracker.Tracker();
            tr.Start();

            //добавляем пир в трекер
            var con = TCPConnection.GetConnection(new ConnectionInfo(CommonHelpers.GetLocalEndPoint(10000, true)), false);
            var peer = new BlockChainVotingsTracker.Peer(con, tr.Peers, new System.Timers.Timer());
            peer.Status = BlockChainVotingsTracker.PeerStatus.Connected;
            tr.Peers.Add(peer);

            //создаем клиент и подключаемся
            var net = new Network();
            net.Connect();

            w(); w();

            Assert.IsTrue(net.Started == true);
            Assert.IsTrue(net.Trackers.Count == 1);
            Assert.IsTrue(net.Peers.Count == 1);

            //отключаемся
            net.Disconnect();
            w();
            Assert.IsTrue(net.Started == false);
            Assert.IsTrue(net.Trackers.Count == 0);
            Assert.IsTrue(net.Peers.Count == 0);
        }

        void w()
        {
            Thread.Sleep(5000);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainVotings;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class UnitTestBlockchain
    {
        [TestMethod]
        public void TestMethodBlockchain()
        {
            var keys = CommonHelpers.GetPublicPrivateKeys();
            VotingsUser.PublicKey = "MFYwEAYHKoZIzj0CAQYFK4EEAAoDQgAEhWfjbJW2Xd+f0Gls8bi2pzrV5av+R7eG6H8ysQXKNY99mL5j+fUSoJRDaZz9dxhPq3+zmRiewNy0BesJljUl1Q==";
            VotingsUser.PrivateKey = "MHQCAQEEICUx8Nb2dysdxxbGHvw6yEWLgqw6PW+YLd74Z0PVxBfMoAcGBSuBBAAKoUQDQgAEhWfjbJW2Xd+f0Gls8bi2pzrV5av+R7eG6H8ysQXKNY99mL5j+fUSoJRDaZz9dxhPq3+zmRiewNy0BesJljUl1Q==";
            VotingsUser.CreateOwnBlocks = true;
            VotingsUser.PeerDiscovery = true;

            var db = new VotingsDB();
            db.ConnectToDBAsync();
            db.Clear();

            var blockchain = new BlockChainVotings.BlockChainVotings();
            blockchain.Start();

            Assert.IsTrue(blockchain.Started == true);

            //проверка корня
            blockchain.CheckRoot();
            Assert.IsTrue(db.GetUserCreation(VotingsUser.RootPublicKey).Signature == VotingsUser.RootCreationSignature);
            Assert.IsTrue(db.GetVoting(0).Signature == VotingsUser.FirstVotingSignature);
            Assert.IsTrue(db.GetBlock(0).Signature == VotingsUser.FirstBlockSignature);

            //создание пользователя
            var newUser = keys[0];
            blockchain.CreateUser(newUser, "somename", "12345");
            Assert.IsNotNull(db.GetUserCreation(newUser));

            //голосования
            var list = new List<String>();
            list.Add(newUser);
            list.Add(VotingsUser.RootPublicKey);

            blockchain.CreateVoting(list, "voting");
            Assert.IsTrue(JObject.Parse(db.GetVoting(1).Info)["name"].Value<string>() == "voting");

            //голоса
            blockchain.CreateVote(newUser, db.GetVoting(1).Hash);
            Assert.IsTrue(db.GetUserVote(VotingsUser.PublicKey, 1).RecieverHash == newUser);

            //бан
            blockchain.BanUser(newUser, "cause");
            Assert.IsTrue(db.GetUserBan(newUser).RecieverHash == newUser);


            //создание блока
            for (int i = 0; i < 6; i++)
            {
                blockchain.CreateUser(newUser+i, "somename", "12345");
            }

            Assert.IsTrue(db.GetLastBlock().Transactions.Contains(db.GetUserCreation(newUser).Hash));
            Assert.IsTrue(db.GetFreeTransactions(100).Count == 0);

        }

        void w()
        {
            Thread.Sleep(3000);
        }
    }
}

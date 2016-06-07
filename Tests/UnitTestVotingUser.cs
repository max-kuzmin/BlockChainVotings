using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainVotings;
using System.Security.Permissions;

namespace Tests
{
    [TestClass]
    public class UnitTestVotingUser
    {

        string publ = "publ";
        string priv = "priv";
        string pass = "pass";
        string trackers = "trackers";
        int theme = 0;


        [TestMethod]
        public void TestMethodVotingUser()
        {
            VotingsUser.ClearUserData();
            VotingsUser.Register(publ, priv, pass);
            VotingsUser.ChangeSetting("trackers", trackers);

            VotingsUser.GetKeysFromConfig();

            Assert.IsTrue(VotingsUser.CheckUserExists());

            Assert.IsTrue(VotingsUser.CreateOwnBlocks == true);
            Assert.IsTrue(VotingsUser.PublicKey == publ);
            Assert.IsTrue(VotingsUser.PeerDiscovery == true);
            Assert.IsTrue(VotingsUser.Trackers == trackers);
            Assert.IsTrue(VotingsUser.Theme == theme);
            Assert.IsTrue(VotingsUser.UseLanLocalIP == true);
            Assert.IsTrue(VotingsUser.Login(pass));

            VotingsUser.ClearUserData();
            Assert.IsTrue(VotingsUser.CheckUserExists() == false);
            Assert.IsTrue(VotingsUser.PrivateKey == priv);

        }
    }
}

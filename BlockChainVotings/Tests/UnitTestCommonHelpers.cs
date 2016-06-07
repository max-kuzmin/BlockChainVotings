using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChainVotings;

namespace Tests
{
    [TestClass]
    public class UnitTestCommonHelpers
    {
        [TestMethod]
        public void TestMethodCommonHelpers()
        {
            string data = "data";

            VotingsUser.UseLanLocalIP = false;
            Assert.IsTrue(CommonHelpers.GetLocalEndPoint(1000, true).Address.ToString().Contains("192."));
            Assert.IsTrue(!CommonHelpers.GetLocalEndPoint(1000, false).Address.ToString().Contains("192."));

            Assert.IsTrue(CommonHelpers.CalcHash(data).Length > 0);

            var keys = CommonHelpers.GetPublicPrivateKeys();
            Assert.IsTrue(keys[1].Length > 0);
            Assert.IsTrue(CommonHelpers.CheckKeys(keys[0], keys[1]));

            var sign = CommonHelpers.SignData(data, keys[1]);
            Assert.IsTrue(sign.Length > 0);
            Assert.IsTrue(CommonHelpers.VerifyData(data, sign, keys[0]));

            var time = CommonHelpers.GetTime();
            Assert.IsTrue(time.Year == DateTime.Now.Year && time.Month == DateTime.Now.Month
                 && time.Day == DateTime.Now.Day && time.Hour == DateTime.Now.Hour
                 && time.Minute == DateTime.Now.Minute);
        }
    }
}

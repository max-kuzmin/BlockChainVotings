using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public static class VotingsUser
    {
        static public string PublicKey = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());
        static public string PrivateKey = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());
        static public string RootPublicKey;
    }
}

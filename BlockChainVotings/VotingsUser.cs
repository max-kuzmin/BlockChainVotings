using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    static public class VotingsUser
    {
        static public string PublicKey = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());
        static public string PrivateKey = (new Random((int)(DateTime.Now.Ticks)).Next().ToString());
        static public string RootPublicKey;
        static public string RootCreationSignature;
        static public DateTime RootUserDate = new DateTime(2016, 1, 1);


        static public void Login(string password) 
        {
            throw new NotImplementedException();
        }

        static public void SaveUser(string publicKey, string privateKey, string password)
        {
            throw new NotImplementedException();
        }

        static public void ClearUserData()
        {
            throw new NotImplementedException();
        }
    }
}

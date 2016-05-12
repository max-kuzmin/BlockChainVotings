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
        static public DateTime RootUserDate;


        static public void Login(string password) 
        {

        }

        static public void SaveUser(string publicKey, string privateKey, string password)
        {

        }

        static public void ClearUserData()
        {
            
        }
    }
}

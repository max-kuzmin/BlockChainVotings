using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virgil.Crypto;

namespace BlockChainVotings
{
    static public class VotingsUser
    {
        static public string PublicKey;
        static public string PrivateKey;
        static string PrivateKeyCrypted;
        static string PasswordHash;
        static public string RootPublicKey;
        static public string RootCreationSignature;
        static public DateTime RootUserDate = new DateTime(2016, 1, 1);


        static public bool Login(string password) 
        {
            if (PublicKey!=null && PrivateKeyCrypted != null && PasswordHash != null)
            {
                if (PasswordHash == CommonHelpers.CalcHash(password))
                {
                    PrivateKey = Encoding.UTF8.GetString(CryptoHelper.Decrypt(Encoding.UTF8.GetBytes(PrivateKeyCrypted), password));
                    return true;
                }
            }
            return false;
        }


        static public void GetKeysFromConfig()
        {
            if (CheckUserExists())
            {
                PublicKey = ConfigurationManager.AppSettings.Get("publicKey");
                PrivateKeyCrypted = ConfigurationManager.AppSettings.Get("privateKeyCrypted");
                PasswordHash = ConfigurationManager.AppSettings.Get("passwordHash");
            }
        }

        static public void ClearUserData()
        {
            ConfigurationManager.AppSettings.Remove("publicKey");
            ConfigurationManager.AppSettings.Remove("privateKeyCrypted");
            ConfigurationManager.AppSettings.Remove("passwordHash");
        }

        static public bool CheckUserExists()
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains("publicKey") &&
                ConfigurationManager.AppSettings.AllKeys.Contains("privateKeyCrypted") &&
                ConfigurationManager.AppSettings.AllKeys.Contains("passwordHash"))
                return true;
            else return false;
        }

        static public void Register(string publicKey, string privateKey, string password)
        {
            string privateKeyCrypted = Encoding.UTF8.GetString(CryptoHelper.Encrypt(Encoding.UTF8.GetBytes(privateKey), password));
            string passwordHash = CommonHelpers.CalcHash(privateKey);

            ConfigurationManager.AppSettings.Set("publicKey", publicKey);
            ConfigurationManager.AppSettings.Set("privateKeyCrypted", privateKeyCrypted);
            ConfigurationManager.AppSettings.Set("passwordHash", passwordHash);
        }
    }
}

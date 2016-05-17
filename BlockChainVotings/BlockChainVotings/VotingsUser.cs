using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        public static string PasswordHash;

        static public string RootPublicKey = "LS0tLS1CRUdJTiBQVUJMSUMgS0VZLS0tLS0KTUZzd0ZRWUhLb1pJemowQ0FRWUtLd1lCQkFHWFZRRUZBUU5DQUFSN1FQeEYzVjZzV0l5Y1o2Q0JlenRYeEljQgo1WTdCd2hRdTBKaVFlWXhZdVFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUEKLS0tLS1FTkQgUFVCTElDIEtFWS0tLS0tCg==";
        static public string RootCreationSignature = "MFkwDQYJYIZIAWUDBAICBQAESDBGAiEAxS2PLzJ4a3aYaDoiyIwSLvy3RjMiQXoYQx6LPl4nKc8CIQCC+K2Q79OdQSdMmrnA3ybRBHENnlxrx/rcazqrx+/BcA==";
        static public string FirstVotingSignature = "MFkwDQYJYIZIAWUDBAICBQAESDBGAiEAtO8rUKFxUCVDA54wAQiqI9LFvQHDql0Fu9ROs+pytXACIQCE2fXvIgwJpdmCgja5HAi/zJPDAmHrJhYFIqiJJrFiKA==";
        static public string FirstBlockSignature = "MFkwDQYJYIZIAWUDBAICBQAESDBGAiEAiRSmH2zdKAl7pfmi8SvrsyFGS+v+4L9BOIBDcgpoAPwCIQCIzH1BJE+jgyBPa1e3KOI52xqBC3exkq38wWEiNRJQJg==";

        static public DateTime RootUserDate = new DateTime(2016, 1, 1);



        //static Configuration config = ConfigurationManager.OpenExeConfiguration(Path.Combine(Environment.CurrentDirectory, Process.GetCurrentProcess().MainModule.FileName));
        static Configuration config = ConfigurationManager.OpenExeConfiguration(Path.Combine(Environment.CurrentDirectory, "BlockChainVotings.exe"));


        static public bool Login(string password)
        {
            if (PublicKey != null && PrivateKeyCrypted != null && PasswordHash != null)
            {
                if (PasswordHash == CommonHelpers.CalcHash(password))
                {
                    PrivateKey = CryptoHelper.Decrypt(PrivateKeyCrypted, password);
                    return true;
                }
            }
            return false;
        }


        static public void GetKeysFromConfig()
        {
            //if (CheckUserExists())
            //{
            PublicKey = config.AppSettings.Settings["publicKey"].Value;
            PrivateKeyCrypted = config.AppSettings.Settings["privateKeyCrypted"].Value;
            PasswordHash = config.AppSettings.Settings["passwordHash"].Value;
            //}
        }

        static public void ClearUserData()
        {
            config.AppSettings.Settings.Remove("publicKey");
            config.AppSettings.Settings.Remove("privateKeyCrypted");
            config.AppSettings.Settings.Remove("passwordHash");
            config.Save();
        }

        static public bool CheckUserExists()
        {
            if (config.AppSettings.Settings.AllKeys.Contains("publicKey") &&
                config.AppSettings.Settings.AllKeys.Contains("privateKeyCrypted") &&
                config.AppSettings.Settings.AllKeys.Contains("passwordHash"))
                return true;
            else return false;
        }

        static public void Register(string publicKey, string privateKey, string password)
        {
            string privateKeyCrypted = Convert.ToBase64String(CryptoHelper.Encrypt(Encoding.UTF8.GetBytes(privateKey), password));
            string passwordHash = CommonHelpers.CalcHash(password);

            config.AppSettings.Settings.Add("publicKey", publicKey);
            config.AppSettings.Settings.Add("privateKeyCrypted", privateKeyCrypted);
            config.AppSettings.Settings.Add("passwordHash", passwordHash);
            config.Save();
        }
    }
}
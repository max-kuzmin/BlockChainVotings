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

        static public string RootPublicKey = "MFYwEAYHKoZIzj0CAQYFK4EEAAoDQgAEhWfjbJW2Xd+f0Gls8bi2pzrV5av+R7eG6H8ysQXKNY99mL5j+fUSoJRDaZz9dxhPq3+zmRiewNy0BesJljUl1Q==";
        static public string RootCreationSignature = "MFgwDQYJYIZIAWUDBAICBQAERzBFAiEArA9SnlCxrh3xD7w3TQ7mAENQ3xgWwAFE7bL7mLSRAOACIGqVhy3uks97DdIQhjA8EAPdW1hArdsbvYJdndSodlD6";
        static public string FirstVotingSignature = "MFgwDQYJYIZIAWUDBAICBQAERzBFAiEA4Px5VS8aKtMNq4zmdBd9jtYe1uBfGpk27nOmm9pORigCIEts8ThqMphCuaxo3fh1STHLGAWKIYSCMTELWW8J9hZO";
        static public string FirstBlockSignature = "MFkwDQYJYIZIAWUDBAICBQAESDBGAiEAwVRfJ4BaVOfrAg588C9blSThuTB9GtOYed06u6ZLU38CIQDw/1Yz3conNjirNMbFtMBrJuS+yfpPQETEBMqfrwJueQ==";

        static public DateTime RootUserDate = new DateTime(2016, 1, 1);


        static public bool CreateOwnBlocks;
        static public int Theme;
        static public string Trackers = "";
        static public bool PeerDiscovery;

        static public bool UseLanLocalIP = true;




        static Configuration config = ConfigurationManager.OpenExeConfiguration(Path.Combine(Environment.CurrentDirectory, Process.GetCurrentProcess().MainModule.FileName));
        //static Configuration config = ConfigurationManager.OpenExeConfiguration(Path.Combine(Environment.CurrentDirectory, "BlockChainVotings.exe"));


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

            PublicKey = config.AppSettings.Settings["publicKey"].Value;
            PrivateKeyCrypted = config.AppSettings.Settings["privateKeyCrypted"].Value;
            PasswordHash = config.AppSettings.Settings["passwordHash"].Value;

            CreateOwnBlocks = bool.Parse(config.AppSettings.Settings["createOwnBlocks"].Value);
            Theme = int.Parse(config.AppSettings.Settings["theme"].Value);
            Trackers = config.AppSettings.Settings["trackers"].Value;
            PeerDiscovery = bool.Parse(config.AppSettings.Settings["peerDiscovery"].Value);
            UseLanLocalIP = bool.Parse(config.AppSettings.Settings["useLanLocalIP"].Value);


        }

        static public void ClearUserData()
        {
            config.AppSettings.Settings.Remove("publicKey");
            config.AppSettings.Settings.Remove("privateKeyCrypted");
            config.AppSettings.Settings.Remove("passwordHash");

            config.AppSettings.Settings.Remove("createOwnBlocks");
            config.AppSettings.Settings.Remove("theme");
            config.AppSettings.Settings.Remove("trackers");
            config.AppSettings.Settings.Remove("peerDiscovery");
            config.AppSettings.Settings.Remove("useLanLocalIP");

            config.Save();
        }

        static public bool CheckUserExists()
        {
            if (config.AppSettings.Settings.AllKeys.Contains("publicKey") &&
                config.AppSettings.Settings.AllKeys.Contains("privateKeyCrypted") &&
                config.AppSettings.Settings.AllKeys.Contains("passwordHash") &&

                config.AppSettings.Settings.AllKeys.Contains("createOwnBlocks") &&
                config.AppSettings.Settings.AllKeys.Contains("theme") &&
                config.AppSettings.Settings.AllKeys.Contains("trackers") &&
                config.AppSettings.Settings.AllKeys.Contains("peerDiscovery") &&
                config.AppSettings.Settings.AllKeys.Contains("useLanLocalIP"))
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

            config.AppSettings.Settings.Add("createOwnBlocks", true.ToString());
            config.AppSettings.Settings.Add("theme", 0.ToString());
            config.AppSettings.Settings.Add("trackers", Trackers);
            config.AppSettings.Settings.Add("peerDiscovery", true.ToString());
            config.AppSettings.Settings.Add("useLanLocalIP", true.ToString());

            config.Save();
        }


        static public void ChangeSetting(string name, string value)
        {
            config.AppSettings.Settings.Remove(name);
            config.AppSettings.Settings.Add(name, value);
            config.Save();
        }
    }
}
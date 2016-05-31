using Android.App;
using Android.Content;
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

namespace BlockChainVotingsAndroid
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
        static public string Trackers = "192.168.0.36";
        static public bool PeerDiscovery;


        static ISharedPreferences prefs = Application.Context.GetSharedPreferences("Setting", FileCreationMode.Private);
        static ISharedPreferencesEditor prefEditor = prefs.Edit();

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
            PublicKey = prefs.GetString("publicKey", null);
            PrivateKeyCrypted = prefs.GetString("privateKeyCrypted", null);
            PasswordHash = prefs.GetString("passwordHash", null);

            CreateOwnBlocks = bool.Parse(prefs.GetString("createOwnBlocks", null));
            Trackers = prefs.GetString("trackers", null);
            PeerDiscovery = bool.Parse(prefs.GetString("peerDiscovery", null));
        }

        static public void ClearUserData()
        {
            
            prefEditor.Remove("publicKey");
            prefEditor.Remove("privateKeyCrypted");
            prefEditor.Remove("passwordHash");

            prefEditor.Remove("createOwnBlocks");
            prefEditor.Remove("theme");
            prefEditor.Remove("trackers");
            prefEditor.Remove("peerDiscovery");

            prefEditor.Commit();
        }

        static public bool CheckUserExists()
        {
            
            if (prefs.Contains("publicKey") &&
                prefs.Contains("privateKeyCrypted") &&
                prefs.Contains("passwordHash") &&

                prefs.Contains("createOwnBlocks") &&
                prefs.Contains("theme") &&
                prefs.Contains("trackers") &&
                prefs.Contains("peerDiscovery"))
                return true;
            else return false;
        }

        static public void Register(string publicKey, string privateKey, string password)
        {
            string privateKeyCrypted = Convert.ToBase64String(CryptoHelper.Encrypt(Encoding.UTF8.GetBytes(privateKey), password));
            string passwordHash = CommonHelpers.CalcHash(password);

            
            prefEditor.PutString("publicKey", publicKey);
            prefEditor.PutString("privateKeyCrypted", privateKeyCrypted);
            prefEditor.PutString("passwordHash", passwordHash);

            prefEditor.PutString("createOwnBlocks", true.ToString());
            prefEditor.PutString("theme", 0.ToString());
            prefEditor.PutString("trackers", Trackers);
            prefEditor.PutString("peerDiscovery", true.ToString());

            prefEditor.Commit();
        }


        static public void ChangeSetting(string name, string value)
        {
            prefEditor.Remove(name);
            prefEditor.PutString(name, value);
            prefEditor.Commit();
        }
    }
}
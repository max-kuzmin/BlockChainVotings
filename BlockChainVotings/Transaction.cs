using ProtoBuf;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlockChainVotings
{
    [ProtoContract]
    [Table("Transaction")]
    public class Transaction
    {
        [ProtoMember(30)]
        public DateTime Date { get; set; }

        [ProtoMember(31)]
        public string PreviousHash { get; set; }

        [ProtoMember(32)]
        public TransactionType Type { get; set; }

        [ProtoMember(33)]
        public string SenderHash { get; set; }

        [ProtoMember(34)]
        public string RecieverHash { get; set; }

        [ProtoMember(35)]
        public int VotingNumber { get; set; }

        [ProtoMember(36)]
        public string Info { get; set; } //json

        [ProtoMember(37)]
        [PrimaryKey]
        public string Hash { get; set; }

        [ProtoMember(38)]
        public string Signature { get; set; }


        //поле для нахождения несвязаных в блоки транзакций
        public bool InBlock { get; set; }


        public bool CheckHash()
        {
            if (CalcHash() == Hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CalcHash()
        {
            string data = "";

            data += Date.Ticks + PreviousHash + (int)Type;
            data += SenderHash + RecieverHash + VotingNumber + Info;

            return CommonHelpers.CalcHash(data);
        }

        public string CalcSignature()
        {
            return CommonHelpers.SignData(Hash, VotingsUser.PrivateKey);
        }

        public bool CheckSignature()
        {
            if (CalcSignature() == Signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static Transaction CreateUserTransacton(string publicHash, string name, string id, string previousHash)
        {
            var tr = new Transaction();

            tr.Type = TransactionType.CreateUser;
            tr.Date = CommonHelpers.GetTime();
            tr.SenderHash = VotingsUser.PublicKey;
            tr.RecieverHash = publicHash;
            tr.PreviousHash = previousHash;

            JObject info = new JObject();
            info["name"] = name;
            info["id"] = id;
            tr.Info = info.ToString();

            tr.Hash = tr.CalcHash();
            tr.Signature = tr.CalcSignature();

            return tr;
        }

        public static Transaction BanUserTransaction(string cause, string publicHash, string previousHash)
        {
            var tr = new Transaction();

            tr.Type = TransactionType.BanUser;
            tr.Date = CommonHelpers.GetTime();
            tr.SenderHash = VotingsUser.PublicKey;
            tr.RecieverHash = publicHash;
            tr.PreviousHash = previousHash;

            JObject info = new JObject();
            info["cause"] = cause;
            tr.Info = info.ToString();

            tr.Hash = tr.CalcHash();
            tr.Signature = tr.CalcSignature();

            return tr;
        }

        public static Transaction VoteTransaction(string candidateHash, string votingHash)
        {
            var tr = new Transaction();

            tr.Type = TransactionType.Vote;
            tr.Date = CommonHelpers.GetTime();
            tr.SenderHash = VotingsUser.PublicKey;
            tr.RecieverHash = candidateHash;

            tr.PreviousHash = votingHash;

            tr.Hash = tr.CalcHash();
            tr.Signature = tr.CalcSignature();

            return tr;
        }

        public static Transaction StartVotingTransation(List<string> candidatesHashes, string nameOfVoting, int votingNumber, string previousVotingHash)
        {
            var tr = new Transaction();

            tr.Type = TransactionType.StartVoting;
            tr.Date = CommonHelpers.GetTime();
            tr.SenderHash = VotingsUser.PublicKey;

            JObject info = new JObject();
            JArray candidates = new JArray(candidatesHashes.ToArray());
            info["candidates"] = candidates;
            info["name"] = nameOfVoting;
            tr.Info = info.ToString();

            tr.PreviousHash = previousVotingHash;

            tr.Hash = tr.CalcHash();
            tr.Signature = tr.CalcSignature();

            return tr;
        }


        static Transaction ChangeRootUserTransation()
        {
            //var tr = new Transaction();
            //tr.Type = TransactionType.ChangeRootUser;
            //return tr;

            throw new NotImplementedException();
        }



        //
        long dateTicks;

        [ProtoBeforeSerialization]
        private void Serialize()
        {
            dateTicks = Date.Ticks;
        }

        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            Date = new DateTime(dateTicks);
        }
    }
}

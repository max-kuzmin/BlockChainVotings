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
        [Ignore]
        public DateTime Date0
        {
            get { return new DateTime(Date); }
            set { Date = value.Ticks; }
        }

        [ProtoMember(30)]
        public long Date { get; set; }

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
        [ProtoMember(39)]
        public TransactionStatus Status { get; set; }


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

        public Transaction() { }

        public string CalcHash()
        {
            string data = "";

            data += Date0.Ticks + PreviousHash + (int)Type;
            data += SenderHash + RecieverHash + VotingNumber + Info;

            return CommonHelpers.CalcHash(data);
        }

        public string CalcSignature()
        {
            return CommonHelpers.SignData(Hash, VotingsUser.PrivateKey);
        }

        public bool CheckSignature()
        {
            if (CommonHelpers.VerifyData(Hash, Signature, SenderHash))
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
            tr.Date0 = CommonHelpers.GetTime();
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
            tr.Date0 = CommonHelpers.GetTime();
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

        public static Transaction VoteTransaction(string candidateHash, string votingHash, int votingNumber)
        {
            var tr = new Transaction();

            tr.Type = TransactionType.Vote;
            tr.Date0 = CommonHelpers.GetTime();
            tr.SenderHash = VotingsUser.PublicKey;
            tr.RecieverHash = candidateHash;
            tr.VotingNumber = votingNumber;

            tr.PreviousHash = votingHash;

            tr.Hash = tr.CalcHash();
            tr.Signature = tr.CalcSignature();

            return tr;
        }

        public static Transaction StartVotingTransation(List<string> candidatesHashes, string nameOfVoting, int votingNumber, string previousVotingHash)
        {
            var tr = new Transaction();

            tr.Type = TransactionType.StartVoting;
            tr.Date0 = CommonHelpers.GetTime();
            tr.SenderHash = VotingsUser.PublicKey;
            tr.VotingNumber = votingNumber;

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


    }
}

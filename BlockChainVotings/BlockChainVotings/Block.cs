using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    [Table("Block")]
    [ProtoContract]
    public class Block
    {
        [Ignore]
        public DateTime Date0 {
            get { return new DateTime(Date); }
            set { Date = value.Ticks; } }

        [ProtoMember(20)]
        public long Date { get; set; }

        [ProtoMember(21)]
        public string PreviousHash { get; set; }

        [ProtoMember(22)]
        public int Number { get; set; }

        [ProtoMember(23)]
        public string CreatorHash { get; set; }

        [ProtoMember(24)]
        [Ignore]
        public List<string> Transactions { get; set; }

        public string TransactionsBlob {
            get
            {
                return JsonConvert.SerializeObject(Transactions);
            }
            set
            {
                Transactions = JsonConvert.DeserializeObject<List<string>>(value);
            }
        }

        [PrimaryKey]
        [ProtoMember(25)]
        public string Hash { get; set; }

        [ProtoMember(26)]
        public string Signature { get; set; }

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

        public Block() { }

        public string CalcHash()
        {
            string data = "";

            data += Date0.Ticks + PreviousHash + Number;

            foreach (var tr in Transactions)
            {
                data += tr;
            }

            return CommonHelpers.CalcHash(data);
        }

        public string CalcSignature()
        {
            return CommonHelpers.SignData(Hash, VotingsUser.PrivateKey);
        }

        public bool CheckSignature()
        {
            if (CommonHelpers.VerifyData(Hash, Signature, CreatorHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Block(List<Transaction> transactions, Block previousBlock)
        {
            Date0 = CommonHelpers.GetTime();
            PreviousHash = previousBlock.Hash;
            Number = previousBlock.Number + 1;
            CreatorHash = VotingsUser.PublicKey;


            List<string> transactionsHashes = new List<string>();

            foreach (var tr in transactions)
            {
                transactionsHashes.Add(tr.Hash);
            }

            Transactions = transactionsHashes;

            Hash = CalcHash();
            Signature = CalcSignature();


        }


        ////

        //[ProtoBeforeSerialization]
        //private void Serialize()
        //{
        //    Date = Date0.Ticks;
        //}

        //[ProtoAfterDeserialization]
        //private void Deserialize()
        //{
        //    Date0 = new DateTime(Date);
        //}

    }
}

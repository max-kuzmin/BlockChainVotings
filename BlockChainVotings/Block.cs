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
        [ProtoMember(20)]
        public DateTime Date { get; set; }

        [ProtoMember(21)]
        public string PreviousHash { get; set; }

        [ProtoMember(22)]
        public int Number { get; set; }

        [ProtoMember(23)]
        public List<Transaction> Transactions { get; set; }

        [PrimaryKey]
        [ProtoMember(24)]
        public string Hash { get; set; }

        [ProtoMember(25)]
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

        public string CalcHash()
        {
            string data = "";

            data += Date.Ticks + PreviousHash + Number;

            Transactions.Sort((x, y) => 
            {
                if (x.Date > y.Date) return 1;
                else if (x.Date < y.Date) return -1;
                else return 0;
            });

            foreach (var tr in Transactions)
            {
                data += tr.Hash;
            }

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

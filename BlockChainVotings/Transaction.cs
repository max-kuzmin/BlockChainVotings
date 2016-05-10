using ProtoBuf;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        static Transaction CreateUserTransacton()
        {

        }

        static Transaction BanUserTransaction()
        {

        }

        static Transaction VoteTransaction()
        {

        }

        static Transaction StartVotingTransation()
        {

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

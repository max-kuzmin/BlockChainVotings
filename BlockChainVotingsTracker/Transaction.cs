using ProtoBuf;
using System;


namespace BlockChainVotingsTracker
{
    [ProtoContract]
    public class Transaction
    {

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
        public string Hash { get; set; }

        [ProtoMember(38)]
        public string Signature { get; set; }



        //поле для нахождения несвязанных в блоки транзакций
        [ProtoMember(39)]
        public TransactionStatus Status { get; set; }


        public Transaction() { }


    }
}

using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace BlockChainVotingsTracker
{
    [ProtoContract]
    public class Block
    {
        public DateTime Date0
        {
            get { return new DateTime(Date); }
            set { Date = value.Ticks; }
        }

        [ProtoMember(20)]
        public long Date { get; set; }

        [ProtoMember(21)]
        public string PreviousHash { get; set; }

        [ProtoMember(22)]
        public int Number { get; set; }

        [ProtoMember(23)]
        public string CreatorHash { get; set; }

        [ProtoMember(24)]

        public List<string> Transactions { get; set; }

        public string TransactionsBlob
        {
            get
            {
                return JsonConvert.SerializeObject(Transactions);
            }
            set
            {
                Transactions = JsonConvert.DeserializeObject<List<string>>(value);
            }
        }

        [ProtoMember(25)]
        public string Hash { get; set; }

        [ProtoMember(26)]
        public string Signature { get; set; }


        public Block() { }




    }
}
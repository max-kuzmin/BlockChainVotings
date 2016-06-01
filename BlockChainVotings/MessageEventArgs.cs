using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public class MessageEventArgs
    {
        public Message Message { get; set; }
        public string SenderHash { get; set; }
        public EndPoint SenderAddress { get; set; }

        public MessageEventArgs(Message message, string senderHash, EndPoint senderAddress)
        {
            this.Message = message;
            this.SenderAddress = senderAddress;
        }

    }


    public class IntEventArgs
    {
        public int Data { get; set; }

        public IntEventArgs(int data)
        {
            this.Data = data;
        }

    }

}

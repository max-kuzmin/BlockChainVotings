using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainVotings
{
    public class MessageRecievedEventArgs
    {
        public Message Message { get; set; }
        public EndPoint Address { get; set; }

        public MessageRecievedEventArgs(Message message, EndPoint address)
        {
            this.Message = message;
            this.Address = address;
        }

    }
}

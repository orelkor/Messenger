using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Entities
{
    public class Message
    {
        public string Id;
        public string Body;
        public string User_id;
        public bool IsSendedMessage;

        public Message(string id, string body, string user_id, bool isSendedMessage)
        {
            Id = id;
            Body = body;
            User_id = user_id;
            IsSendedMessage = isSendedMessage;
        }

        public override string ToString()
        {
            string io = null;
            if (IsSendedMessage == true) io = "Я";
            else io = "Он";
            return string.Format("{0}:{1}", io, Body);
        }
    }
}

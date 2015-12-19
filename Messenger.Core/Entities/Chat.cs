using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Entities
{
    public class Chat : List<Message>
    {
        public string UserInConversationId;

        public Chat(string IdChat)
        {
            UserInConversationId = IdChat;
        }

        public Chat()
        {
           
        }
    }
}

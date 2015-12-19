using Messenger.Core.Abstracts;
using Messenger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Concrete
{
    public class ChatDirector
    {
        
        public Chat BuildChat(ChatBuilderBase _chatBuilder)
        {
            _chatBuilder.BuildChat();
            return _chatBuilder.GetResult();
        }
    }
}

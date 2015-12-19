using Messenger.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Entities;

namespace Messenger.Core.Concrete
{
    class ConcreteChatBuilder : ChatBuilderBase
    {
       
        public Chat _chat;
        public string _id;
        public ConcreteChatBuilder(string Id)
        {
            _id = Id;
        }

        public override void BuildChat()
        {
            _chat = new Chat(_id);
        }

        public override Chat GetResult()
        {
            return _chat;
        }

       
                
    }
}

using Messenger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Abstracts
{
    public abstract class ChatBuilderBase
    {
        public abstract void BuildChat();
        public abstract Chat GetResult();
    }
}

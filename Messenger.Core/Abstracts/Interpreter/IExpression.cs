using Messenger.Core.Concrete.Intrpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Abstracts.Interpreter
{
   public interface IExpression
    {
        string Interpret(SmileContext context);
    }
}

using Messenger.Core.Abstracts.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Concrete.Intrpreter
{
    public class SmileExpression : IExpression
    {
        string _text;
        public SmileExpression(string Text)
        {
            _text = Text;
        }
        public string Interpret(SmileContext context)
        {
            return context.FindSmileParser(_text);
        }
    }
}

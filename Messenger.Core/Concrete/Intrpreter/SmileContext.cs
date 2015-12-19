using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Concrete.Intrpreter
{
    public class SmileContext
    {
        public string FindSmileParser(string str)
        {
            string result = str;
            int countSmile = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i < str.Length - 1)
                {

                    if (str[i] == ':' && str[i + 1] == ')')
                    {
                        string smile = "☻";
                        string firstPart = result.Substring(0, i - countSmile);
                        string lastPart = result.Substring(i + 2 - countSmile, str.Length - i - 2);
                        countSmile++;
                        result = string.Format("{0}{1}{2}", firstPart, smile, lastPart);

                    }
                }
            }
            return result;
        }
    }
}

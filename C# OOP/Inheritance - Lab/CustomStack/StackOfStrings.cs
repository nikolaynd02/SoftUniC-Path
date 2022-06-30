using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> collections)
        {
            foreach(var currString in collections)
            {
                base.Push(currString);
            }

            return this;
        }         
    }
}

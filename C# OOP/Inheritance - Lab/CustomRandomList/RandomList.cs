using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random randomNum = new Random();

        public string RandomString()
        {
            int index = randomNum.Next(0, base.Count);

            string random = base[index];

            base.RemoveAt(index);

            return random;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Stationaryphone
    {
        public string Calling(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Dialing... {number}";
            }

            return "Invalid number!";
        }
    }
}

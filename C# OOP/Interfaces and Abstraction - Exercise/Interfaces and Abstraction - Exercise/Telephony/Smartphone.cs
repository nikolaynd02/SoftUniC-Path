using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone
    {
        public string Calling(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Calling... {number}";
            }

            return "Invalid number!";
        }

        public string Browsing(string website)
        {
            if (!website.Any(char.IsDigit))
            {
                return $"Browsing: {website}!";
            }

            return "Invalid URL!";
        }
    }
}

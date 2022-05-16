using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");

            List<string> validNames = new List<string>();

            foreach(string name in names)
            {
                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool valid = name.All(x => char.IsLetterOrDigit(x) || x.Equals('_') || x.Equals('-'));

                    if (valid)
                    {
                        validNames.Add(name);
                    }        
                }
            }

            foreach(string name in validNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace P01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string text = Console.ReadLine();

            MatchCollection validNames = Regex.Matches(text, pattern);

            foreach(var name in validNames)
            {
                Console.Write(name + " ");
            }
        }
    }
}

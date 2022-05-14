using System;
using System.Text.RegularExpressions;

namespace P02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([ |-])2\1\d{3}\1\d{4}\b";

            string phoneNumbers = Console.ReadLine();

            MatchCollection validPhones = Regex.Matches(phoneNumbers, pattern);
            

            Console.WriteLine(string.Join(", ", validPhones));
        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace _02._Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());

            string pattern = @"^([$|%])([A-Z][a-z]{2,})\1: \[([0-9]+)\]\|\[([0-9]+)\]\|\[([0-9]+)\]\|$";

            for (int i = 0; i < numOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    char firstCh = (char)(int.Parse(match.Groups[3].ToString()));
                    char secondCh = (char)(int.Parse(match.Groups[4].ToString()));
                    char thirdCh = (char)(int.Parse(match.Groups[5].ToString()));

                    char[] chars = {firstCh, secondCh, thirdCh };

                    string tag = match.Groups[2].ToString();
                    string result = string.Empty;

                    result = new string(chars);

                    Console.WriteLine($"{tag}: {result}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }

            //if (numOfInputs == 0)
            //{
            //    Console.WriteLine("Valid message not found!");
            //}
        }
    }
}

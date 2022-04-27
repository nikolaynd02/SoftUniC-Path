using System;

namespace P06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetMiddleChar(input));
        }

        static string GetMiddleChar(string word)
        {
            if (((double)word.Length / 2) % 2 != 0 && (double)word.Length % 2 !=0)
            {                
                return word[(word.Length / 2)].ToString();
            }
            else
            {
                return word[(word.Length / 2 - 1)].ToString() + word[word.Length / 2];
            }
        }
    }
}

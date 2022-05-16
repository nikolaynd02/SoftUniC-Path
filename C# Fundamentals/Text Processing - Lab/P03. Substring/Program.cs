using System;

namespace P03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine();
            string rawWord = Console.ReadLine();

            while (rawWord.Contains(removeWord))
            {
                int index = rawWord.IndexOf(removeWord);
                rawWord = rawWord.Remove(index,removeWord.Length);
            }

            Console.WriteLine(rawWord);
        }
    }
}

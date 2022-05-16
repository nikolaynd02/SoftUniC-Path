using System;

namespace P04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach(string word in bannedWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
}

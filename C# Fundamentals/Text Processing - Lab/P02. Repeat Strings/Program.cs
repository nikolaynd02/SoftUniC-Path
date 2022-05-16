using System;

namespace P02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string newWord = string.Empty;

            for(int i = 0; i < words.Length; i++)
            {
                for(int p = 0; p < words[i].Length; p++)
                {
                    newWord += words[i];
                }
            }

            Console.WriteLine(newWord);
        }
    }
}

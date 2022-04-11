using System;
using System.Collections.Generic;

namespace P01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");

            Dictionary<char, int> lettersCount = new Dictionary<char, int>();

            for(int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                for(int p = 0; p < currWord.Length; p++)
                {
                    char currChar = currWord[p];
                    if (!lettersCount.ContainsKey(currChar))
                    {
                        lettersCount[currChar] = 0;
                    }

                    lettersCount[currChar]++;
                }
            }

            foreach(var kvp in lettersCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

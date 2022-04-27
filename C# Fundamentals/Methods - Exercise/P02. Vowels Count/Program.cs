using System;

namespace P02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine(GetNumOfVowels(word));
        }

        static int GetNumOfVowels(string word)
        {
            int vowels = 0;
            for(int i = 0; i < word.Length; i++)
            {
                
                if("AEIOUYaeiouy".IndexOf(word[i]) >= 0)
                {
                    vowels++;
                }
            }

            return vowels;
        }
    }
}

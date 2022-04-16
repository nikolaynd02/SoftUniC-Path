using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach(string word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts.Add(word, 1);
                }
            }

            foreach(var word in counts)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write(word.Key + " ");
                }
            }


        }
    }
}

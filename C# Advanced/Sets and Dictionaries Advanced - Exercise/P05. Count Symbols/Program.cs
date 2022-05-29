using System;
using System.Collections.Generic;

namespace P05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> numOfCh = new SortedDictionary<char, int>();

            foreach(char ch in text)
            {
                if (!numOfCh.ContainsKey(ch))
                {
                    numOfCh[ch] = 1;
                }
                else
                {
                    numOfCh[ch]++;
                }
            }

            foreach(KeyValuePair<char,int> kvp in numOfCh)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}

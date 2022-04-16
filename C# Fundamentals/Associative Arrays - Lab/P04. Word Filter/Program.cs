using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] words = Console.ReadLine().Split();

            //Dictionary<string, int> wordsLenght = new Dictionary<string, int>();

            //foreach(string word in words)
            //{
            //    wordsLenght.Add(word, word.Length);
            //}

            //foreach(var word in wordsLenght)
            //{
            //    if (word.Value % 2 == 0)
            //    {
            //        Console.WriteLine(word.Key);
            //    }
            //}

            string[] words = Console.ReadLine().Split().Where(x => x.Length%2==0).ToArray();

            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}

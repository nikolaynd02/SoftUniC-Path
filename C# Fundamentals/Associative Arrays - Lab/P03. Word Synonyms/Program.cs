using System;
using System.Collections.Generic;

namespace P03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairs = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for(int i = 0; i < pairs; i++)
            {
                string keyWord = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!synonyms.ContainsKey(keyWord))
                {
                    synonyms.Add(keyWord, new List<string>());
                    synonyms[keyWord].Add(synonym);
                }
                else
                {
                    synonyms[keyWord].Add(synonym);
                }
            }

            foreach(var synonim in synonyms)
            {
                Console.WriteLine($"{synonim.Key} - {string.Join(", ", synonim.Value)}");
            }


        }
    }
}

using System;
using System.Collections.Generic;

namespace P03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for(int i = 0; i < inputs; i++)
            {
                string[] compounds = Console.ReadLine().Split();
                foreach(string element in compounds)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

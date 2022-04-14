using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();

            string name = string.Empty;

            while((name = Console.ReadLine()) != "End")
            {
                if(name == "Paid")
                {
                    while (people.Count > 0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(name);
                }
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}

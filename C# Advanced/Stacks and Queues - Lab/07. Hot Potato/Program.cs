using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();

            int timer = int.Parse(Console.ReadLine());

            Queue<string> names = new Queue<string>();

            foreach(string kid in kids)
            {
                names.Enqueue(kid);
            }

            int count = 1;

            while (names.Count > 1)
            {
                if (count % timer == 0)
                {
                    Console.WriteLine($"Removed {names.Dequeue()}");
                }
                else
                {
                    names.Enqueue(names.Dequeue());
                }
                count++;
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}

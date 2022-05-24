using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numsToAdd = numbers[0];
            int numsToRemove = numbers[1];
            int numToSerch = numbers[2];

            int[] toAdd = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();

            Queue<int> numbersInQ = new Queue<int>();

            while (numsToAdd != 0)
            {
                numbersInQ.Enqueue(toAdd[numsToAdd-1]);
                numsToAdd--;
            }

            while (numsToRemove != 0 && numbersInQ.Count() != 0)
            {
                numbersInQ.Dequeue();
                numsToRemove--;
            }

            if (numbersInQ.Contains(numToSerch))
            {
                Console.WriteLine("true");
                return;
            }

            if(numbersInQ.Count() == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int lowest = int.MaxValue;

            while(numbersInQ.Count() > 0)
            {
                if (numbersInQ.Peek() < lowest)
                {
                    lowest = numbersInQ.Dequeue();
                }
                else
                {
                    numbersInQ.Dequeue();
                }
            }

            Console.WriteLine(lowest);
        }
    }
}

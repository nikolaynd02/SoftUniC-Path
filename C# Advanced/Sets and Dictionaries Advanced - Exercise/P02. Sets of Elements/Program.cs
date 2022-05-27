using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for(int i = 0; i < numbers.Sum(); i++)
            {
                if (i < numbers[0])
                {
                    firstSet.Add(int.Parse(Console.ReadLine()));
                }
                else
                {
                    secondSet.Add(int.Parse(Console.ReadLine()));
                }
            }

            foreach(int num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}

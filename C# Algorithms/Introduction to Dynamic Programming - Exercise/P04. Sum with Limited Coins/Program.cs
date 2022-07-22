using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Sum_with_Limited_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSums(numbers, target));
        }

        private static int CountSums(int[] numbers, int target)
        {
            HashSet<int> sums = new HashSet<int> { 0 };

            int counter = 0;

            foreach (int number in numbers)
            {
                HashSet<int> newSums = new HashSet<int>();
                foreach(int sum in sums)
                {
                    int newSum = sum + number;
                    if(newSum == target)
                    {
                        counter++;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return counter;
        }
    }
}

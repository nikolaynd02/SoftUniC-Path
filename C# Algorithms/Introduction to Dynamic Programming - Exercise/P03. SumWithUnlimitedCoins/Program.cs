using System;
using System.Linq;

namespace P03._SumWithUnlimitedCoins
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
            int[] sums = new int[target + 1];
            sums[0] = 1;

            foreach(int number in numbers)
            {
                for(int i = number; i <= target; i++)
                {
                    sums[i] += sums[i - number];
                }
            }

            return sums[target];
        }
    }
}

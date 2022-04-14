using System;
using System.Linq;

namespace Ex._06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int sumEven = 0;
            int sumOdd = 0;

            foreach(int currNumber in nums)
            {
                if (currNumber % 2 == 0)
                {
                    sumEven += currNumber;
                }
                else
                {
                    sumOdd += currNumber;
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}

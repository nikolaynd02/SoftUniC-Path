using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Dividing_Presents
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int alanSum = arr.Sum() / 2;

            int totalSum = arr.Sum();

            var sums = WriteSplit(arr);

            while (true)
            {
                if (sums.ContainsKey(alanSum))
                {
                    int bobSum = totalSum - alanSum;
                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {GetAlanNums(sums, alanSum)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }

                alanSum--;
            }
        }

        private static string GetAlanNums(Dictionary<int, int> sums, int alanSum)
        {
            List<int> alanNums = new List<int>();

            while(alanSum != 0)
            {
                int num = sums[alanSum];
                alanNums.Add(num);
                alanSum -= num;
            }

            return string.Join(" ", alanNums);
        }

        private static Dictionary<int, int> WriteSplit(int[] arr)
        {
            var sums = new Dictionary<int, int> { {0, 0 } };

            foreach(var number in arr)
            {
                var currSums = sums.Keys.ToArray();
                foreach(var sum in currSums)
                {
                    var newSum = sum + number;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }
                    sums.Add(newSum, number);

                }
            }

            return sums;
        }
    }
}

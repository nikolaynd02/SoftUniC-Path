using System;
using System.Linq;

namespace Ex._07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] nums2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int diff= -1;
            int sum =0;
            bool difference = false;
            for(int i = 0; i < nums1.Length; i++)
            {
                if (difference && diff != (-1))
                {

                }
                else if (nums1[i] == nums2[i])
                {
                    sum += nums1[i];
                }
                else
                {
                    difference = true;
                    diff=i;
                }
            }

            if (difference)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {diff} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}

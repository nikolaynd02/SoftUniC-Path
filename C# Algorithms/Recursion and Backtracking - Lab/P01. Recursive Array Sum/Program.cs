using System;
using System.Linq;

namespace P01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(arr,0));
        }

        private static int GetSum(int[] arr,int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);
        }
    }
}

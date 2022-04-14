using System;
using System.Linq;

namespace Ex._08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = arr.Length;
            while (counter != 1)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i] + arr[i + 1];
                }
                arr[counter - 1] = 0;
                counter--;
            }
            Console.WriteLine(arr[0]);

        }
    }
}

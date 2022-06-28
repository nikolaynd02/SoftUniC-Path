using System;

namespace P03._Generating_0_or_1_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrLenght = int.Parse(Console.ReadLine());

            int[] arr = new int[arrLenght];

            GenAllOneZeroVectors(arr, 0);
        }

        private static void GenAllOneZeroVectors(int[] arr,int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }


            for(int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                GenAllOneZeroVectors(arr, index + 1);
            }
        }
    }
}

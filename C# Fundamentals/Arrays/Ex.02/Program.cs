using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Writing values in an array
            //int arrLenght = int.Parse(Console.ReadLine());
            //int[] arr = new int[arrLenght];
            //for(int i = 0; i < arrLenght; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            // Reading array values from single line, separated by space
            //string values = Console.ReadLine();
            //string[] numbers = values.Split();
            //int[] arr = new int[numbers.Length];

            //for(int i = 0; i < numbers.Length; i++)
            //{
            //    arr[i] = int.Parse(numbers[i]);
            //}

            // Same but shorter, using System.Linq
            //string input = Console.ReadLine();
            //string[] items = input.Split(' ');
            //int[] arr = items.Select(int.Parse).ToArray();

            // even shorter with System.Linq
            //int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            // Printing an array reversed
            //int i = arr.Length;
            //for(int index = arr.Length; index > 0; index--)
            //{
            //    i--;
            //    Console.WriteLine(arr[i]);
            //}

            int nums = int.Parse(Console.ReadLine());
            int[] arrOfNums = new int[nums];
            for(int i = 0; i < arrOfNums.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                arrOfNums[i] = number;
            }
            for(int i = arrOfNums.Length - 1; i >= 0; i--)
            {
                Console.Write(arrOfNums[i]+" ");
            }


        }
    }
}

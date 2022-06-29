using System;
using System.Collections.Generic;

namespace P07._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetNum = int.Parse(Console.ReadLine());

            List<int> fibonacciNums = new List<int>();

            fibonacciNums.Add(1);
            fibonacciNums.Add(1);


            Console.WriteLine(GetFibonacci(targetNum, fibonacciNums));
        }


        private static int GetFibonacci(int target, List<int> fibNums)
        {
            if(fibNums.Count - 1 == target || target == 0)
            {
                return fibNums[target];
            }


            fibNums.Add(fibNums[fibNums.Count - 2] + fibNums[fibNums.Count - 1]);


            GetFibonacci(target, fibNums);

            return fibNums[target];

        }
    }
}

using System;

namespace P03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibNum = int.Parse(Console.ReadLine());
            int[] fibArr = new int[fibNum+2];
            fibArr[0] = 1;
            fibArr[1] = 1;
            for(int i = 2; i < fibArr.Length && fibNum > 2; i++)
            {
                fibArr[i] = fibArr[i - 1] + fibArr[i - 2];
            }
            Console.WriteLine(fibArr[fibNum-1]);
        }
    }
}

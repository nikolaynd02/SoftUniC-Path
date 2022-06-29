using System;

namespace P04._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorial(n));
        }

        private static int GetFactorial(int n)
        {
            if(n==1 || n == 0)
            {
                return 1;
            }

            return n * GetFactorial(n - 1);
        }
    }
}

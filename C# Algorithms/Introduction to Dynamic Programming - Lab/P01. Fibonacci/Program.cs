using System;
using System.Collections.Generic;

namespace P01._Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> fibValues = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int targetFib = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFib(targetFib));

        }

        private static long GetFib(int targetFib)
        {
            if (fibValues.ContainsKey(targetFib))
            {
                return fibValues[targetFib];
            }
            if (targetFib < 2)
            {
                return targetFib;
            }

            long result = GetFib(targetFib - 1) + GetFib(targetFib - 2);

            fibValues.Add(targetFib, result);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;

namespace P01._Binomial_Coefficients
{
    class Program
    {
        private static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinomial(row, col));

        }

        private static long GetBinomial(int row, int col)
        {
            if(col == 0 || row == col)
            {
                return 1;
            }

            string key = $"{row}:{col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            long result = GetBinomial(row - 1, col - 1) + GetBinomial(row - 1, col);

            cache.Add(key, result);

            return result;
        }
    }
}

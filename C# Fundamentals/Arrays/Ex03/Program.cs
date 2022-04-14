using System;
using System.Linq;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbersForRounding = Console.ReadLine().Split().Select(double.Parse).ToArray();

            int[] roundedNums = new int[numbersForRounding.Length];
            for(int i = 0; i < roundedNums.Length; i++)
            {
                roundedNums[i] = (int)Math.Round(numbersForRounding[i], MidpointRounding.AwayFromZero);
            }

            for(int i = 0; i < roundedNums.Length; i++)
            {
                Console.WriteLine($"{Convert.ToDecimal(numbersForRounding[i])} => {Convert.ToDecimal(roundedNums[i])}");
            }
        }
    }
}

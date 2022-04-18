using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Happy_Three_Friends
{
    class Program
    {
        static void Main(string[] args) // No idea
        {
            int boxesOfWine = int.Parse(Console.ReadLine());

            for(int i = 0; i < boxesOfWine; i++)
            {
                int[] prices = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (prices.Sum() % 3 != 0)
                {
                    Console.WriteLine("No");
                    continue;
                }

                
            }
        }
    }
}

using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int days = 0;
            int spiceExtracted = 0;

            for(int minimunYield = 100; minimunYield <= startingYield; startingYield -= 10)
            {
                spiceExtracted += startingYield - 26;
                days++;
            }
            spiceExtracted -= 26;
            Console.WriteLine(days);
            if (spiceExtracted < 0)
            {
                spiceExtracted = 0;
            }
            Console.WriteLine(spiceExtracted);
        }
    }
}

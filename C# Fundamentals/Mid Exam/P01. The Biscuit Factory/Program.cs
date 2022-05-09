using System;

namespace P01._The_Biscuit_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int competitorProduction = int.Parse(Console.ReadLine());

            int totalProduction = 0;

            for(int i = 1; i <= 30; i++)
            {
                double todayProd = biscuitsPerWorker * workers;

                if (i % 3 == 0)
                {
                    todayProd = Math.Floor(todayProd * 0.75);
                }

                totalProduction += (int)todayProd;
            }

            Console.WriteLine($"You have produced {totalProduction} biscuits for the past month.");

            if (totalProduction > competitorProduction)
            {
                Console.WriteLine($"You produce {((double)totalProduction / competitorProduction * 100) - 100:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {100 - (double)totalProduction / competitorProduction * 100:f2} percent less biscuits.");
            }

        }
    }
}

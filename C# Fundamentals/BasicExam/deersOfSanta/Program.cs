using System;

namespace deersOfSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double deerOneCPD = double.Parse(Console.ReadLine());
            double deerTwoCPD = double.Parse(Console.ReadLine());
            double deerThreeCPD = double.Parse(Console.ReadLine());

            double totalConsumtion = days * (deerOneCPD + deerTwoCPD + deerThreeCPD);

            if (food < totalConsumtion)
            {
                Console.WriteLine($"{Math.Ceiling(totalConsumtion - food)} more kilos of food are needed.");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(food - totalConsumtion)} kilos of food left.");
            }


        }
    }
}

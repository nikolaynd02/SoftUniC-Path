using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double lightssaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double total = 0;

            double lightsabers = students * lightssaberPrice;
            double addLightsabers = students / 10;
            addLightsabers = Math.Ceiling(addLightsabers);
            lightsabers += addLightsabers * lightssaberPrice;
            
            double robes = students * robePrice;

            double belts = 0;
            for(int i = 1; i <= students; i++)
            {
                if (i % 6 != 0)
                {
                    belts += beltPrice;
                }
            }

            total = lightsabers + robes + belts;
            

            if (budget >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {total - budget:f2}lv more.");
            }

        }
    }
}

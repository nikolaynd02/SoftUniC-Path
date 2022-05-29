using System;
using System.Collections.Generic;

namespace P06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for(int i = 0; i < inputs; i++)
            {
                string input = Console.ReadLine();

                string color = input
                    .Split(" -> ")
                    [0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                string[] clothes = input.Split(" -> ")[1].Split(",");

                foreach(var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 0;
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] searchFor = Console.ReadLine().Split();
            string searchColor = searchFor[0];
            string searchCloth = searchFor[1];

            foreach(var color in wardrobe)
            {
                //Dictionary<string, int> clothes = color.Value;

                Console.WriteLine($"{color.Key} clothes:");

                foreach(var cloth in color.Value)
                {
                    if(color.Key == searchColor && cloth.Key == searchCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}

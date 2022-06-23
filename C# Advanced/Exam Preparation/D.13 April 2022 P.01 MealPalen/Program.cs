using System;
using System.Collections.Generic;
using System.Linq;

namespace D._13_April_2022_P._01_MealPalen
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> meals = new Dictionary<string, int>()
            {
                ["salad"] = 350,
                ["soup"] = 490,
                ["pasta"] = 680,
                ["steak"] = 790
            };

            Queue<string> allowedMeals = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            var caloriesTarget = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int mealsEaten = 0;

            while (allowedMeals.Count != 0 && caloriesTarget.Sum() > 0)
            {
                int currCalTarget = caloriesTarget.Count - 1;

                caloriesTarget[currCalTarget] -= meals[allowedMeals.Dequeue()];
                mealsEaten++;

                if (caloriesTarget[currCalTarget] <= 0 && caloriesTarget.Sum() > 0)
                {

                    caloriesTarget[currCalTarget - 1] += caloriesTarget[currCalTarget];
                    caloriesTarget.RemoveAt(currCalTarget);
                }
            }

            caloriesTarget.Reverse();
            if (allowedMeals.Count == 0)
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesTarget)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", allowedMeals)}.");
            }

        }
    }
}

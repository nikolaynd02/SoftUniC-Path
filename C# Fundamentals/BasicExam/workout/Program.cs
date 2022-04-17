using System;

namespace workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double kilomiters = double.Parse(Console.ReadLine());

            int target = 1000;
            double distanceRun = kilomiters;


            for(int currentDay = 1; currentDay <= days; currentDay++)
            {
                double increase = double.Parse(Console.ReadLine());

                kilomiters =kilomiters+ kilomiters*increase / 100;
                distanceRun += kilomiters;

            }

            if (distanceRun >= target)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(distanceRun - target) } more kilometers!");
                                   
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(target - distanceRun)} more kilometers");
            }

            
        }
    }
}

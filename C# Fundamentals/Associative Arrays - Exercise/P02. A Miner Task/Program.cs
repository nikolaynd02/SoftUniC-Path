using System;
using System.Collections.Generic;

namespace P02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourcesQuantity = new Dictionary<string, int>();

            string resource = string.Empty;

            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resourcesQuantity.ContainsKey(resource))
                {
                    resourcesQuantity[resource] = 0;
                }

                resourcesQuantity[resource] += quantity;
            }

            foreach(var kvp in resourcesQuantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

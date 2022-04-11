using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            const int materialNeeded = 250;

            Dictionary<string, int> valuableMaterials = new Dictionary<string, int>
            {
                {"shards", 0 },
                {"motes", 0 },
                {"fragments", 0 }
            };

            Dictionary<string, int> trashMaterials = new Dictionary<string, int>();

            Dictionary<string, string> legenderyItems = new Dictionary<string, string>
            {
                {"shards","Shadowmourne" },
                {"fragments", "Valanyr" },
                {"motes", "Dragonwrath" }
            };

            string createdItem = string.Empty;

            while (String.IsNullOrEmpty(createdItem))
            {
                string[] input = Console.ReadLine().ToLower().Split();

                for(int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string typeOfMaterial = input[i + 1];

                    if (valuableMaterials.ContainsKey(typeOfMaterial))
                    {
                        valuableMaterials[typeOfMaterial] +=quantity;
                        if (valuableMaterials[typeOfMaterial] >= materialNeeded)
                        {
                            valuableMaterials[typeOfMaterial] -= materialNeeded;
                            createdItem = legenderyItems[typeOfMaterial];
                            break;
                        }
                    }
                    else
                    {
                        if (!trashMaterials.ContainsKey(typeOfMaterial))
                        {
                            trashMaterials[typeOfMaterial] = 0;
                        }

                        trashMaterials[typeOfMaterial] += quantity;
                    }
                }
            }

            Console.WriteLine($"{createdItem} obtained!");
            foreach(var valuabelPair in valuableMaterials)
            {
                Console.WriteLine($"{valuabelPair.Key}: {valuabelPair.Value}");
            }
            if (trashMaterials.Count > 0)
            {
                foreach(var trashpair in trashMaterials)
                {
                    Console.WriteLine($"{trashpair.Key}: {trashpair.Value}");
                }
            }
        }
    }
}

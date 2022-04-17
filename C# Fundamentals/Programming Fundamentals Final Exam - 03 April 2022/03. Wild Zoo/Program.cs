using System;
using System.Collections.Generic;

namespace _03._Wild_Zoo
{
    class Animal
    {
        public string Name { get; set; }

        public int Food { get; set; }

        public string Area { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<Animal>> areas = new Dictionary<string, List<Animal>>();

            while((input = Console.ReadLine()) != "EndDay")
            {
                string[] cmdInfo = input.Split(": ");

                string cmdType = cmdInfo[0];

                if (cmdType == "Add")
                {
                    string[] animalInfo = cmdInfo[1].Split("-", StringSplitOptions.RemoveEmptyEntries);

                    string animalName = animalInfo[0];
                    int animalFood = int.Parse(animalInfo[1]);
                    string animalArea = animalInfo[2];

                    Animal currAnimal = new Animal
                    {
                        Name = animalName,
                        Food = animalFood,
                        Area = animalArea
                    };

                    if (areas.ContainsKey(animalArea))
                    {
                        int animalIndex = areas[animalArea].FindIndex(x => x.Name == animalName);
                        if (animalIndex >= 0)
                        {
                            areas[animalArea][animalIndex].Food += currAnimal.Food;
                        }
                        else
                        {
                            areas[animalArea].Add(currAnimal);
                        }
                    }
                    else
                    {
                        areas.Add(animalArea, new List<Animal> { currAnimal });
                    }


                }
                else if(cmdType == "Feed")
                {
                    string[] feedInfo = cmdInfo[1].Split("-", StringSplitOptions.RemoveEmptyEntries);

                    string animalToFeed = feedInfo[0];
                    int foodGiven = int.Parse(feedInfo[1]);

                    foreach(var area in areas)
                    {
                        int animalIndex = area.Value.FindIndex(x => x.Name == animalToFeed);
                        if (animalIndex >= 0)
                        {
                            area.Value[animalIndex].Food -= foodGiven;
                            if (area.Value[animalIndex].Food <= 0)
                            {
                                Console.WriteLine($"{area.Value[animalIndex].Name} was successfully fed");
                                area.Value.RemoveAt(animalIndex);
                            }
                            break;
                        }
                    }                   

                }
            }

            Console.WriteLine("Animals: ");

            foreach(var area in areas)
            {
                 foreach(var animal in area.Value)
                 {
                    if (animal.Food > 0)
                    {
                        Console.WriteLine($" {animal.Name} -> {animal.Food}g");
                    }
                 }
            }


            Console.WriteLine("Areas with hungry animals:");
            foreach(var area in areas)
            {
                int hungryAnimals = 0;
                foreach (var animal in area.Value)
                {
                    if (animal.Food > 0)
                    {
                        hungryAnimals++;
                    }
                }

                if (hungryAnimals > 0)
                {
                    Console.WriteLine($" {area.Key}: {hungryAnimals}");
                }
            }
        }
    }
}

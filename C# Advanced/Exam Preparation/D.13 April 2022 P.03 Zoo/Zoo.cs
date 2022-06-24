using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {        

        public readonly List<Animal> Animals = new List<Animal>();

        private string name;
        private int capacity;

        public Zoo(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string AddAnimal(Animal animal)
        {
            if(animal.Species is null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            else if(animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if(Animals.Count >= capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }       
        }

        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(x => x.Species == species);
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.Find(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach(var currAnimal in Animals)
            {
                if (currAnimal.Lenght <= maximumLength && currAnimal.Lenght >= minimumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

    }
}

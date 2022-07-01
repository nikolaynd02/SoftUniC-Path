using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string cmd = string.Empty; 

            while ((cmd = Console.ReadLine()) != "Beast!")
            {
                string animalType = cmd;

                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {

                    if(animalType.ToLower() == "dog")
                    {
                        animals.Add(new Dog(name, age, gender));
                    }
                    else if(animalType.ToLower() == "cat")
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    else if(animalType.ToLower() == "kitten")
                    {
                        animals.Add(new Kitten(name, age));
                    }
                    else if(animalType.ToLower() == "tomcat")
                    {
                        animals.Add(new Tomcat(name, age));
                    }
                    else
                    {
                        animals.Add(new Frog(name, age, gender));
                    }
                }

            }

            foreach (Animal currAnimal in animals)
            {
                Console.WriteLine(currAnimal.GetType().ToString().Split(".")[1]);
                Console.WriteLine($"{currAnimal.Name} {currAnimal.Age} {currAnimal.Gender}");
                Console.WriteLine(currAnimal.ProduceSound());
            }
        }
    }
}

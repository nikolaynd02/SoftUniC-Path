using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Order_by_Age
{
    class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string ID = info[1];
                int age = int.Parse(info[2]);

                int indexForCheck = people.FindIndex(x => x.ID == ID);

                if (indexForCheck >= 0)
                {
                    people[indexForCheck].Name = name;
                    people[indexForCheck].Age = age;
                }
                else
                {
                    Person newPerson = new Person()
                    {
                        Name = name,
                        ID = ID,
                        Age = age
                    };

                    people.Add(newPerson);
                }

                input = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (Person currPerson in people)
            {
                Console.WriteLine($"{currPerson.Name} with ID: {currPerson.ID} is {currPerson.Age} years old.");
            }
        }
    }
}

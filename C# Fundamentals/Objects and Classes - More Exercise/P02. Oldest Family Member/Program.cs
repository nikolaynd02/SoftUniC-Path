using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Oldest_Family_Member
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Family
    {
        List<Person> Members = new List<Person>();

        public void AddMember(Person newMember)
        {
            Members.Add(newMember);
        }

        public void PrintOldestMember()
        {
            Person oldestPerson = Members.OrderByDescending(p => p.Age).First();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}" );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            Family family = new Family();

            for(int i = 0; i < people; i++)
            {
                string[] personinfo = Console.ReadLine().Split(" ");
                Person newPerson = new Person
                {
                    Name = personinfo[0],
                    Age = int.Parse(personinfo[1])
                };

                family.AddMember(newPerson);
            }          
            family.PrintOldestMember();
        }
    }
}

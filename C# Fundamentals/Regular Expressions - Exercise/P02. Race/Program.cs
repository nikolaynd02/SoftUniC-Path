using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Race
{
    class Person
    {
        public string Name { get; set; }

        public int Distance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();

            List<Person> personRanking = new List<Person>();

            foreach(string name in names)
            {
                personRanking.Add(new Person { Name = name, Distance = 0 });
            }

            string input = string.Empty;

            while((input = Console.ReadLine())!="end of race")
            {
                string name = "";
                int distance = 0;

                foreach(char ch in input)
                {
                  
                    if (char.IsLetter(ch))
                    {
                        name += ch;
                    }
                    else if (char.IsDigit(ch))
                    {
                        distance += int.Parse(char.ToString(ch));
                    }
                }

                int index = personRanking.FindIndex(x => x.Name == name);

                if (index>=0)
                {
                    personRanking[index].Distance += distance;
                }
            }

            personRanking = personRanking.OrderByDescending(x => x.Distance).ToList();

            int place = 1;

            foreach(Person currPerson in personRanking)
            {
                if (place == 1)
                {
                    Console.WriteLine($"1st place: {currPerson.Name}");
                }
                else if(place == 2)
                {
                    Console.WriteLine($"2nd place: {currPerson.Name}");
                }
                else if(place == 3)
                {
                    Console.WriteLine($"3rd place: {currPerson.Name}");
                    break;
                }

                place++;
            }
        }
    }
}

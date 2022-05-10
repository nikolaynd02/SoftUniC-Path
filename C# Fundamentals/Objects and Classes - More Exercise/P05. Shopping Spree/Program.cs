using System;
using System.Collections.Generic;

namespace P05._Shopping_Spree
{
    class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
    class Person
    {
        public string Name { get; set; }

        public double Money { get; set; }

        public List<string> Bag = new List<string>();
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] infoForCustomers = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            foreach(string currPerson in infoForCustomers)
            {
                string[] currPersoninfo = currPerson.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = currPersoninfo[0];
                double budget = double.Parse(currPersoninfo[1]);

                Person newPerson = new Person()
                {
                    Name = name,
                    Money = budget
                };
                people.Add(newPerson);
            }

            string[] infoForProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Product> products = new List<Product>();

            foreach(string currProduct in infoForProducts)
            {
                string[] currProductInfo = currProduct.Split("=",StringSplitOptions.RemoveEmptyEntries);
                string productName = currProductInfo[0];
                double productPrice = double.Parse(currProductInfo[1]);

                Product newProduct = new Product()
                {
                    Name = productName,
                    Price = productPrice
                };
                products.Add(newProduct);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] order = input.Split(" ");
                string person = order[0];
                string product = order[1];

                int personIndex = people.FindIndex(x => x.Name == person);
                int productIndex = products.FindIndex(x => x.Name == product);

                if (people[personIndex].Money >= products[productIndex].Price)
                {
                    people[personIndex].Bag.Add(product);
                    people[personIndex].Money -= products[productIndex].Price;
                    Console.WriteLine($"{person} bought {product}");
                }
                else
                {
                    Console.WriteLine($"{person} can't afford {product}");
                }

                input = Console.ReadLine();
            }

            foreach(Person currPerson in people)
            {
                if (currPerson.Bag.Count > 0)
                {
                    Console.Write($"{currPerson.Name} - " + string.Join(", ", currPerson.Bag)); 
                }
                else
                {
                    Console.Write($"{currPerson.Name} - Nothing bought");
                }
                Console.WriteLine();
            }
        }
    }
}

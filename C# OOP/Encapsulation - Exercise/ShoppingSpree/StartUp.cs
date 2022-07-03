using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                foreach(string currPersonInfo in peopleInfo)
                {
                    string[] info = currPersonInfo.Split("=",StringSplitOptions.RemoveEmptyEntries);

                    string name = info[0];
                    decimal money = decimal.Parse(info[1]);

                    Person newPerson = new Person(name, money);

                    people.Add(newPerson);
                }

                foreach (string currProductInfo in productInfo)
                {
                    string[] info = currProductInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = info[0];
                    decimal cost = decimal.Parse(info[1]);

                    Product newProduct = new Product(name, cost);

                    products.Add(newProduct);
                }
            }
            catch(ArgumentException arg)
            {
                Console.WriteLine(arg.Message);
                return;
            }

            string input = string.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = people.Find(x => x.Name == info[0]);
                Product product = products.Find(x => x.Name == info[1]);

                person.Buy(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}

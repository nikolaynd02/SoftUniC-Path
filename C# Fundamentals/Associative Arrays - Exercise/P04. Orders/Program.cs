using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Orders
{
    class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] productInfo = input.Split(" ");

                string productName = productInfo[0];
                double productPrice = double.Parse(productInfo[1]);
                int productQuantity = int.Parse(productInfo[2]);

                int productIndex = products.FindIndex(x => x.Name == productName);

                if(productIndex>=0)
                {
                    products[productIndex].Price = productPrice;
                    products[productIndex].Quantity += productQuantity;
                }
                else
                {
                    Product newProduct = new Product
                    {
                        Name = productName,
                        Price = productPrice,
                        Quantity = productQuantity
                    };
                    products.Add(newProduct);
                }

                input = Console.ReadLine();
            }

            foreach(Product currProduct in products)
            {
                Console.WriteLine($"{currProduct.Name} -> {currProduct.Price * currProduct.Quantity:f2}");
            }
        }
    }
}

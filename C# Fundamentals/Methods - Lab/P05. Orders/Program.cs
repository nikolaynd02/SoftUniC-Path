using System;

namespace P05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            CalculatePrice(product, quantity);
        }

        static void CalculatePrice(string product,int quantity)
        {
            switch (product)
            {
                case "coffee":
                    Console.WriteLine($"{quantity * 1.50:f2}");
                    break;
                case "water":
                    Console.WriteLine($"{quantity * 1.00:f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{quantity * 1.40:f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{quantity * 2.00:f2}");
                    break;
            }
        }
    }
}

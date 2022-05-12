using System;

namespace P01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalSum = 0;

            while (input != "special" && input != "regular")
            {
                double currPrice = double.Parse(input);

                if (currPrice < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    totalSum += currPrice;
                }

                input = Console.ReadLine();
            }

            double priceWithoutTax = totalSum;
            double Tax = totalSum * 0.2;
            totalSum += Tax;

            if (input == "special")
            {
                totalSum -= totalSum * 0.1;
            }

            if (totalSum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!\nPrice without taxes: {priceWithoutTax:f2}$\nTaxes: {Tax:f2}$\n-----------\nTotal price: {totalSum:f2}$");
            }
        }
    }
}

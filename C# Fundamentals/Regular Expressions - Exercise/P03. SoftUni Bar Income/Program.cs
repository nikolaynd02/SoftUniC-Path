using System;
using System.Text.RegularExpressions;

namespace P03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            double total = 0;

            string input = string.Empty;

            while((input = Console.ReadLine()) != "end of shift")
            {
                Match order = Regex.Match(input, pattern);

                if (order.Success)
                {
                    string customer = order.Groups["customer"].Value;
                    string product = order.Groups["product"].Value;
                    double price = double.Parse(order.Groups["count"].Value) * double.Parse(order.Groups["price"].Value);
                    Console.WriteLine($"{customer}: {product} - {price:f2}");

                    total += price;
                }
            }

            Console.WriteLine($"Total income: {total:f2}");

        }
    }
}

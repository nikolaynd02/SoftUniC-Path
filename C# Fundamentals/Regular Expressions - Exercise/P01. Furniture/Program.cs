using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<item>[A-Z][A-Z|[a-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            string input = string.Empty;

            List<string> items = new List<string>();

            double total = 0;

            while((input=Console.ReadLine())!= "Purchase")
            {
                Match info = Regex.Match(input, pattern);

                if (info.Success)
                {
                    var name = info.Groups["item"].Value;
                    items.Add(name);
                    var currItemPrice = double.Parse(info.Groups["price"].Value);
                    var quantity = int.Parse(info.Groups["quantity"].Value);
                    total += currItemPrice * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            if (items.Count > 0)
            {
                Console.WriteLine($"{string.Join(Environment.NewLine, items)}");
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}

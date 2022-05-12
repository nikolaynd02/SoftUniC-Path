using System;
using System.Text.RegularExpressions;

namespace P02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string patter = @"@#{1,}(?<item>[A-Z][A-Za-z0-9}]{4,}[A-Z])@#{1,}";

            int numOfBarcodes = int.Parse(Console.ReadLine());

            for(int i = 0; i < numOfBarcodes; i++)
            {              
                string productGroup = string.Empty;

                Match barcode = Regex.Match(Console.ReadLine(), patter);

                if (!barcode.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                foreach (char currCh in barcode.Value)
                {
                    if (currCh >= '0' && currCh <= '9')
                    {
                        productGroup += currCh;
                    }
                }

                if (productGroup.Length == 0)
                {
                    productGroup = "00";
                }

                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}

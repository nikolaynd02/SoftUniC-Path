using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());

            double totalSum = 0;

            for(int i = 1; i <= orders; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsules = int.Parse(Console.ReadLine());

                double sum = capsulePrice * days * capsules;
                totalSum += sum;

                Console.WriteLine($"The price for the coffee is: ${sum:f2}");
            }

            Console.WriteLine($"Total: ${totalSum:f2}");
        }
    }
}

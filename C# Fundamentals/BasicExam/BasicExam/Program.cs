using System;

namespace BasicExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int tourists = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int transportPass = int.Parse(Console.ReadLine());
            int museumPass = int.Parse(Console.ReadLine());

            double nightPrice = 20.00;
            double transportPrice = 1.60;
            double museumPrice = 6.00;

            double total = tourists *( nights * nightPrice + transportPass * transportPrice + museumPass * museumPrice);
            total += total / 4;
            Console.WriteLine($"{total:f2}");

        }
    }
}

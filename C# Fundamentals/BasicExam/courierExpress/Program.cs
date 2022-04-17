using System;

namespace courierExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string option = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());

            double pricePerKm = 0;
            double additionalfee = 0;
            if (weight < 1)
            {
                pricePerKm = 0.03;
                switch (option)
                {
                    case "express":
                        additionalfee = (0.80 * pricePerKm ) * weight * distance;
                        break;
                }
            }
            else if (weight < 10)
            {
                pricePerKm = 0.05;
                switch (option)
                {
                    case "express":
                        additionalfee = (0.40 * pricePerKm ) * weight * distance;
                        break;
                }
            }
            else if (weight < 40)
            {
                pricePerKm = 0.10;
                switch (option)
                {
                    case "express":
                        additionalfee = (0.05 * pricePerKm ) * weight * distance;
                        break;
                }
            }
            else if (weight < 90)
            {
                pricePerKm = 0.15;
                switch (option)
                {
                    case "express":
                        additionalfee = (0.02 * pricePerKm) * weight * distance ;
                        break;
                }
            }
            else if (weight < 150)
            {
                pricePerKm = 0.20;
                switch (option)
                {
                    case "express":
                        additionalfee = (0.01 * pricePerKm ) * weight*distance;
                        break;
                }
            }

            double total = pricePerKm * distance+additionalfee;

            Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {total:f2} lv.");


        }
    }
}

using System;

namespace excursionSale
{
    class Program
    {
        static void Main(string[] args)
        {
            int seaVacations = int.Parse(Console.ReadLine());
            int mountainVacations = int.Parse(Console.ReadLine());

            int sea = 680;
            int mountaint = 499;

            int total = 0;
            bool sold = false;

            string input = Console.ReadLine();

            while (input != "Stop")
            {

                switch (input)
                {
                    case "sea":
                        if (seaVacations != 0)
                        {
                            seaVacations--;
                            total += sea;
                        }
                        break;
                    case "mountain":
                        if (mountainVacations != 0)
                        {
                            mountainVacations--;
                            total += mountaint;
                        }
                        break;

                }

                if (seaVacations == 0 && mountainVacations == 0)
                {
                    sold = true;
                    break;
                }

                input = Console.ReadLine();

            }
            if (sold)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }
            Console.WriteLine($"Profit: {total} leva.");

        }
    }
}

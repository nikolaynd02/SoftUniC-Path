using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();

            double sum=0;
            
            switch (day)
            {
                case "Friday":
                    switch (group)
                    {
                        case "Students":
                            sum = 8.45 * people;
                            break;
                        case "Business":
                            sum = 10.90 * people;
                            break;
                        case "Regular":
                            sum = 15 * people;
                            break;
                    }
                    break;
                case "Saturday":
                    switch (group)
                    {
                        case "Students":
                            sum = 9.80 * people;
                            break;
                        case "Business":
                            sum = 15.60 * people;
                            break;
                        case "Regular":
                            sum = 20 * people;
                            break;
                    }
                    break;
                case "Sunday":
                    switch (group)
                    {
                        case "Students":
                            sum = 10.46 * people;
                            break;
                        case "Business":
                            sum = 16 * people;
                            break;
                        case "Regular":
                            sum = 22.50 * people;
                            break;
                    }
                    break;
            }

            if (group == "Students" && people >= 30)
            {
                sum = sum - sum * 15 / 100;
            }
            else if (group == "Business" && people >= 100&&day=="Friday")
            {
                sum = sum - 10 * 10.90;
            }
            else if (group == "Business" && people >= 100 && day == "Saturday")
            {
                sum = sum - 10 * 15.60;
            }
            else if (group == "Business" && people >= 100 && day == "Sunday")
            {
                sum = sum - 10 * 16;
            }
            else if (group == "Regular" && people >= 10 && people <= 20)
            {
                sum = sum - sum * 5 / 100;
            }

            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}

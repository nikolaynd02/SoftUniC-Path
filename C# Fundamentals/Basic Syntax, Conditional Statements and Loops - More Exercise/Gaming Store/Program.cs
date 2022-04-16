using System;

namespace Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());

            double startingBalance = balance;

            while (true)
            {

                if (balance <= 0)
                {
                    break;
                }

                string name = Console.ReadLine();

                if(name=="Game Time")
                {
                    break;
                }

                switch (name)
                {
                    case "OutFall 4":
                        if (balance >= 39.99)
                        {
                            Console.WriteLine("Bought OutFall 4");
                            balance -= 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        if (balance >= 15.99)
                        {
                            Console.WriteLine("Bought CS: OG");
                            balance -= 15.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        if (balance >= 19.99)
                        {
                            Console.WriteLine("Bought Zplinter Zell");
                            balance -= 19.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        if (balance >= 59.99)
                        {
                            Console.WriteLine("Bought Honored 2");
                            balance -= 59.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        if (balance >= 29.99)
                        {
                            Console.WriteLine("Bought RoverWatch");
                            balance -= 29.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (balance >= 39.99)
                        {
                            Console.WriteLine("Bought RoverWatch Origins Edition");
                            balance -= 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

            }

            if (balance > 0)
            {
                Console.WriteLine($"Total spent: ${startingBalance - balance:f2}. Remaining: ${balance:f2}");
            }
            else
            {
                Console.WriteLine("Out of money!");
            }
        }
    }
}

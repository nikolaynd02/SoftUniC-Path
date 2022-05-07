using System;

namespace P01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int num = int.Parse(Console.ReadLine());
                ManipulateInput(num);
            }
            else if (type == "real")
            {
                double num = double.Parse(Console.ReadLine());
                ManipulateInput(num);
            }
            else if (type == "string")
            {
                string input = Console.ReadLine();
                ManipulateInput(input);
            }
        }

        static void ManipulateInput(int num)
        {
            Console.WriteLine(num * 2);
        }

        static void ManipulateInput(double num)
        {
            Console.WriteLine($"{num * 1.5:f2}");
        }

        static void ManipulateInput(string input)
        {
            Console.WriteLine($"${input}$");
        }
    }
}

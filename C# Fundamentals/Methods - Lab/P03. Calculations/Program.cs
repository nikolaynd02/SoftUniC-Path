using System;

namespace P03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Calculate(input, num1, num2);
        }
        static void Calculate(string operation,int num1,int num2)
        {
            if (operation == "add")
            {
                Console.WriteLine(num1 + num2);
            }
            else if (operation == "multiply")
            {
                Console.WriteLine(num1 * num2);
            }
            else if(operation == "substract")
            {
                Console.WriteLine(num1 - num2);
            }
            else
            {
                Console.WriteLine(num1 / num2);
            }
        }
    }
}

using System;

namespace P11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            if (@operator == '/')
            {
                Console.WriteLine(GetDivision(number1, number2));
            }
            else if (@operator == '*')
            {
                Console.WriteLine(GetProduct(number1, number2));
            }
            else if (@operator == '+')
            {
                Console.WriteLine(GetSum(number1, number2));
            }
            else if (@operator == '-')
            {
                Console.WriteLine(GetDiffernce(number1, number2));
            }
        }

        static int GetSum(int num1,int num2)
        {
            return num1 + num2;
        }
        static int GetDiffernce(int num1, int num2)
        {
            return num1 - num2;
        }
        static int GetProduct(int num1, int num2)
        {
            return num1 * num2;
        }
        static double GetDivision(double num1, double num2)
        {
            return num1 / num2;
        }

    }
}

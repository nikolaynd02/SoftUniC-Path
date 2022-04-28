using System;

namespace P08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(number, power));
        }

        static double MathPower(double number, double power)
        {
            double multiplier = number;
            for(int i = 1; i < power; i++)
            {
                number *= multiplier;
            }
            return number;
        }
    }
}

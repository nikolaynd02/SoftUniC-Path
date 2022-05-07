using System;

namespace P05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given a number num1, num2, and num3. Write a program that finds if num1 * num2 * num3 (the product) is negative, positive, or zero. Try to do this WITHOUT multiplying the 3 numbers.
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(CheckProductIfPositiveOrNegative(num1, num2, num3));
        }

        static string CheckProductIfPositiveOrNegative(int num1,int num2,int num3)
        {
            string result = string.Empty;
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                return "zero";
            }
            else if (num1 > 0 && num2 > 0 && num3 > 0)
            {
                return "positive";
            }
            else if (num1 < 0 && num2 < 0 && num3 < 0)
            {
                return "negative";
            }
            else if (num1 < 0 && (num2 < 0 || num3 < 0))
            {
                return "positive";
            }
            else if (num2 < 0 && (num3 < 0 || num1 < 0))
            {
                return "positive";
            }
            else if (num3 < 0 && (num1 < 0 || num2 < 0))
            {
                return "positive";
            }
            else
            {
                return "negative";
            }
        }
    }
}

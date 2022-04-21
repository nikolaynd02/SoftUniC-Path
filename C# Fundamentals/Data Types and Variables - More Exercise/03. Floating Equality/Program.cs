using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNum = decimal.Parse(Console.ReadLine());
            decimal secondNum = decimal.Parse(Console.ReadLine());

            decimal diff = 0m;
            const decimal eps = 0.000001m;
            if (firstNum > secondNum)
            {
                diff = firstNum - secondNum;
            }
            else
            {
                diff = secondNum - firstNum;
            }

            if (diff < 0)
            {
                diff *= (-1);
            }

            if (diff < eps)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

        }
    }
}

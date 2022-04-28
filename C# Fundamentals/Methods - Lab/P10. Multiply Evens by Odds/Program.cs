using System;

namespace P10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine(GetMultipleOfEvenOdds(GetSumOfEvenDigits(number), GetSumOFOddDigits(number)));
        }

        static int GetMultipleOfEvenOdds(int sumEven,int sumOdd)
        {
            return sumEven * sumOdd;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 == 0)
                {
                    sum += number % 10;
                }
                number /= 10;
            }
            return sum;
        }

        static int GetSumOFOddDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 != 0 )
                {
                    sum += number % 10;
                }
                number /= 10;
            }
            return sum;
        }
    }
}

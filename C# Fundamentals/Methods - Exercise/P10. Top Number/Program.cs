using System;

namespace P10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for(int i = 1; i <= end; i++)
            {
                if (IsSumOfDigitsDivisibleBy8(i) && CheckForOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsSumOfDigitsDivisibleBy8(int currNum)
        {
            int sum = 0;
            while (currNum != 0)
            {
                sum += currNum%10;
                currNum /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool CheckForOddDigit(int currNum)
        {
            while (currNum != 0)
            {
                int currDigit = currNum % 10;
                if (currDigit % 2 != 0)
                {
                    return true;
                }
                currNum /= 10;
            }

            return false;
        }
    }
}

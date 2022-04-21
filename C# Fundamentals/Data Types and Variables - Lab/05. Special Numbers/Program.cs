using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for(int i = 1; i <= number; i++)
            {
                int sum = 0;
                int digit = 0;
                int currNum = i;
                while (currNum > 0)
                {
                    digit = currNum % 10;
                    sum += digit;
                    currNum = (currNum - digit) / 10;
                    
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}

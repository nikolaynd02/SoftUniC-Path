using System;

namespace multiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int firstDigit = number % 10;
            int secondDigit = (number / 10) % 10;
            int thirdDigit = (number / 100) % 10;

            for (int i = 1; i <= firstDigit; i++)
            {
                for(int j = 1; j <= secondDigit; j++)
                {
                    for(int k = 1; k <= thirdDigit; k++)
                    {
                        int product = i * k * j;
                        Console.WriteLine($"{i} * {j} * {k} = {product};");
                    }
                }
            }


        }
    }
}

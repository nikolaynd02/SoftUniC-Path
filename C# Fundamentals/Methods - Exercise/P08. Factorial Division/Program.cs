using System;

namespace P08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"{DivideFactorials(firstNum, secondNum):f2}");
        }

        static double DivideFactorials(int firstNum, int secondNum)
        {
            double firstFactorial = 1;
            double secondFactorial = 1;
            
            for(int i = 1; i <= firstNum; i++)
            {
                firstFactorial *= i;
            }
            for (int i = 1; i <= secondNum; i++)
            {
                secondFactorial *= i;
            }
            return firstFactorial / secondFactorial;
        }
    }
}

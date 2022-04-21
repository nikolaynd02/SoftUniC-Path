using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = 0;
            for (int currNum = 1; currNum <= input; currNum++)
            {
                bool special = false;
                int sum = 0;
                number = currNum;
                while (currNum > 0)
                {
                    sum += currNum % 10;
                    currNum = currNum / 10;
                }
                special = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", number, special);
                sum = 0;
                currNum = number;
            }
        }
    }
}

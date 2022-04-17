using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int charachters = int.Parse(Console.ReadLine());

            int sum = 0;
            for(int symbolNum = 1; symbolNum <= charachters; symbolNum++)
            {
                string input = Console.ReadLine();
                char symbol = input[0];

                sum += symbol;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}

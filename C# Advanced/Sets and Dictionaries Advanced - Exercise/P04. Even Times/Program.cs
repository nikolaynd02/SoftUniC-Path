using System;
using System.Collections.Generic;

namespace P04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for(int i = 0; i < inputs; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 1;
                }
                else
                {
                    numbers[num]++;
                }
            }

            foreach(var number in numbers)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    return;
                }
            }
        }
    }
}

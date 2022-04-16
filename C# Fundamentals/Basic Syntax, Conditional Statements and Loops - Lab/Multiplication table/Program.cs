using System;

namespace Multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            if (multiplier <= 10)
            {

                for(;multiplier<=10;multiplier++)
                {   
                    Console.WriteLine($"{input} X {multiplier} = {input * multiplier}");
                }
            }
            else
            {
                Console.WriteLine($"{input} X {multiplier} = {input * multiplier}");
            }

        }
    }
}

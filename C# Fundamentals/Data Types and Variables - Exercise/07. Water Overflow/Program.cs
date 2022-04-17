using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            int capacity = 255;

            for(int i = 1; i <= inputs; i++)
            {
                int lites = int.Parse(Console.ReadLine());
                if (capacity >= lites)
                {
                    capacity -= lites;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(255-capacity);
        }
    }
}

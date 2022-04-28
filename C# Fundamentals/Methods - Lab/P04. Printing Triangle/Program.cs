using System;

namespace P04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            PrintTriangle(lines);
        }

        static void PrintTriangle(int lines)
        {
            for(int i = 1; i <= lines; i++)
            {
                for(int p = 1; p <= i; p++)
                {
                    Console.Write(p + " ");
                }
                Console.WriteLine();
            }
            for(int i = lines; i > 0; i--)
            {
                for(int p = 1; p < i; p++)
                {
                    Console.Write(p + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

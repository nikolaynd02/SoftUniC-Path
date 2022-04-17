using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            for (; start <= finish; start++)
            {
                char currChar = (char)(start);
                Console.Write(currChar+" ");
            }
        }
    }
}

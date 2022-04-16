using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = "";
            int lenght = input.Length-1;

            while (lenght >= 0)
            {

                output += input[lenght];

                lenght--;
            }

            Console.WriteLine(output);

        }
    }
}

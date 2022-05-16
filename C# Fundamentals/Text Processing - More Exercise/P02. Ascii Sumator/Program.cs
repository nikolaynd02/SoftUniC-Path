using System;

namespace P02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = Convert.ToChar(Console.ReadLine());
            char secondChar = Convert.ToChar(Console.ReadLine());
            string inputString = Console.ReadLine();

            int sum = 0;
            foreach(char currChar in inputString)
            {
                if ((firstChar > currChar && secondChar < currChar) || (firstChar < currChar && secondChar > currChar))
                {
                    sum += currChar;
                }
            }

            Console.WriteLine(sum);
        }
    }
}

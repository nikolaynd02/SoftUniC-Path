using System;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = Console.ReadLine();

            string reverse = c + " " + b + " " + a;
            Console.WriteLine(reverse);
        }
    }
}

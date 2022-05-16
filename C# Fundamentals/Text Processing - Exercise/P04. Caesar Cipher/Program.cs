using System;
using System.Text;

namespace P04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder encrypted = new StringBuilder();

            for(int i = 0; i < message.Length; i++)
            {
                encrypted.Append((char)(message[i] + 3));
            }

            Console.WriteLine(encrypted);
        }
    }
}

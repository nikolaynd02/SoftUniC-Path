using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            while (times>0) { 
                int num = int.Parse(Console.ReadLine());

                string digits = num.ToString();

                int numOfDigits = digits.Length;

                int offset = (num%10-2)*3;

                if (num % 10 == 8 || num % 10 == 9)
                {
                    offset++;
                }

                if (num != 0)
                {

                    int letterIndex = offset + numOfDigits - 1;
                    char letter = (char)(97+letterIndex);

                    Console.Write(letter);
                }
                else
                {
                    Console.Write(" ");
                }

                times--;
            }

            

        }
    }
}

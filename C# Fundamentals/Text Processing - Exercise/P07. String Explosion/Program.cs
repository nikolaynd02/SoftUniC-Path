using System;
using System.Text;

namespace P07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int bombPower = 0;

            StringBuilder result = new StringBuilder();

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>') 
                {
                    bombPower += int.Parse(input[i + 1].ToString());

                    result.Append(input[i]);
                }
                else if (bombPower > 0)
                {
                    bombPower--;
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}

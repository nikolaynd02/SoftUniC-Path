using System;

namespace P02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            string firstWord = input[0];
            string secondWord = input[1];

            int shortLenght = Math.Min(firstWord.Length, secondWord.Length);

            int sum = 0;

            for(int i = 0; i < shortLenght; i++)
            {
                sum += (firstWord[i] * secondWord[i]);
            }

            if (firstWord.Length > shortLenght)
            {
                string remaining = firstWord.Substring(shortLenght);
                for(int i = 0; i < remaining.Length; i++)
                {
                    sum += remaining[i];
                }

            }
            else if (firstWord.Length != secondWord.Length)
            {
                string remaining = secondWord.Substring(shortLenght);
                for (int i = 0; i < remaining.Length; i++)
                {
                    sum += remaining[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}

using System;

namespace P01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            Random random = new Random();

            for (int i=0; i < input.Length; i++)
            {
                int randomIndex = random.Next(0, input.Length);

                string currWord = input[i];
                input[i] = input[randomIndex];
                input[randomIndex] = currWord;
            }

            foreach(string word in input)
            {
                Console.WriteLine(word);
            }

        }
    }
}

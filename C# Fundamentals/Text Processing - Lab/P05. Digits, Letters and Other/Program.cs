using System;
using System.Text;

namespace P05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            StringBuilder letters = new StringBuilder();
            StringBuilder numbers = new StringBuilder();
            StringBuilder symbols = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    numbers.Append(word[i]);
                }
                else if (char.IsLetter(word[i]))
                {
                    letters.Append(word[i]);
                }
                else
                {
                    symbols.Append(word[i]);
                }
            }

            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(symbols);
        }
    }
}

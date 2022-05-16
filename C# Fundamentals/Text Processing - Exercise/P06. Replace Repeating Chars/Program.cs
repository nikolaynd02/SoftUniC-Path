using System;
using System.Text;

namespace P06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder filteredText = new StringBuilder();

            char lastChar;
            for(int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    filteredText.Append(text[0]);
                    continue;
                }
                lastChar = text[i - 1];
                if (lastChar != text[i])
                {
                    filteredText.Append(text[i]);
                }
            }
            Console.WriteLine(filteredText);
        }
    }
}

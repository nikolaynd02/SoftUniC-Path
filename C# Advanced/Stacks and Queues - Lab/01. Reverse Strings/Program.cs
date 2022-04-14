using System;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> wordToReverse = new Stack<char>();

            foreach(char symbol in input)
            {
                wordToReverse.Push(symbol);
            }

            while (wordToReverse.Count > 0)
            {
                Console.Write(wordToReverse.Pop());
            }
        }
    }
}

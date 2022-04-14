using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indecies = new Stack<int>();
            
            for(int i = 0; i < expression.Length; i++)
            {
                char symbol = expression[i];

                if(symbol == '(')
                {
                    indecies.Push(i);
                }
                else if(symbol == ')')
                {
                    int startIndex = indecies.Pop();
                    int endIndex = i;

                    Console.WriteLine(expression.Substring(startIndex, endIndex - startIndex + 1));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>();

            foreach(string currCh in expression)
            {
                stack.Push(currCh);
            }

            int sum = 0;

            int positiveSum = 0;
            int negativeSum = 0;

            while (stack.Count > 1)
            {
                int number = int.Parse(stack.Pop());

                string cmd = stack.Pop().ToString();

                if (cmd == "+")
                {
                    positiveSum += number;
                }
                else
                {
                    negativeSum += number ;
                }
            }

            positiveSum += int.Parse(stack.Pop());

            sum = positiveSum - negativeSum;

            Console.WriteLine(sum);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        //60/100
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stackNum = new Stack<int>();

            int[] numbersToPush = Console.ReadLine().Split().Select(int.Parse).ToArray();


            foreach(int num in numbersToPush)
            {
                stackNum.Push(num);
            }

            for(int i = 0; i < numbers[1]; i++)
            {
                stackNum.Pop();
            }

            int min = int.MaxValue;

            while (stackNum.Count > 0)
            {
                if (stackNum.Peek() == numbers[2])
                {
                    Console.WriteLine("true");
                    return;
                }
                else
                {
                    if (min > stackNum.Peek())
                    {
                        min = stackNum.Peek();
                    }

                    stackNum.Pop();
                }
            }

            if (stackNum.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (min != int.MaxValue)
            {
                Console.WriteLine(min);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ConditionalExpressionResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();


            while(input.Count > 1)
            {
                int boolIndex = input.FindLastIndex(x => x == "t" || x =="f");

                if(boolIndex < 0)
                {
                    break;
                }

                bool boolValue = input[boolIndex] == "t";
                int firstNum = int.Parse(input[boolIndex + 2]);
                int secondNum = int.Parse(input[boolIndex + 4]);

                int result = boolValue ? firstNum : secondNum;

                input.RemoveAt(boolIndex);
                input.RemoveAt(boolIndex);
                input.RemoveAt(boolIndex);
                input.RemoveAt(boolIndex);
                input.RemoveAt(boolIndex);
                input.Insert(boolIndex, result.ToString());

            }

            Console.WriteLine(input[0]);
        }
    }
}

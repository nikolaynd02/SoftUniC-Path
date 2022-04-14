using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdInfo = cmd.Split();
                if (cmdInfo[0] == "add")
                {
                    numbers.Push(int.Parse(cmdInfo[1]));
                    numbers.Push(int.Parse(cmdInfo[2]));
                }
                else if(cmdInfo[0] == "remove")
                {
                    int numbersToRemove = int.Parse(cmdInfo[1]);
                    if (numbersToRemove <= numbers.Count)
                    {
                        while (numbersToRemove != 0)
                        {
                            numbers.Pop();
                            numbersToRemove--;
                        }
                    }
                }
            }

            int sum = 0;
            while (numbers.Count > 0)
            {
                sum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

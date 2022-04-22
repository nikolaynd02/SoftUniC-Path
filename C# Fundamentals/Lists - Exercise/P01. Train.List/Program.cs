using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Train.List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int wagonMaxCap = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split();

            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    int morePass = int.Parse(input[0]);
                    for(int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + morePass <= wagonMaxCap)
                        {
                            wagons[i] += morePass;
                            break;
                        }
                    }
                }
                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}

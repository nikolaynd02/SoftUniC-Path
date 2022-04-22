using System;
using System.Collections.Generic;
using System.Linq;

namespace P09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sumOfRemovedElements = 0;

            while (numbersList.Count != 0)
            {
                int currIndex = int.Parse(Console.ReadLine());
                if (currIndex < 0)
                {
                    int currIndexNum = numbersList[0];
                    sumOfRemovedElements += currIndexNum;
                    numbersList[0] = numbersList[numbersList.Count - 1];
                    ChangeNumbers(numbersList, currIndexNum);
                }
                else if (currIndex > numbersList.Count - 1)
                {
                    int currIndexNum = numbersList[numbersList.Count - 1];
                    sumOfRemovedElements += numbersList[numbersList.Count - 1];
                    numbersList[numbersList.Count - 1] = numbersList[0];
                    ChangeNumbers(numbersList, currIndexNum);
                }
                else
                {
                    int currIndexNum = numbersList[currIndex];
                    ChangeNumbers(numbersList, currIndexNum);
                    sumOfRemovedElements += currIndexNum;
                    numbersList.RemoveAt(currIndex);
                }
            }

            Console.WriteLine(sumOfRemovedElements);
        }

        static void ChangeNumbers(List<int> numbers, int currNum)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= currNum)
                {
                    numbers[i] += currNum;
                }
                else
                {
                    numbers[i] -= currNum;
                }
            }
        }
    }
}

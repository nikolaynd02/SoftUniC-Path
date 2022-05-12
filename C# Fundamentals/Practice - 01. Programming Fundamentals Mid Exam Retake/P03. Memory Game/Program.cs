using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)                
                .ToList();

            string input = Console.ReadLine();

            int movesCounter = 0;

            while (input != "end" && listOfElements.Count!=0)
            {
                int[] guess = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                movesCounter++;

                if (CheckIndexes(guess[0],guess[1],listOfElements.Count))
                {
                    if (listOfElements[guess[0]] == listOfElements[guess[1]])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {listOfElements[guess[0]]}!");
                        if (guess[0] > guess[1])
                        {
                            listOfElements.RemoveAt(guess[0]);
                            listOfElements.RemoveAt(guess[1]);
                        }
                        else
                        {
                            listOfElements.RemoveAt(guess[1]);
                            listOfElements.RemoveAt(guess[0]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    listOfElements.Insert(listOfElements.Count / 2, $"-{movesCounter}a");
                    listOfElements.Insert(listOfElements.Count / 2, $"-{movesCounter}a");
                }

                input = Console.ReadLine();
            }

            if (listOfElements.Count==0)
            {
                Console.WriteLine($"You have won in {movesCounter} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", listOfElements));
            }

        }

        static bool CheckIndexes(int firstIndex, int secondIndex, int listCount)
        {
            if (firstIndex < 0 || firstIndex > listCount - 1 || secondIndex < 0 || secondIndex > listCount - 1 || firstIndex == secondIndex)
            {
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    AddNumber(numbers, int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    RemoveAllNumbers(numbers, int.Parse(command[1]));
                }
                else if (command[0] == "RemoveAt")
                {
                    RemoveNumberAtindex(numbers, int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    InsertNumAtIndex(numbers, int.Parse(command[1]), int.Parse(command[2]));
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void AddNumber(List<int >numbers, int number)
        {
            numbers.Add(number);
        }

        static void RemoveAllNumbers(List<int> numbers, int number)
        {
            numbers.RemoveAll(currNum => currNum == number);
        }

        static void RemoveNumberAtindex(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
        }

        static void InsertNumAtIndex(List<int> numbers, int number, int index)
        {
            numbers.Insert(index, number);
        }

    }
}

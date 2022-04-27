using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            bool wasChanged = false;

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    AddNumber(numbers, int.Parse(command[1]));
                    wasChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    RemoveAllNumbers(numbers, int.Parse(command[1]));
                    wasChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    RemoveNumberAtindex(numbers, int.Parse(command[1]));
                    wasChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    InsertNumAtIndex(numbers, int.Parse(command[1]), int.Parse(command[2]));
                    wasChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    Console.WriteLine(CheckIfContainsNum(numbers, int.Parse(command[1])));
                }
                else if (command[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (command[0] == "GetSum")
                {
                    PrintSum(numbers);
                }
                else if(command[0] == "Filter")
                {
                    Console.WriteLine(string.Join(" ",Filter(numbers, command[1], int.Parse(command[2]))));
                }

                command = Console.ReadLine().Split();
            }

            if (wasChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void AddNumber(List<int> numbers, int number)
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

        static string CheckIfContainsNum(List<int> numbers, int number)
        {
            if (numbers.Contains(number))
            {
                return "Yes";
            }

            return "No such number";
        }

        static void PrintEven(List<int> numbers)
        {          
            foreach(int number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        static void PrintOdd(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        static void PrintSum(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

        static List<int> Filter(List<int> numbers, string criteria, int number)
        {
            List<int> result = new List<int>();

            if (criteria == "<")
            {
                return numbers.FindAll(currNum => currNum < number);
            }
            else if (criteria == ">")
            {
                return numbers.FindAll(currNum => currNum > number);
            }
            else if (criteria == ">=")
            {
                return numbers.FindAll(currNum => currNum >= number);
            }
            else
            {
                return numbers.FindAll(currNum => currNum <= number);
            }
        }
    }
}

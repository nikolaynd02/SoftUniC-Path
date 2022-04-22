using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    numbers.RemoveAll(currNum => currNum == int.Parse(command[1]));
                }
                else // insert
                {
                    int index = int.Parse(command[2]);
                    int givenNum = int.Parse(command[1]);
                    numbers.Insert(index, givenNum);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}

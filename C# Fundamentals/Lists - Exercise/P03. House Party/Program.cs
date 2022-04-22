using System;
using System.Collections.Generic;

namespace P03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesOfInput = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();

            for(int i = 0; i < linesOfInput; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (!guestList.Contains(input[0]) && input[2] != "not")
                {
                    guestList.Add(input[0]);
                }
                else if(guestList.Contains(input[0]) && input[2] == "not")
                {
                    guestList.Remove(input[0]);
                }
                else if (!guestList.Contains(input[0]) && input[2] == "not")
                {

                    Console.WriteLine($"{input[0]} is not in the list!");
                }
                else
                {
                    Console.WriteLine($"{input[0]} is already in the list!");
                }
            }

            foreach(string name in guestList)
            {
                Console.WriteLine(name);
            }

        }
    }
}

using System;

namespace P09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(num1,num2));
            }
            else if (type == "string")
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                Console.WriteLine(GetMax(input1, input2));
            }
            else
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));
            }
        }

        static int GetMax(int num1,int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }

            return num2;
        }

        static string GetMax(string input1,string input2)
        {
            if (input1.CompareTo(input2) > 0)
            {
                return input1;
            }

            return input2;
        }

        static char GetMax(char first,char second)
        {
            if (first > second)
            {
                return first;
            }

            return second;
        }
        
    }
}

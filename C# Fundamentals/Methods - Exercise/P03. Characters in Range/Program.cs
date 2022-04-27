using System;

namespace P03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            PrintCharsInRange(firstChar, secondChar);
        }

        static void PrintCharsInRange(char start,char end)
        {
            if (start > end)
            {
                char temp = ' ';
                temp = end;
                end = start;
                start = temp;
            }

            for (int currChar= start + 1; currChar < end; currChar++)
            {
                Console.Write((char)currChar + " ");
            }
        }
    }
}

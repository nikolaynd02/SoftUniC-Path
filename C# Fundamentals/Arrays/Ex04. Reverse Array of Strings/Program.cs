using System;
using System.Linq;

namespace Ex04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine().Split(' ').ToArray();
            
            for(int i=0; i < letters.Length / 2; i++)
            {
                string currLetter = letters[i];
                letters[i] = letters[letters.Length - 1 - i];
                letters[letters.Length - 1 - i] = currLetter;
            }
            //string.Join to write the whole array
            Console.WriteLine(string.Join(" ", letters));
        }
    }
}

using System;

namespace P04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            PrintTribonacciSequence(numbers);
        }

        static void PrintTribonacciSequence(int numbers)
        {
            int[] lastThreenums =new int[3];
            lastThreenums[0] = 1;
            lastThreenums[1] = 1;
            lastThreenums[2] = 2;
            int counter = 0;
            while (numbers != 0)
            {
                Console.Write(lastThreenums[counter%3] + " ");
                lastThreenums[counter % 3] = lastThreenums[0] + lastThreenums[1] + lastThreenums[2];
                counter++;
                numbers--;
            }
        }
    }
}

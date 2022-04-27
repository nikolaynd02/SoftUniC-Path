using System;

namespace P07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int filler = int.Parse(Console.ReadLine());

            int counter = 0;

            foreach(int i in GetMatrix(filler))
            {
                counter++;
                Console.Write(i + " ");
                if (counter == filler)
                {
                    counter = 0;
                    Console.WriteLine();
                }
            }
        }

        static int[,] GetMatrix(int filler)
        {
            int[,] matrix = new int[filler,filler];

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int p = 0; p < matrix.GetLength(1); p++)
                {
                    matrix[i, p] = filler;
                }
            }
            return matrix;
        }
    }
}

using System;
using System.Linq;

namespace P01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for(int x = 0; x < n; x++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int y = 0; y < n; y++)
                {
                    matrix[x, y] = row[y];
                }
            }


            int primarySum = 0;
            int secondarySum = 0;

            for(int x = 0; x < matrix.GetLength(0); x++)
            {
                for(int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (x == y && x + y == n - 1)
                    {
                        primarySum += matrix[x, y];
                        secondarySum += matrix[x, y];
                    }
                    else if (x == y)
                    {
                        primarySum += matrix[x, y];
                    }
                    else if (x + y == n - 1)
                    {
                        secondarySum += matrix[x, y];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}

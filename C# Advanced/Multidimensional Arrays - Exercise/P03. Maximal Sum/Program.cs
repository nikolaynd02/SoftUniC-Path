using System;
using System.Linq;

namespace P03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            // 60/100
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[numbers[0], numbers[1]];

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                int[] numsToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    matrix[x, y] = numsToAdd[y];
                }
            }

            int maxSum = int.MinValue;
            int[,] biggesMatrix = new int[3, 3];
            

            for (int x = 0; x < matrix.GetLength(0) - 2; x++)
            {
                for (int y = 0; y < matrix.GetLength(1) - 2; y++)
                {
                    int row = 0;
                    int col = 0;
                    int currMaxSum = 0;
                    int[,] currMatrix = new int[3, 3];


                    for (int innerX = x; innerX<x+3; innerX++)
                    {
                        for (int innerY = y; innerY < y + 3; innerY++)
                        {
                            currMaxSum += matrix[innerX, innerY];
                            currMatrix[row,col++] = matrix[innerX, innerY];
                        }
                        row++;
                        col = 0;
                    }

                    if (maxSum < currMaxSum)
                    {
                        maxSum = currMaxSum;
                        biggesMatrix = currMatrix;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int x = 0; x < biggesMatrix.GetLength(0); x++)
            {

                for (int y = 0; y < biggesMatrix.GetLength(1); y++)
                {
                    Console.Write(biggesMatrix[x,y] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

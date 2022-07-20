using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Move_DownOrRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int[,] originalMatrix = new int[height, width];
            PopulateMatrix(originalMatrix);
            int[,] alteredMatrix = new int[height, width];
            PopulateAlteredMatrix(alteredMatrix, originalMatrix);

            Stack<string> path = Generatepath(alteredMatrix);

            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<string> Generatepath(int[,] alteredMatrix)
        {
            Stack<string> path = new Stack<string>();

            int row = alteredMatrix.GetLength(0) - 1;
            int col = alteredMatrix.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                int left = alteredMatrix[row, col - 1];
                int up = alteredMatrix[row - 1, col];

                if(up > left)
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            while (row > 0) path.Push($"[{row--}, {col}]");

            while (col > 0) path.Push($"[{row}, {col--}]");

            path.Push($"[{row}, {col}]");

            return path;
        }

        private static void PopulateAlteredMatrix(int[,] alteredMatrix, int[,] originalMatrix)
        {
            alteredMatrix[0, 0] = originalMatrix[0, 0];

            for (int x = 1; x < originalMatrix.GetLength(0); x++)
            {
                alteredMatrix[x, 0] = originalMatrix[x, 0] + alteredMatrix[x - 1, 0];
            }
            for (int y = 1; y < originalMatrix.GetLength(1); y++)
            {
                alteredMatrix[0, y] = originalMatrix[0, y] + alteredMatrix[0, y - 1];
            }

            for (int x = 1; x < originalMatrix.GetLength(0); x++)
            {
                for (int y = 1; y < originalMatrix.GetLength(1); y++)
                {                   
                        alteredMatrix[x, y] = Math.Max(alteredMatrix[x - 1, y], alteredMatrix[x, y - 1]) + originalMatrix[x, y];                   
                }
            }

        }

        private static void PopulateMatrix(int[,] matrix)
        {
            for(int x=0; x < matrix.GetLength(0); x++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    matrix[x, y] = input[y];
                }
            }
        }
    }
}

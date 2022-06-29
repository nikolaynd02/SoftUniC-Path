using System;
using System.Collections.Generic;

namespace P05._Paths_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];

            for(int x = 0; x < rows; x++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for(int y = 0; y < cols; y++)
                {
                    matrix[x, y] = input[y];
                }
            }

            List<string> directions = new List<string>();

            GetAllPaths(matrix,0,0,directions,string.Empty);


        }

        private static void GetAllPaths(char[,] matrix,int currRow,int currCol, List<string> directions, string direction)
        {
            
            if(currRow < 0 || currRow >= matrix.GetLength(0) || currCol < 0 || currCol >= matrix.GetLength(1) || matrix[currRow,currCol] == '*' || matrix[currRow,currCol] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (matrix[currRow, currCol] == 'e')
            {
                Console.WriteLine(string.Join("",directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[currRow, currCol] = 'v';

            GetAllPaths(matrix, currRow - 1, currCol,directions,"U"); // up
            GetAllPaths(matrix, currRow + 1, currCol,directions,"D"); // down
            GetAllPaths(matrix, currRow, currCol + 1,directions,"R"); // right
            GetAllPaths(matrix, currRow, currCol - 1,directions,"L"); //left

            matrix[currRow, currCol] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}

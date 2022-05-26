using System;
using System.Linq;

namespace P02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[numbers[0], numbers[1]];

            for(int x = 0; x < matrix.GetLength(0); x++)
            {
                string[] chToAdd = Console.ReadLine().Split().ToArray();

                for(int y = 0; y < matrix.GetLength(1); y++)
                {
                    matrix[x, y] = chToAdd[y];
                }
            }

            int sameCount = 0;

            for (int x = 0; x < matrix.GetLength(0) - 1; x++)
            {                
                for (int y = 0; y < matrix.GetLength(1) - 1; y++)
                {
                    if(matrix[x,y] == matrix[x,y+1] && matrix[x,y] == matrix[x+1,y] && matrix[x, y] == matrix[x + 1, y + 1])
                    {
                        sameCount++;
                    }
                }
            }

            Console.WriteLine(sameCount);
        }
    }
}

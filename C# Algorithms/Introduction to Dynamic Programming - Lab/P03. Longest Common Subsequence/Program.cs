using System;
using System.Collections.Generic;

namespace P03._Longest_Common_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string strOne = Console.ReadLine();
            string strTwo = Console.ReadLine();

            int[,] matrix = new int[strOne.Length + 1, strTwo.Length + 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (strOne[i - 1] == strTwo[j - 1]) matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                }
            }

            Console.WriteLine(matrix[strOne.Length, strTwo.Length]);
        }        
    }
}

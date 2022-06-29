using System;
using System.Collections.Generic;

namespace P06._8_Queens_Puzzle
{
    class Program
    {
        private static List<int> attackedRows = new List<int>();
        private static List<int> attackedCols = new List<int>();
        private static List<int> attackedPrimaryDiagonals = new List<int>();
        private static List<int> attackedSecondaryDiagonals = new List<int>();
        
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    board[x, y] = '-';
                }               
            }

            PrintValidBoards(board,0);
        }

        private static void PrintValidBoards(char[,] board,int row)
        {
            if(row >= board.GetLength(0))
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    for (int y = 0; y < board.GetLength(1); y++)
                    {
                        Console.Write(board[x, y] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            for(int col = 0; col <= board.GetLength(1); col++)
            {
                
                if(Validation(board,row,col))
                {
                    board[row, col] = '*';

                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedPrimaryDiagonals.Add(col - row);
                    attackedSecondaryDiagonals.Add(col + row);

                    PrintValidBoards(board, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedPrimaryDiagonals.Remove(col - row);
                    attackedSecondaryDiagonals.Remove(col + row);
                    board[row, col] = '-';

                }
            }
            
        }

        private static bool Validation(char[,] board,int row,int col)
        {
            if(row < 0 || row >= board.GetLength(0) || col < 0 || col>= board.GetLength(1))
            {
                return false;
            }
            else if(attackedRows.Contains(row) 
                || attackedCols.Contains(col)
                || attackedPrimaryDiagonals.Contains(col - row)
                || attackedSecondaryDiagonals.Contains(col + row))
            {
                return false;
            }

            return true;
        }
    }
}

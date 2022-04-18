using System;
using System.Linq;

namespace P04._Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows,columns];

            for(int i = 0; i < rows; i++)
            {
                int[] rowToAdd = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for(int p = 0; p < columns; p++)
                {
                    matrix[i, p] = rowToAdd[p];
                }

            }

           

            int printedRowsCounter = 0;
            int printedColumsCounter = 0;
            int rowsLeft = rows;
            int columnsLeft = columns;


            while (rowsLeft !=0 && columnsLeft != 0)
            {
                if (printedColumsCounter % 2 == 1 && printedRowsCounter % 2 == 1) //prints row reversed
                {
                    for(int i = columns - printedColumsCounter/2 - 2; i >= 0 + printedColumsCounter / 2; i--)
                    {
                        Console.Write(matrix[rows-1-printedRowsCounter/2 , i] + " ");
                    }                   
                    printedRowsCounter++;
                    rowsLeft--;
                }
                else if (printedRowsCounter % 2 == 1 && printedColumsCounter % 2 == 0) //prints column
                {
                    for(int i = 1 + printedRowsCounter / 2; i < rows - printedRowsCounter / 2 ; i++)
                    {
                        Console.Write(matrix[i, columns - printedColumsCounter / 2 - 1] + " ");
                    }
                    printedColumsCounter++;
                    columnsLeft--;
                }
                else if (printedColumsCounter % 2 == 0 && printedRowsCounter % 2 == 0) //prints row
                {
                    for(int i = 0 + printedColumsCounter / 2; i < columns - printedColumsCounter / 2; i++)
                    {
                        Console.Write(matrix[printedRowsCounter / 2, i] + " ");
                    }
                    printedRowsCounter++;
                    rowsLeft--;
                }
                else if (printedRowsCounter % 2 == 0 && printedColumsCounter % 2 == 1) //print column reversed
                {
                    for(int i = rows - printedRowsCounter/2 -1; i >= 0 + printedRowsCounter / 2; i--)
                    {
                        Console.Write(matrix[i, printedColumsCounter / 2 ] + " ");
                    }
                    printedColumsCounter++;
                    columnsLeft--;
                }
            }

        }
    }
}

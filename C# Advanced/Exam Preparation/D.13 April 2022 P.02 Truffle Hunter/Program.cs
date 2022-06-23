using System;
using System.Collections.Generic;

namespace D._13_April_2022_P._02_Truffle_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            string[,] field = new string[matrixSize, matrixSize];

            for(int x = 0; x < field.GetLength(0); x++)
            {
                string[] rowInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for(int y = 0; y < field.GetLength(1); y++)
                {
                    field[x, y] = rowInfo[y];
                }
            }

            Dictionary<string, int> truffleCounts = new Dictionary<string, int>()
            {
                ["B"] = 0,
                ["S"] = 0,
                ["W"] = 0
            };

            int boarTrufflesCount = 0;

            string command = string.Empty;

            while((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdInfo[0];
                int row = int.Parse(cmdInfo[1]);
                int col = int.Parse(cmdInfo[2]);
                //string direction = string.Empty;

                if(cmdType == "Wild_Boar")
                {
                    string direction = cmdInfo[3];

                    if (direction == "up")
                    {
                        while (CheckCordinates(row, col, matrixSize))
                        {
                            if (field[row, col] != "-")
                            {
                                field[row, col] = "-";
                                boarTrufflesCount++;
                            }
                            row -= 2;
                            
                        }
                    }
                    else if(direction == "down")
                    {
                        while (CheckCordinates(row, col, matrixSize))
                        {
                            if (field[row, col] != "-")
                            {
                                field[row, col] = "-";
                                boarTrufflesCount++;
                            }
                            row += 2;
                        }
                    }
                    else if(direction == "left")
                    {
                        while (CheckCordinates(row, col, matrixSize))
                        {
                            if (field[row, col] != "-")
                            {
                                field[row, col] = "-";
                                boarTrufflesCount++;
                            }
                            col -= 2;
                        }
                    }
                    else //right
                    {
                        while (CheckCordinates(row, col, matrixSize))
                        {
                            if (field[row, col] != "-")
                            {
                                field[row, col] = "-";
                                boarTrufflesCount++;
                            }
                            col +=2;
                            
                        }
                    }
                }

                else
                {
                    if (truffleCounts.ContainsKey(field[row, col]))
                    {
                        truffleCounts[field[row, col]]++;
                        field[row, col] = "-";
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {truffleCounts["B"]} black, {truffleCounts["S"]} summer, and {truffleCounts["W"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTrufflesCount} truffles.");

            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int y = 0; y < field.GetLength(1); y++)
                {
                    Console.Write(field[i, y] + " ");
                }
                Console.WriteLine();
            }

        }

        static bool CheckCordinates(int row, int col, int matrixSize )
        {
            if (row >= 0 && row < matrixSize && col >= 0 && col < matrixSize)
            {
                return true;
            }

            return false;
        }
    }
}

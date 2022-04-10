using System;

namespace P02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[] currRowNums = new int[1];
            currRowNums[0] = 1;
            int[] lastRowNums = currRowNums;
            for(int i = 1; i <= rows; i++)
            {
                Console.WriteLine(string.Join(" ", currRowNums));
                lastRowNums = new int[currRowNums.Length];
                lastRowNums = currRowNums;
                currRowNums = new int[i + 1];
                for(int p = 0; p < currRowNums.Length; p++)
                {
                    if (p == 0)
                    {
                        currRowNums[p] = 1;
                    }
                    else if (p == currRowNums.Length - 1)
                    {
                        currRowNums[p] = 1;
                    }
                    else
                    {
                        currRowNums[p] = lastRowNums[p - 1] + lastRowNums[p];
                    }
                }
            }
        }
    }
}

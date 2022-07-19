using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Areas_in_Matrix
{
    class Program
    {
        private static SortedDictionary<char, int> areas = new SortedDictionary<char, int>();
        private static bool[,] visited;
        private static char[,] matrix;

        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            visited = new bool[height, width];
            matrix = new char[height, width];
           
            for(int x = 0; x < height; x++)
            {
                string input = Console.ReadLine();
                for(int y = 0; y < width; y++)
                {
                    matrix[x, y] = input[y];
                }
            }
            
            for(int x = 0; x < height; x++)
            {
                for(int y = 0; y < width; y++)
                {
                    if (!visited[x, y])
                    {
                        char chForArea = matrix[x, y];
                        DFS(x, y, chForArea);
                        if (areas.ContainsKey(chForArea))
                        {
                            areas[chForArea]++;
                        }
                        else
                        {
                            areas.Add(chForArea, 1);
                        }
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            foreach(var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }

        }

        private static void DFS(int x, int y, char chForArea)
        {
            if(x < 0 || x >= matrix.GetLength(0) || y < 0 || y >= matrix.GetLength(1))
            {
                return;
            }
            if (visited[x, y])
            {
                return;
            }
            if(matrix[x,y] != chForArea)
            {
                return;
            }
            if (!areas.ContainsKey(chForArea))
            {
                areas.Add(chForArea, 0);
            }
            visited[x, y] = true;

            DFS(x, y + 1, chForArea);
            DFS(x, y - 1, chForArea);
            DFS(x + 1, y, chForArea);
            DFS(x - 1, y, chForArea);

        }
    }
}

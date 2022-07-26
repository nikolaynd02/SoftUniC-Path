using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Guards
{
    class Program
    {
        private static Dictionary<int, List<int>> Graph;
        private static Dictionary<int, bool> Visited;
        private static Dictionary<int, int> Parent;
        static void Main(string[] args)
        {
            Graph = RegisterGraph();
            Visited = RegisterVisitedList();
            Parent = RegisterParentsList();

            int startNode = int.Parse(Console.ReadLine());

            BFS(startNode);
            ;

            List<int> leftNodes = new List<int>();
            foreach (var kvp in Visited)
            {
                if (!kvp.Value)
                {
                    leftNodes.Add(kvp.Key);
                }
            }

            Console.WriteLine(string.Join(" ", leftNodes.OrderBy(x => x)));
        }

        private static void BFS(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            Visited[start] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (int child in Graph[node])
                {
                    if (!Visited[child])
                    {
                        Visited[child] = true;
                        queue.Enqueue(child);
                        Parent[child] = node;
                    }
                }
            }           
        }

        private static Dictionary<int, int> RegisterParentsList()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            foreach (int n in Graph.Keys) list.Add(n, -1);
            return list;
        }

        private static Dictionary<int, bool> RegisterVisitedList()
        {
            Dictionary<int, bool> list = new Dictionary<int, bool>();
            foreach (int n in Graph.Keys) list.Add(n, false);
            return list;
        }


        private static Dictionary<int, List<int>> RegisterGraph()
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            while (edges > 0)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = data[0];
                int to = data[1];

                if (!graph.ContainsKey(from)) graph.Add(from, new List<int>());
                if (!graph.ContainsKey(to)) graph.Add(to, new List<int>());

                graph[from].Add(to);
               
                edges--;
            }

            List<int> addNodes = new List<int>();

            for(int i = 1; i <= nodes; i++)
            {
                if (!graph.ContainsKey(i))
                {
                    graph.Add(i, new List<int>());
                }
            }

            return graph;
        }
    }
}

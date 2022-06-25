using System;
using System.Collections.Generic;
using System.Linq;

namespace P._01._Tiles_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@$"-Renovator: {12}
--Speciality: {10}
--Rate per day: {2} BGN");

            Dictionary<int, int> tilesAndLocations = new Dictionary<int, int>()
            {
                [40] = 0,
                [50] = 0,
                [60] = 0,
                [70] = 0
            };

            int floorCount = 0;

            Stack<int> whiteTilesAreas = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> greyTilesAreas = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (whiteTilesAreas.Count() > 0 && greyTilesAreas.Count() > 0)
            {
                int currWhiteTile = whiteTilesAreas.Peek();
                int currGreyTile = greyTilesAreas.Peek();

                if (currGreyTile == currWhiteTile)
                {
                    int sum = currWhiteTile + currGreyTile;

                    if (tilesAndLocations.ContainsKey(sum))
                    {
                        tilesAndLocations[sum]++;
                    }
                    else
                    {
                        floorCount++;
                    }

                    whiteTilesAreas.Pop();
                    greyTilesAreas.Dequeue();
                }
                else
                {
                    whiteTilesAreas.Push(whiteTilesAreas.Pop() / 2);
                    greyTilesAreas.Enqueue(greyTilesAreas.Dequeue());
                }
            }

            if (whiteTilesAreas.Count() == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTilesAreas)}");
            }

            if(greyTilesAreas.Count() == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTilesAreas)}");
            }

            Dictionary<string, int> finalDic = new Dictionary<string, int>()
            {
                ["Countertop"] = tilesAndLocations[60],
                ["Floor"] = floorCount,
                ["Oven"] = tilesAndLocations[50],
                ["Sink"] = tilesAndLocations[40],
                ["Wall"] = tilesAndLocations[70]
            };


            Dictionary<string, int> d = new Dictionary<string, int>(finalDic.OrderByDescending(x => x.Value).ThenBy(y => y.Key));

            foreach(var kvp in d)
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Placeholder
{
    class Program
    {
        static void Main(string[] args)// no idea
        {
            int numberOfFigures = int.Parse(Console.ReadLine());

            List<ulong[,,]> space = new List<ulong[,,]>();

            for(int i = 0; i < numberOfFigures;i++)
            {
                ulong[] newFigure = Console.ReadLine().Split(" ").Select(ulong.Parse).ToArray();
               
            }
        }
    }
}

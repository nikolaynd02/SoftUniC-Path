using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> handOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> handTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

            //bool firstWon = false;
            //bool secondWon = false;
            while(handOne.Count!=0 && handTwo.Count != 0)
            {
                if (handOne[0] > handTwo[0])
                {
                    handOne.Add(handTwo[0]);
                    handOne.Add(handOne[0]);
                    handOne.RemoveAt(0);
                    handTwo.RemoveAt(0);
                }
                else if(handOne[0] < handTwo[0])
                {
                    handTwo.Add(handOne[0]);
                    handTwo.Add(handTwo[0]);
                    handTwo.RemoveAt(0);
                    handOne.RemoveAt(0);
                }
                else
                {
                    handOne.RemoveAt(0);
                    handTwo.RemoveAt(0);
                }
                
                
            }

            if (handOne.Count > handTwo.Count)
            {
                Console.WriteLine($"First player wins! Sum: {handOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {handTwo.Sum()}");
            }
        }
    }
}

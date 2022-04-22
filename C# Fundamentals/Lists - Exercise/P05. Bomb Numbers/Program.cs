using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];
                       
            while(numbers.Contains(bomb))
            {
                for(int p = 0; p < power; p++)
                {
                    int bombPosition = numbers.FindIndex(currNum => currNum == bomb);

                    if (bombPosition + 1 < numbers.Count)
                    {
                        numbers.RemoveAt(bombPosition + 1);
                    }
                    if (bombPosition - 1 >= 0)
                    {
                        numbers.RemoveAt(bombPosition - 1);
                    }
                }

                numbers.Remove(bomb);
            }
            

            Console.WriteLine(numbers.Sum());
        }
    }
}

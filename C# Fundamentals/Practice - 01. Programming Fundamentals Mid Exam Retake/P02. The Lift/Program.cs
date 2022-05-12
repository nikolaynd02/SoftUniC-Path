using System;
using System.Linq;

namespace P02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for(int i = 0; i < lift.Length; i++)
            {
                if (peopleWaiting <= 0)
                {
                    peopleWaiting = 0;
                    break;
                }

                if (lift[i] < 4)
                {
                    if (peopleWaiting >= 4 - lift[i])
                    {
                        int peopleGettingIn = 4-lift[i];
                        lift[i] =lift[i]+peopleGettingIn;
                        peopleWaiting -= peopleGettingIn;
                    }
                    else
                    {
                        lift[i] = lift[i] + peopleWaiting;
                        peopleWaiting = 0;
                        
                    }
                }
            }

            if (peopleWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (lift.Sum() == 4 * lift.Length && peopleWaiting == 0)
            {
                Console.WriteLine(string.Join(" ", lift));
            }
            else
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", lift));
            }

        }
    }
}

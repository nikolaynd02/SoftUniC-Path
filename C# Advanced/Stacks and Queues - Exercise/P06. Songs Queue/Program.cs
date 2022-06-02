using System;
using System.Collections.Generic;

namespace P06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsToBeQueued = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songsToBeQueued);

            string[] cmd = { };

            while (songsQueue.Count > 0)
            {
                cmd = Console.ReadLine().Split(new[] {' '}, 2);

                if (cmd[0] == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if(cmd[0] == "Add")
                {
                    if (songsQueue.Contains(cmd[1]))
                    {
                        Console.WriteLine($"{cmd[1]} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(cmd[1]);
                    }
                }
                else if(cmd[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

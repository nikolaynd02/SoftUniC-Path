using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
           
            Dictionary<string,Vlogger> vloggers = new Dictionary<string, Vlogger>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = info[0];
                string action = info[1];
                string followedVlogger = info[2];

                if (action == "joined" && !vloggers.ContainsKey(vloggerName))
                {
                    vloggers[vloggerName] = new Vlogger();
                }
                else if(action == "followed" && vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followedVlogger) && vloggerName != followedVlogger)
                {
                    vloggers[vloggerName].Following.Add(followedVlogger);
                    vloggers[followedVlogger].Followers.Add(vloggerName);
                }
            }
            vloggers = vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count).ToDictionary(key => key.Key, value => value.Value);


            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 0;
            foreach(var vlogger in vloggers)
            {
                count++;

                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                if (count == 1)
                {
                    foreach(var follower in vlogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }                    
                }                
            }
        }
    }

    class Vlogger
    {
        public SortedSet<string> Followers = new SortedSet<string>();
    
        public SortedSet<string> Following = new SortedSet<string>();
    }
}

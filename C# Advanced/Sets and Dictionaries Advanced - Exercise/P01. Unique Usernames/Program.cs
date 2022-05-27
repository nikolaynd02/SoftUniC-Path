using System;
using System.Collections.Generic;

namespace P01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();

            int numOfNames = int.Parse(Console.ReadLine());

            for(int i = 0; i < numOfNames; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach(string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}

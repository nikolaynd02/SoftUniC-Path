using System;
using System.Collections.Generic;

namespace P05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Dictionary<string, string> usersVehicles = new Dictionary<string, string>();

            for(int i = 0; i < inputs; i++)
            {
                string[] userInfo = Console.ReadLine().Split(" ");

                string typeOfCmd = userInfo[0];
                string username = userInfo[1];

                if (typeOfCmd == "register")
                {
                    string licensePlate = userInfo[2];
                    if (usersVehicles.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {usersVehicles[username]}");
                    }
                    else
                    {
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                        usersVehicles[username] = licensePlate;
                    }

                }
                else
                {
                    if (usersVehicles.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        usersVehicles.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach(var kvp in usersVehicles)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}

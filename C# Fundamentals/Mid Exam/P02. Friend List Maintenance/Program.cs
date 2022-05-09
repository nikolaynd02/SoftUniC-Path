using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Friend_List_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nameList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] currCmd = command
                    .Split(" ");

                if (currCmd[0] == "Blacklist")
                {
                    int currnameIndex = nameList.IndexOf(currCmd[1]);
                    if (currnameIndex >= 0)
                    {
                        nameList.RemoveAt(currnameIndex);
                        nameList.Insert(currnameIndex, "Blacklisted");
                        Console.WriteLine($"{currCmd[1]} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{currCmd[1]} was not found.");
                    }
                }
                else if (currCmd[0] == "Error")
                {
                    if (CheckErrorIndex(int.Parse(currCmd[1]), nameList))
                    {
                        Console.WriteLine($"{nameList[int.Parse(currCmd[1])]} was lost due to an error.");
                        nameList[int.Parse(currCmd[1])] = "Lost";
                    }
                }
                else if(currCmd[0] == "Change")
                {
                    int currIndex = int.Parse(currCmd[1]);
                    if (currIndex >= 0 && currIndex < nameList.Count)
                    {
                        Console.WriteLine($"{nameList[currIndex]} changed his username to {currCmd[2]}.");
                        nameList[currIndex] = currCmd[2];
                    }
                }
            }

            int blacklistedCount = nameList.Count(x => x == "Blacklisted");
            int lostCount = nameList.Count(x => x == "Lost");

            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(" ", nameList));
                
        }

        static bool CheckErrorIndex(int index, List<string>nameList)
        {
            if (index >= 0 && index < nameList.Count)
            {
                if (nameList[index] != "Blacklisted" && nameList[index] != "Lost")
                {
                    return true;
                }
            }

            return false;
        }
    }
}

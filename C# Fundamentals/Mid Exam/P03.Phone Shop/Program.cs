using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Phone_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = string.Empty;

            string[] forSplit = { " - ", ":" };

            while ((command = Console.ReadLine()) != "End")
            {
                string[] currCmd = command.Split(forSplit,StringSplitOptions.None);
                if (currCmd[0] == "Add")
                {
                    if (!phoneList.Contains(currCmd[1]))
                    {
                        phoneList.Add(currCmd[1]);
                    }
                }
                else if(currCmd[0] == "Remove")
                {
                    if (phoneList.Contains(currCmd[1]))
                    {
                        phoneList.Remove(currCmd[1]);
                    }
                }
                else if(currCmd[0] == "Bonus phone")
                {
                    if (phoneList.Contains(currCmd[1]))
                    {
                        phoneList.Insert(phoneList.FindIndex(x => x == currCmd[1]) + 1, currCmd[2]);
                    }
                }
                else if (currCmd[0] == "Last")
                {
                    if (phoneList.Contains(currCmd[1]))
                    {
                        phoneList.Add(currCmd[1]);
                        phoneList.Remove(currCmd[1]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", phoneList));
        }
    }
}

using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<IIdentifiable> ids = new List<IIdentifiable>();

            while((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (info.Length == 3)
                {
                    Citizen citizen = new Citizen(info[0], info[1], info[2]);
                    ids.Add(citizen);
                }
                else
                {
                    Robot robot = new Robot(info[0], info[1]);
                    ids.Add(robot);
                }
            }

            string chackNum = Console.ReadLine();

            foreach(var id in ids)
            {
                if (!id.IsIdValid(chackNum))
                {
                    Console.WriteLine(id.Id);
                }
            }
        }
    }
}

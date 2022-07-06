using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int inputs = int.Parse(Console.ReadLine());

            while(inputs-- > 0)
            {
                BaseHero currHero;

                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if(type == "Druid")
                {
                    currHero = new Druid(name);
                    heroes.Add(currHero);
                }
                else if (type == "Paladin")
                {
                    currHero = new Paladin(name);
                    heroes.Add(currHero);
                }
                else if (type == "Rogue")
                {
                    currHero = new Rogue(name);
                    heroes.Add(currHero);
                }
                else if (type == "Warrior")
                {
                    currHero = new Warrior(name);
                    heroes.Add(currHero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    inputs++;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalPower = 0;

            foreach(var currHero in heroes)
            {
                Console.WriteLine(currHero.CastAbility());
                totalPower += currHero.Power;
            }

            if(totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

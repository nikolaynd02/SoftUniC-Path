using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public void CastSpell(int neededMP, string spellName)
        {
            if (this.MP >= neededMP)
            {
                this.MP -= neededMP;
                Console.WriteLine($"{this.Name} has successfully cast {spellName} and now has {this.MP} MP!");
            }
            else
            {
                Console.WriteLine($"{this.Name} does not have enough MP to cast {spellName}!");
            }
        }

        public void TakeDamage(int damage, string attacker)
        {
            this.HP -= damage;

            if (this.HP > 0)
            {
                Console.WriteLine($"{this.Name} was hit for {damage} HP by {attacker} and now has {this.HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{this.Name} has been killed by {attacker}!");
            }
        }

        public void Recharge(int amount)
        {
            this.MP += amount;

            if (this.MP > 200)
            {
                Console.WriteLine($"{this.Name} recharged for {amount - (this.MP - 200)} MP!");
                this.MP = 200;
            }
            else
            {
                Console.WriteLine($"{this.Name} recharged for {amount} MP!");
            }
        }

        public void Heal(int amount)
        {
            this.HP += amount;


            if (this.HP > 100)
            {
                Console.WriteLine($"{this.Name} healed for {amount - (this.HP - 100)} HP!");
                this.HP = 100;
            }
            else
            {
                Console.WriteLine($"{this.Name} healed for {amount} HP!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numOfHeroes = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for(int i = 0; i < numOfHeroes; i++)
            {
                string[] heroinfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string name = heroinfo[0];
                int HP = int.Parse(heroinfo[1]);
                int MP = int.Parse(heroinfo[2]);

                Hero currHero = new Hero()
                {
                    Name = name,
                    HP = HP,
                    MP = MP
                };

                heroes.Add(currHero);
            }

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] actionInfo = cmd.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string actionName = actionInfo[0];
                string hero = actionInfo[1];

                int index = heroes.FindIndex(x => x.Name == hero);

                if(actionName == "CastSpell")
                {
                    int neededMP = int.Parse(actionInfo[2]);
                    string spellName = actionInfo[3];
                    heroes[index].CastSpell(neededMP, spellName);
                }
                else if(actionName == "TakeDamage")
                {
                    int damage = int.Parse(actionInfo[2]);
                    string attacker = actionInfo[3];
                    heroes[index].TakeDamage(damage, attacker);

                    if (heroes[index].HP <= 0)
                    {
                        heroes.RemoveAt(index);
                    }
                }
                else if (actionName == "Recharge")
                {
                    int amount = int.Parse(actionInfo[2]);
                    heroes[index].Recharge(amount);
                }
                else if (actionName == "Heal")
                {
                    int amount = int.Parse(actionInfo[2]);
                    heroes[index].Heal(amount);
                }
            }

            foreach(Hero currHero in heroes)
            {
                Console.WriteLine(currHero.Name);
                Console.WriteLine($"  HP: {currHero.HP}");
                Console.WriteLine($"  MP: {currHero.MP}");
            }
        }
    }
}

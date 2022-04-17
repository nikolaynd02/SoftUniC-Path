using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {            
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokes = 0;

            int startingPower = pokePower;

            for (; pokePower >= distance; pokePower -= distance)
            {
                pokes++;

                if (pokePower == startingPower / 2 && startingPower % 2 == 0 && exhaustionFactor!=0)
                {
                    pokePower /= exhaustionFactor;
                    
                    if (pokePower < distance)
                    {
                        pokes--;
                        break;
                    }
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCmd = int.Parse(Console.ReadLine());

            List<string> attPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for(int i = 0; i < numOfCmd; i++)
            {
                string encryptedMessage = Console.ReadLine();

                string message = DecryptMessage(encryptedMessage);

                string pattern = @"@(?<planet>[A-Z][a-z]+)[^\@\-\!\:\>]*?:(?<population>\d+)[^\@\-\!\:\>]*?!(?<attack>[A|D])![^\@\-\!\:\>]*?->(?<soldierCount>\d+)";

                Match info = Regex.Match(message, pattern);

                if (!info.Success)
                {
                    continue;
                }

                string planet = info.Groups["planet"].Value;
                string attackType = info.Groups["attack"].Value;

                if (attackType == "D")
                {
                    destroyedPlanets.Add(planet);
                }
                else
                {
                    attPlanets.Add(planet);
                }

            }

            destroyedPlanets.Sort();
            attPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attPlanets.Count}");
            foreach(string planet in attPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach(string planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

        }

        static string DecryptMessage(string encryptedMessage)
        {
            int key = GetDecriptionKey(encryptedMessage);

            StringBuilder decryptedMessage = new StringBuilder();

            foreach(char currCh in encryptedMessage)
            {
                decryptedMessage.Append((char)(currCh - key));
            }

            return decryptedMessage.ToString();
        }

        static int GetDecriptionKey(string encryptedMessage)
        {
            string pattern = @"[star]{1}";

            MatchCollection match = Regex.Matches(encryptedMessage, pattern, RegexOptions.IgnoreCase);

            return match.Count;
        }
    }
}

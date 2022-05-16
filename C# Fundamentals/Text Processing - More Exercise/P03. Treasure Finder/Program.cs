using System;
using System.Linq;
using System.Text;

namespace P03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string input = string.Empty;
            int currKey = 0;
            while ((input=Console.ReadLine()) != "find")
            {
                currKey = 0;

                StringBuilder decodedText = new StringBuilder();
                foreach(char symbol in input)
                {
                    decodedText.Append((char)(symbol - key[currKey%key.Length]));

                    currKey++;
                }

                string text = decodedText.ToString();

                int materialIndexStart = text.IndexOf('&') + 1;
                int materiaIndexEnd = text.LastIndexOf('&');
                string material = text.Substring(materialIndexStart, materiaIndexEnd - materialIndexStart);

                int cordinateIndexStart = text.IndexOf('<') + 1;
                int cordinateIndexEnd = text.LastIndexOf('>');
                string cordinates = text.Substring(cordinateIndexStart, cordinateIndexEnd - cordinateIndexStart);

                Console.WriteLine($"Found {material} at {cordinates}");
            }

        }
    }
}

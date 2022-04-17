using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int firstLetter = 97; firstLetter < 97 + n; firstLetter++)
            {
                for (int secondLetter = 97; secondLetter < 97 + n; secondLetter++)
                {
                    for (int thirdLetter = 97; thirdLetter < 97 + n; thirdLetter++)
                    {
                        char one = (char)firstLetter;
                        char two = (char)secondLetter;
                        char three = (char)thirdLetter;
                        Console.WriteLine($"{one}{two}{three}");
                    }
                }
            }
        }
    }
}

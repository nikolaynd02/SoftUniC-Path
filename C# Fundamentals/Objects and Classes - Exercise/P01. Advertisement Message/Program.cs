using System;
using System.Collections.Generic;

namespace P01._Advertisement_Message
{   
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrase = new List<string>()
            {
                "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };

            List<string> events = new List<string>()
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            List<string> authors = new List<string>()
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            List<string> cities = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            int numOfMessages = int.Parse(Console.ReadLine());

            Random random = new Random();

            for(int i = 0; i < numOfMessages; i++)
            {
                int phraseIndex = random.Next(0, phrase.Count);
                int eventsIndex = random.Next(0, events.Count);
                int authorsIndex = random.Next(0, authors.Count);
                int citiesIndex = random.Next(0, cities.Count);

                Console.WriteLine($"{phrase[phraseIndex]} {events[eventsIndex]} {authors[authorsIndex]} – {cities[citiesIndex]}.");
            }
        }
    }
}

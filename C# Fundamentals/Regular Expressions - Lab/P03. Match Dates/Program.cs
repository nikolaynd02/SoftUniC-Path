using System;
using System.Text.RegularExpressions;

namespace P03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<day>\d{2})([/|\-|.])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            string dates = Console.ReadLine();

            MatchCollection validDates = Regex.Matches(dates, pattern);

            foreach(Match date in validDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }

        }
    }
}

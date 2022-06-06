using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            DateModifier date = new DateModifier();

            Console.WriteLine(date.GetDiffInDays(dateOne, dateTwo));
        }
    }
}

using System;
using System.Collections.Generic;

namespace P08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> companiesEmploees = new Dictionary<string, List<string>>();

            while(input != "End")
            {
                string[] employeeInfo = input.Split(" -> ");
                string company = employeeInfo[0];
                string iD = employeeInfo[1];

                if (!companiesEmploees.ContainsKey(company))
                {
                    companiesEmploees[company] = new List<string>();
                }

                if (!companiesEmploees[company].Contains(iD))
                {
                    companiesEmploees[company].Add(iD);
                }

                input = Console.ReadLine();
            }

            foreach(var company in companiesEmploees)
            {
                Console.WriteLine($"{company.Key}");
                foreach(string employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}

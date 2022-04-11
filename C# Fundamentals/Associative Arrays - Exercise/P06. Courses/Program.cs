using System;
using System.Collections.Generic;

namespace P06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input != "end")
            {
                string[] studentInfo = input.Split(" : ");

                string course = studentInfo[0];
                string studentName = studentInfo[1];

                if (courses.ContainsKey(course))
                {
                    courses[course].Add(studentName);
                }
                else
                {
                    courses[course] = new List<string> { studentName };
                }

                input = Console.ReadLine();
            }

            foreach(var kvp in courses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach(string student in kvp.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}

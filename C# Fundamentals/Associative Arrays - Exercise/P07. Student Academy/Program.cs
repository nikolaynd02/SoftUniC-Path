using System;
using System.Collections.Generic;
using System.Linq;

namespace P07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairs = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            for(int i = 0; i < pairs; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades[student] = new List<double>();
                }

                studentsGrades[student].Add(grade);
            }

            Dictionary<string, double> sortedStudentGrades = studentsGrades.Where(x => x.Value.Average() >= 4.50).ToDictionary(x => x.Key,x =>x.Value.Average());


            foreach(var student in sortedStudentGrades)
            {                                 
                        Console.WriteLine($"{student.Key} -> {student.Value:f2}");                
            }
        }
    }
}

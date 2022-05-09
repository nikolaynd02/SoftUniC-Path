using System;
using System.Collections.Generic;
using System.Linq;

namespace P04._Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for(int i = 0; i < numOfStudents; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student newStudent = new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Grade = double.Parse(studentInfo[2])
                };

                students.Add(newStudent);
            }

            List<Student> sortedStudents = students.OrderByDescending(x => x.Grade).ToList();

            foreach(Student currStudent in sortedStudents)
            {
                Console.WriteLine($"{currStudent.FirstName} {currStudent.LastName}: {currStudent.Grade:f2}");
            }
        }
    }
}

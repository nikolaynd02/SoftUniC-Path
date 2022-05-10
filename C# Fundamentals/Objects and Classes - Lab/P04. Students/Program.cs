using System;
using System.Collections.Generic;

namespace P04._Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Student> students = new List<Student>();

            while (studentInfo[0] != "end")
            {
                Student currStudent = new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Age = int.Parse(studentInfo[2]),
                    HomeTown = studentInfo[3]
                };

                students.Add(currStudent);

                studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string city = Console.ReadLine();

            List<Student> studentsFromGivenCity = students.FindAll(x => x.HomeTown == city);

            foreach(Student currStudent in studentsFromGivenCity)
            {
                Console.WriteLine($"{currStudent.FirstName} {currStudent.LastName} is {currStudent.Age} years old.");
            }
        }
    }
}

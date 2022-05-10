using System;
using System.Collections.Generic;

namespace P05._Students_2._0
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
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string hometown = studentInfo[3];

                if (DoesStudentExist(students, studentInfo[0], studentInfo[1]))
                {
                    var existingStudent = GetExistingStudent(students, firstName, lastName);

                    existingStudent.Age = age;
                    existingStudent.HomeTown = hometown;
                }
                else
                {
                    Student currStudent = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = hometown
                    };
                    students.Add(currStudent);
                }

                studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string city = Console.ReadLine();

            List<Student> studentsFromGivenCity = students.FindAll(x => x.HomeTown == city);

            foreach (Student currStudent in studentsFromGivenCity)
            {
                Console.WriteLine($"{currStudent.FirstName} {currStudent.LastName} is {currStudent.Age} years old.");
            }
        }

        static bool DoesStudentExist(List<Student> students, string firstName, string lastName)
        {
            foreach(Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static Student GetExistingStudent(List<Student> students, string firstName, string lastName)
        {
            foreach(Student student in students)
            {
                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    return student;
                }
            }

            return null;
        }
    }
}

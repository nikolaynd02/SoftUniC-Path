using System;
using System.Collections.Generic;
using System.Linq;

namespace P10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] currinput = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while(currinput[0]!="course start")
            {
                if (currinput[0] == "Add")
                {
                    AddLesson(lessons, currinput[1]);
                }
                else if(currinput[0] == "Insert")
                {
                    InsertLessonAdindex(lessons, currinput[1], int.Parse(currinput[2]));
                }
                else if (currinput[0] == "Remove")
                {
                    RemoveGivenLesson(lessons, currinput[1]);
                }
                else if(currinput[0] == "Swap")
                {
                    SwapLessons(lessons, currinput[1], currinput[2]);
                }
                else if(currinput[0] == "Exercise")
                {
                    AddExercise(lessons, currinput[1]);
                }

                currinput = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            for(int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }

        static void AddLesson(List<string> lessons, string lessonTitle)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Add(lessonTitle);
            }
        }

        static void InsertLessonAdindex(List<string> lessons, string lessonTitle, int index)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Insert(index, lessonTitle);
            }
        }

        static void RemoveGivenLesson(List<string> lessons, string lessonTitle)
        {
            if (lessons.Contains(lessonTitle))
            {
                lessons.Remove(lessonTitle);
                if(lessons.Contains("Exercise:" + lessonTitle))
                {
                    lessons.Remove("Exercise:" + lessonTitle);
                }
            }
        }

        static void SwapLessons(List<string> lessons, string firstLesson, string secondLesson)
        {
            if (lessons.Contains(firstLesson) && lessons.Contains(secondLesson))
            {
                int indexOfFirstLesson = lessons.IndexOf(firstLesson);
                int indexOfSecondLesson = lessons.IndexOf(secondLesson);                

                lessons[indexOfSecondLesson] = firstLesson;
                if (lessons.Contains(secondLesson + "-Exercise"))
                {
                    lessons.Insert(indexOfFirstLesson + 1, secondLesson + "-Exercise");
                    lessons.RemoveAt(indexOfSecondLesson + 2);
                }

                lessons[indexOfFirstLesson] = secondLesson;
                if(lessons.Contains(firstLesson + "-Exercise"))
                {
                    lessons.Insert(indexOfSecondLesson + 2, firstLesson + "-Exercise");
                    lessons.RemoveAt(indexOfFirstLesson + 2);
                }
            }
        }

        static void AddExercise(List<string> lessons,string lessonTitle)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Add(lessonTitle);
                lessons.Add(lessonTitle + "-Exercise");
            }
            else if(!lessons.Contains(lessonTitle + "-Exercise"))
            {
                int ExerciseIndex = lessons.FindIndex(currLesson => currLesson == lessonTitle) + 1;

                lessons.Insert(ExerciseIndex, lessonTitle + "-Exercise");
            }         
        }
    }
}

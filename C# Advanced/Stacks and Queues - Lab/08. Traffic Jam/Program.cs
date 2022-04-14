using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsAbleToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string car = string.Empty;

            int count = 0;

            while((car = Console.ReadLine()) != "end")
            {
                if(car == "green")
                {
                    for(int i = 0; i < carsAbleToPass; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

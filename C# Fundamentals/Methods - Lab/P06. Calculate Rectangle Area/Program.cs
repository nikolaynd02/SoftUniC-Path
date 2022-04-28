using System;

namespace P06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateRectangleArea(height, width));
        }

        static int CalculateRectangleArea(int height,int width)
        {
            return height * width;
        }
    }
}

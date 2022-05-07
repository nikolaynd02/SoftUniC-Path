using System;

namespace P03._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintClosestPoint(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void PrintClosestPoint(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double lenght1 = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double lenght2 = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));

            if (lenght1 >= lenght2)
            {
                double close1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
                double close2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

                if (close1 <= close2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }              
            }
            else
            {
                double close1 = Math.Sqrt(Math.Pow(x3, 2) + Math.Pow(y3, 2));
                double close2 = Math.Sqrt(Math.Pow(x4, 2) + Math.Pow(y4, 2));

                if (close1 <= close2)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
    }
}

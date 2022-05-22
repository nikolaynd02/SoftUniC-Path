using System;

namespace ConsoleApp14
{
    class Program
    {
        static void Main()
        {
            byte decriptionInput = byte.Parse(Console.ReadLine());
            byte Count = byte.Parse(Console.ReadLine());
            string message = "";

            while (Count > 0)
            {
                message += ((char)(char.Parse(Console.ReadLine()) + decriptionInput)).ToString();

                Count--;
            }

            Console.WriteLine(message);
        }
    }
}
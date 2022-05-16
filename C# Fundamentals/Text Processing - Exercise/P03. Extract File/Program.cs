using System;

namespace P03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split((char)92);

            string[] file = path[^1].Split('.');

            string fileNme = file[0];
            string extension = file[1];

            Console.WriteLine($"File name: {fileNme}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}

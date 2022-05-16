using System;

namespace P05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            Console.WriteLine($"<h1>\n\t{title}\n</h1>");
            string article = Console.ReadLine();
            Console.WriteLine($"<article>\n\t{article}\n</article>");

            string comment = string.Empty;

            while((comment=Console.ReadLine())!= "end of comments")
            {
                Console.WriteLine($"<div>\n\t{comment}\n</div>");
            }
        }
    }
}

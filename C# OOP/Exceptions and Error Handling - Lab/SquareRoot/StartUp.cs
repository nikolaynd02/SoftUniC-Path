using System;

namespace SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                int sqr = (int)Math.Sqrt(num);

                Console.WriteLine(sqr);

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}

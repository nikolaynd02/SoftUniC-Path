using System;

namespace Sum_of_odd_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int counter = 0;

            int sum = 0;
            for(int i = 1; i<100; i++)
            {
                if (i % 2 == 1)
                {

                    Console.WriteLine(i);
                    sum += i;
                    counter++;
                    
                }
                if (counter == input)
                {
                    break;
                }
            }

            Console.WriteLine("Sum: "+sum);
        }
    }
}

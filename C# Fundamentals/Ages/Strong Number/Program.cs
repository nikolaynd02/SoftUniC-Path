using System;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int check = num;
            int total = 0;
            int sum = 1;
            while (num!=0)
            {
                int digit = num % 10;
                sum = 1;

                for (int i = 1; i <= digit; i++)
                {
                    sum = sum * i;
                }
                
                total += sum;

                num = (num - digit) / 10;
            }

            if (check == total)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

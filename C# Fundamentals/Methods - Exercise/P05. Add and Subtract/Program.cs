using System;

namespace P05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum=GetSum(num1, num2);
            Console.WriteLine(GetDiff(sum, num3));
        }

        static int GetSum(int num1,int num2)
        {
            return num1 + num2;
        }
        static int GetDiff(int sum,int num)
        {
            return sum - num;
        }

    }
}

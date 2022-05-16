using System;
using System.Text;

namespace P05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int remain = 0;
            for(int i = number.Length - 1; i >= 0; i--)
            {
                int toAdd = ((int.Parse(number[i].ToString())) * multiplier)+remain;
                remain = toAdd / 10;
                toAdd %= 10;
                result.Insert(0, toAdd.ToString());
            }

            if (remain > 0)
            {
                result.Insert(0, remain.ToString());
            }

            Console.WriteLine(result);
        }
    }
}

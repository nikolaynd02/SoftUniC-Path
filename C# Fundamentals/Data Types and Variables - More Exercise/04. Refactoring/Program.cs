using System;

namespace _04._Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int startNum = 2; startNum <= num; startNum++)
            {
                bool checkNumPrime = true;
                for (int devider = 2; devider < startNum; devider++)
                {
                    if (startNum % devider == 0)
                    {
                        checkNumPrime = false;
                        break;
                    }
                }
                if (checkNumPrime)
                {
                    Console.WriteLine($"{startNum} -> true");
                }
                else
                {
                    Console.WriteLine($"{startNum} -> alse");
                }
            }
        }
    }
}

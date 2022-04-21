using System;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int repeats = 1; repeats <= n; repeats++)
            {
                string input = Console.ReadLine();

                long firstNum = 0;
                long secondNum = 0;
                string number = string.Empty;

                int firstNumDigits = 0;
                int secondNumDigits = 0;
            
                for(int i = 0; i < input.Length;++i) 
                {
                    number += input[i];
                    if(input[i]==' ')
                    {
                        firstNumDigits =number.Length-1;
                        firstNum = long.Parse(number);
                        number = string.Empty;
                    }
                    else if (i == input.Length-1)
                    {
                        secondNumDigits = number.Length;
                        secondNum = long.Parse(number);
                        break;
                    }
                }

                long sum = 0;

                if (firstNum > secondNum)
                {
                    for(int i = 1; i <= firstNumDigits; i++)
                    {
                        sum += firstNum % 10;
                        firstNum = (firstNum - firstNum % 10) / 10;
                    }                    
                }
                else
                {
                    for (int i = 1; i <= secondNumDigits; i++)
                    {
                        sum += secondNum % 10;
                        secondNum = (secondNum - secondNum % 10) / 10;
                    }                    
                }
                if (sum < 0)
                {
                    sum = sum * (-1);
                }
                Console.WriteLine(sum);
                sum = 0;
            }
           
        }
    }
}

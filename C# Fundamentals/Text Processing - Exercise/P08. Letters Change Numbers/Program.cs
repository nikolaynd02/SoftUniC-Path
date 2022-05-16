using System;
using System.Text;

namespace P08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0m;

            for(int i = 0; i < input.Length; i++)
            {
                string currInput = input[i];
                char firstLetter = 'a';
                string strNumber = string.Empty;
                char lastLetter = 'a';
                for(int p = 0; p < currInput.Length; p++)
                {
                    if (p == 0)
                    {
                        firstLetter = currInput[p];
                    }
                    else if (p > 0 && p < currInput.Length - 1)
                    {
                        strNumber += (currInput[p]);
                    }
                    else
                    {
                        lastLetter = currInput[p];
                    }
                }

                decimal number = decimal.Parse(strNumber);
                decimal firstSum = 0m;
                decimal secondSum = 0m;

                if (IsUpperCase(firstLetter))
                {
                    firstSum = number / (firstLetter - 64);
                }
                else
                {
                    firstSum = number * (firstLetter - 96);
                }

                if (IsUpperCase(lastLetter))
                {
                    secondSum = firstSum - (lastLetter - 64);
                }
                else
                {
                    secondSum = firstSum + (lastLetter - 96);
                }

                sum += secondSum;
            }

            Console.WriteLine($"{sum:f2}");
        }


        static bool IsUpperCase(char letter)
        {
            if(char.IsUpper(letter))
            {
                return true;
            }

            return false;
        }
    }
}

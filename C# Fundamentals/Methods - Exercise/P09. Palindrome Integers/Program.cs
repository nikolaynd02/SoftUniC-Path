using System;

namespace P09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                int number = int.Parse(input);
                Console.WriteLine(CheckIfPalindrome(number));
                input = Console.ReadLine();
            }
        }

        static bool CheckIfPalindrome(int number)
        {
            string strNum = number.ToString();
            int[] firstNum = new int[strNum.Length];
            int[] secondNum = new int[strNum.Length];

            for(int i = 0; i < strNum.Length; i++)
            {
                firstNum[i] = strNum[i];
            }
            for(int i = strNum.Length - 1; i >= 0; i--)
            {
                secondNum[strNum.Length-i-1] = strNum[i];
            }
            
            for(int i = 0; i < firstNum.Length; i++)
            {
                if (firstNum[i] != secondNum[i])
                {
                    return false;
                }
            
            }
            return true;
        }
    }
}

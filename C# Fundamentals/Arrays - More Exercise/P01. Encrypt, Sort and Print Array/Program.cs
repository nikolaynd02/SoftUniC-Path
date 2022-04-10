using System;

namespace Arrays___More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            int[] sums = new int[inputLines];
            string input = string.Empty;
            for(int i=0;i<inputLines; i++)
            {
                int vowelSum = 0;
                int consonantSum = 0;
                foreach(char letter in (input=Console.ReadLine()))
                {
                    bool isVowel = "aeiouAEIOU".IndexOf(letter)>=0;
                    if (isVowel)
                    {
                        vowelSum += letter * input.Length;
                    }
                    else
                    {
                        consonantSum += letter / input.Length;
                    }
                }
                sums[i] = vowelSum + consonantSum;
            }
            Array.Sort(sums);
            foreach(int sum in sums)
            {
                Console.WriteLine(sum);
            }
        }
    }
}

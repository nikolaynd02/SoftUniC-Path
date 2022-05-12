using System;
using System.Linq;
using System.Text;

namespace P01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "Done")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmd[0];
                if (cmdType == "TakeOdd")
                {
                    password = TakeOddIndices(password);
                    Console.WriteLine(password);
                }
                else if (cmdType == "Cut")
                {
                    int index = int.Parse(cmd[1]);
                    int lenght = int.Parse(cmd[2]);
                    password = CutSubstringOnce(password, index, lenght);
                    Console.WriteLine(password);
                }
                else if(cmdType == "Substitute")
                {
                    string oldWord = cmd[1];
                    string newWord = cmd[2];
                    if (password.Contains(oldWord))
                    {
                        password = Replace(password, oldWord, newWord);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }

        static string TakeOddIndices(string password)
        {
            StringBuilder newPass = new StringBuilder();

            for(int i = 1; i < password.Length; i += 2)
            {
                newPass.Append(password[i]);
            }

            return newPass.ToString();
        }

        static string CutSubstringOnce(string password,int index,int lenght)
        {
            string toRemove = password.Substring(index, lenght);

            int indexToRemove = password.IndexOf(toRemove);

            return password.Remove(indexToRemove, lenght);
        }

        static string Replace(string password,string oldWord, string newWord)
        {
            return password.Replace(oldWord, newWord);
        }
    }
}

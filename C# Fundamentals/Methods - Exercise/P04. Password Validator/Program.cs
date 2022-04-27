using System;

namespace P04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool validPasssword = true;
            if (!CheckPassword(password).Item1)
            {
                validPasssword = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (CheckPassword(password).Item2)
            {
                validPasssword = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (CheckPassword(password).Item3 < 2)
            {
                validPasssword = false;
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (validPasssword)
            {
                Console.WriteLine("Password is valid");
            }
        }

        
        static Tuple<bool,bool,int> CheckPassword(string password)
        {
            bool validLenght = true;
            if (password.Length < 6 || password.Length > 10)
            {
                validLenght = false;
            }

            int numsCounter = 0;
            bool symbolsOutsideOfLimit = false;

            for(int i = 0; i < password.Length; i++)
            {
                if((char)password[i]>=48 && (char)password[i] <= 57)
                {
                    numsCounter++;
                }
                else if(((char)password[i] >= 65 && (char)password[i] <= 90)||((char)password[i] >= 97 && (char)password[i] <= 122))
                {

                }
                else
                {
                    symbolsOutsideOfLimit = true;
                }
            }

            return Tuple.Create(validLenght, symbolsOutsideOfLimit, numsCounter);

        }
    }
}

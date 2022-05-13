using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int length = username.Length - 1;
            while (length >= 0)
            {
                password += username[length];
                length--;
            }

            int counter = 1;

            while (true)
            {
                string check = Console.ReadLine();

                if (check == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    counter++;
                }

            }


        }
    }
}

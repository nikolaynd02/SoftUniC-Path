using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int openingBracket = 0;
            int closingBracket = 0;
            bool unbalanced = false;
            while (lines > 0)
            {
                string input = Console.ReadLine();

                char bracket = '\0';
                if(char.TryParse(input,out bracket))
                {
                    bracket = char.Parse(input);
                    if (bracket == '(')
                    {
                        openingBracket++;
                    }
                    else if (bracket == ')')
                    {
                        closingBracket++;
                    }

                    if (openingBracket>closingBracket+1||closingBracket>openingBracket)
                    {
                        Console.WriteLine("UNBALANCED");
                        unbalanced = true;
                        break;
                    }
                }

                lines--;
            }

            if (openingBracket == closingBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else if (openingBracket != closingBracket && !unbalanced)
            {
                Console.WriteLine("UNBALANCED");
            }

        }
    }
}

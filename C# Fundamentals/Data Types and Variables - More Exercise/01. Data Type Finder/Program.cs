using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            // simplify
            string input = Console.ReadLine();

            while (input != "END")
            {
                
                int dots = 0;
                int minuses = 0;
                int numbers = 0;

                

                for(int i = 0; i < input.Length; i++)
                {                    
                    switch ((char)input[i])
                    {
                        case '.':
                            dots++;
                            break;
                        case '-':
                            minuses++;
                            break;
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            numbers++;
                            break;
                    }
                }

                if (input.Length == 1 && numbers == 0)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (numbers + minuses == input.Length && input[0] == '-' && minuses==1 || numbers==input.Length)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (input.ToLower()== "false" || input.ToLower() == "true")
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (minuses<2&&dots<2&&numbers + dots + minuses == input.Length && input[0] == '-' && input[1] != '.' &&numbers>=2|| numbers + dots == input.Length && input[0] != '.' && input[input.Length-1]!='.' && numbers >= 2 && dots<2)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}

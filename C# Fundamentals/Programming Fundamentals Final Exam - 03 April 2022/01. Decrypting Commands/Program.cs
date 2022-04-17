using System;

namespace _01._Decrypting_Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretInput = Console.ReadLine();

            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "Finish")
            {
                string[] cmdInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdInfo[0];

                if (cmdType == "Replace")
                {
                    char oldCh = cmdInfo[1].ToCharArray()[0];
                    char newCh = cmdInfo[2].ToCharArray()[0];

                    secretInput = secretInput.Replace(oldCh, newCh);

                    Console.WriteLine(secretInput);
                }
                else if(cmdType == "Cut")
                {
                    int startIndex = int.Parse(cmdInfo[1]);
                    int endIndex = int.Parse(cmdInfo[2]);


                    if (startIndex >= 0 && startIndex < secretInput.Length && endIndex>=0 && endIndex < secretInput.Length)
                    {
                        secretInput = secretInput.Remove(startIndex, (endIndex - startIndex) + 1);

                        Console.WriteLine(secretInput);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid indices!");
                    }
                }
                else if (cmdType == "Make")
                {
                    string upOrLow = cmdInfo[1];
                    if (upOrLow == "Upper")
                    {
                        secretInput = secretInput.ToUpper();
                    }
                    else
                    {
                        secretInput = secretInput.ToLower();
                    }

                    Console.WriteLine(secretInput);
                }
                else if (cmdType == "Check")
                {
                    string strToCheck = cmdInfo[1];

                    if (secretInput.Contains(strToCheck))
                    {
                        Console.WriteLine($"Message contains {strToCheck}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {strToCheck}");
                    }
                }
                else if (cmdType == "Sum")
                {
                    int startIndex = int.Parse(cmdInfo[1]);
                    int endIndex = int.Parse(cmdInfo[2]);

                    if(startIndex >= 0 && startIndex < secretInput.Length && endIndex >= 0 && endIndex < secretInput.Length)
                    {
                        string substring = secretInput.Substring(startIndex, (endIndex - startIndex) + 1);

                        int sum = 0;

                        foreach(char currCh in substring)
                        {
                            sum += currCh;
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
            }


            int a = 10;
            int b = 20;
            int c = a > b ? a : b;
            Console.WriteLine(c);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morseCodeWords = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries);

            StringBuilder text = new StringBuilder();
            
            foreach(string morseCodeWord in morseCodeWords)
            {
                string[] morseCodeLetters = morseCodeWord.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                foreach(string morseCodeLetter in morseCodeLetters)
                {
                    char currLetter = MorseCodeFindLetter(morseCodeLetter);

                    text.Append(currLetter);
                }

                text.Append(' ');
            }

            Console.WriteLine(text);
        }

        static char MorseCodeFindLetter(string code)
        {
            Dictionary<string, char> letters = new Dictionary<string, char>()
            {
                {".-", 'A'},
                {"-...", 'B'},
                {"-.-.", 'C'},
                {"-..", 'D'},
                {".", 'E'},
                {"..-.", 'F'},
                {"--.", 'G'},
                {"....", 'H'},
                {"..", 'I'},
                {".---", 'J'},
                {"-.-", 'K'},
                {".-..", 'L'},
                {"--", 'M'},
                {"-.", 'N'},
                {"---", 'O'},
                {".--.", 'P'},
                {"--.-", 'Q'},
                {".-.", 'R'},
                {"...", 'S'},
                {"-", 'T'},
                {"..-", 'U'},
                {"...-", 'V'},
                {".--", 'W'},
                {"-..-", 'X'},
                {"-.--", 'Y'},
                {"--..", 'Z'}
            };

            return letters[code];

        }
    }
}

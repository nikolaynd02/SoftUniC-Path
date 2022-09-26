using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<string> wordArray = new List<string>();
    public static void Main()
    {
        string word = Console.ReadLine();
        string toConvertTo = Console.ReadLine();
        if (word.Length != toConvertTo.Length || ContainsOtherLetter(word, toConvertTo))
        {
            Console.WriteLine("The name cannot be transformed!");
            return;
        }
        GetWordToArray(word);
        int count = 0;
        if (ContainsMoreThanOneLetter(word, toConvertTo))
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (GetWordArrayToString() == toConvertTo)
                {
                    Console.WriteLine($"The minimum operations required to convert \"{word}\" to \"{toConvertTo}\" are {count}");
                    return;
                }
                char c = toConvertTo[i];
                if (word[i] != toConvertTo[i])
                {
                    wordArray.RemoveAt(i);
                    wordArray.Insert(i, c.ToString());
                    count++;
                }
                else
                {
                    wordArray[i] = c.ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (GetWordArrayToString() == toConvertTo)
                {
                    Console.WriteLine($"The minimum operations required to convert \"{word}\" to \"{toConvertTo}\" are {count}");
                    return;
                }
                char c = toConvertTo[i];
                wordArray.Remove(c.ToString());
                wordArray.Insert(i, c.ToString());
                count++;
            }
        }
        if (GetWordArrayToString() == toConvertTo)
        {
            Console.WriteLine($"The minimum operations required to convert \"{word}\" to \"{toConvertTo}\" are {count}");
            return;
        }
        Console.WriteLine("The name cannot be transformed!");
    }
    public static bool ContainsMoreThanOneLetter(string word, string toConvertTo)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (wordArray.Where(x => x == toConvertTo[i].ToString()).Count() > 1)
            {
                return true;
            }
        }
        return false;
    }
    public static void GetWordToArray(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            wordArray.Add(word[i].ToString());
        }
    }
    public static string GetWordArrayToString()
    {
        return string.Join("", wordArray);
    }
    public static bool ContainsOtherLetter(string word, string toConvertTo)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (!toConvertTo.Contains(word[i].ToString()))
            {
                return true;
            }
        }
        for (int i = 0; i < word.Length; i++)
        {
            if (!word.Contains(toConvertTo[i].ToString()))
            {
                return true;
            }
        }
        return false;
    }
}
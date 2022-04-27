using System;
using System.Linq;

namespace P11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    ExchangeFromIndex(inputArr, int.Parse(command[1]));
                }
                else if (command[0] == "max")
                {
                    int index = ReturnMaxEvenOrOddIndex(inputArr, command[1]);
                    if (index >= 0)
                    {
                        Console.WriteLine(index);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (command[0] == "min")
                {
                    int index = ReturnMinEvenOrOddIndex(inputArr, command[1]);
                    if (index >= 0)
                    {
                        Console.WriteLine(index);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (command[0] == "first")
                {
                    string output = ReturnFirstElementsThatAreEvenOrOdd(inputArr, int.Parse(command[1]), command[2]);
                    if(output== "Invalid count")
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        Console.WriteLine($"[{output}]");
                    }
                }
                else if (command[0] == "last")
                {
                    string output = ReturnLastElementsThatAreEvenOrOdd(inputArr, int.Parse(command[1]), command[2]);
                    if (output == "Invalid count")
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        Console.WriteLine($"[{output}]");
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", inputArr)}]");
        }

        static int[] ExchangeFromIndex(int[] numArr,int index)
        {
            if (index >= numArr.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return numArr;
            }            

            int[] leftNums = new int[index + 1];
            int[] rightNums = new int[numArr.Length - index - 1];

            for(int i = 0; i < leftNums.Length; i++)
            {
                leftNums[i] = numArr[i];
            }

            for(int i = numArr.Length - 1; i > index; i--)
            {
                rightNums[i - leftNums.Length] = numArr[i];
            }            
            
            for(int i = 0; i < numArr.Length; i++)
            {
                if (i < rightNums.Length)
                {
                    numArr[i] = rightNums[i];
                }
                else
                {
                    numArr[i] = leftNums[i - rightNums.Length];
                }
            }

            return numArr;
        }

        static int ReturnMaxEvenOrOddIndex(int[] numArr,string evenOrOdd)
        {
            int maxIndex = -1;
            int maxNum = int.MinValue;
            if (evenOrOdd == "even")
            {
                for(int i = numArr.Length - 1; i >= 0; i--)
                {
                    if (numArr[i] % 2 == 0 && maxNum < numArr[i])
                    {
                        maxNum = numArr[i];
                        maxIndex = i;
                    }
                }
            }
            else
            {
                for (int i = numArr.Length - 1; i >= 0; i--)
                {
                    if (numArr[i] % 2 == 1 && maxNum < numArr[i])
                    {
                        maxNum = numArr[i];
                        maxIndex = i;
                    }
                }
            }
            return maxIndex;
        }

        static int ReturnMinEvenOrOddIndex(int[] numArr, string evenOrOdd)
        {
            int minIndex = -1;
            int minNum = int.MaxValue;
            if (evenOrOdd == "even")
            {
                for (int i = numArr.Length - 1; i >= 0; i--)
                {                   
                    if (numArr[i] % 2 == 0 && minNum > numArr[i])
                    {
                        minNum = numArr[i];
                        minIndex = i;
                    }
                }                
            }
            else
            {
                for (int i = numArr.Length - 1; i >= 0; i--)
                {
                    if (numArr[i] % 2 != 0 && minNum > numArr[i])
                    {
                        minNum = numArr[i];
                        minIndex = i;
                    }
                }                
            }

            return minIndex;
        }

        static string ReturnFirstElementsThatAreEvenOrOdd(int[] numArr,int count,string evenOrOdd)
        {           
            if (count > numArr.Length)
            {
                return "Invalid count";
            }

            int[] elements=new int[0];            
            int elementsCounter = 1;

            if (evenOrOdd == "even")
            {
                for (int i = 0; i < numArr.Length; i++)
                {
                    if (numArr[i] % 2 == 0 && elementsCounter <= count)
                    {
                        Array.Resize(ref elements, elementsCounter);
                        elements[elementsCounter-1] = numArr[i];
                        elementsCounter++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < numArr.Length; i++)
                {
                    if (numArr[i] % 2 != 0 && elementsCounter <= count)
                    {
                        Array.Resize(ref elements,elementsCounter);
                        elements[elementsCounter - 1] = numArr[i];
                        elementsCounter++;
                    }
                }
            }
            return string.Join(", ", elements);
        }

        static string ReturnLastElementsThatAreEvenOrOdd(int[] numArr, int count, string evenOrOdd)
        {            
            if (count > numArr.Length)
            {
                return "Invalid count";
            }

            int[] elements =new int[0];
            int elementsCounter = 1;

            if (evenOrOdd == "even")
            {
                for (int i = numArr.Length - 1; i >=0; i--)
                {
                    if (numArr[i] % 2 == 0 && elementsCounter <= count)
                    {
                        Array.Resize(ref elements, elementsCounter);
                        elements[elementsCounter - 1] = numArr[i];
                        elementsCounter++;
                    }
                }
            }
            else
            {
                for (int i = numArr.Length -1; i >= 0; i--)
                {
                    if (numArr[i] % 2 != 0 && elementsCounter <= count)
                    {
                        Array.Resize(ref elements, elementsCounter);
                        elements[elementsCounter - 1] = numArr[i];
                        elementsCounter++;
                    }
                }
            }
            Array.Reverse(elements);
            return string.Join(", ", elements);
        }
    }
}

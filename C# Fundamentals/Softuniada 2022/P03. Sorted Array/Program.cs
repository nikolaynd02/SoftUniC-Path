using System;
using System.Linq;

namespace P03._Sorted_Array
{
    class Program
    {
        //60/100 
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());

            int[] listOfElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for(int i = 0; i < elements; i++)
            {
                if (i == 0 && elements > 1)
                {
                    if (listOfElements[i] < listOfElements[i + 1])
                    {
                        int temp = listOfElements[i];
                        listOfElements[i] = listOfElements[i + 1];
                        listOfElements[i + 1] = temp;
                    }
                    continue;
                }

                if (i % 2 == 0 && i+1<elements)
                {
                    if (listOfElements[i] < listOfElements[i+1])
                    {
                        int temp = listOfElements[i];
                        listOfElements[i] = listOfElements[i + 1];
                        listOfElements[i + 1] = temp;
                    }                    
                }
            }

            Console.WriteLine(string.Join(" ", listOfElements));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split(" ").ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    MergeBetweenIndexes(inputList, startIndex, endIndex);
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    DivideIndexInPartitions(inputList, index, partitions);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", inputList));

        }

        static void MergeBetweenIndexes(List<string> inputList,int startIndex, int endIndex)
        {
            if (startIndex < 0 )
            {
                startIndex = 0;
            }

            if(endIndex >= inputList.Count )
            {
                endIndex = inputList.Count-1;
            }

            if (startIndex >= 0 && endIndex < inputList.Count && startIndex <= endIndex)
            {
                StringBuilder merged = new StringBuilder();
                for (int i=startIndex; i <= endIndex; i++)
                {
                    merged.Append(inputList[startIndex]);
                    inputList.RemoveAt(startIndex);                
                }
                inputList.Insert(startIndex, merged.ToString());
            }

        }

        static void DivideIndexInPartitions(List<string> inputList,int index,int partitions)
        {
            if (partitions > inputList[index].Length)
            {
                return;
            }

            int partitionsLenght = inputList[index].Length / partitions;
            int partitionsRemains = inputList[index].Length % partitions;
            int lastPartitionLenght = partitionsLenght + partitionsRemains;

            List<string> partitionsList = new List<string>();
            for(int i = 0; i < partitions; i++)
            {
                char[] currPartition;
                if (i == partitions - 1)
                {
                    currPartition = inputList[index]
                       .Skip(i * partitionsLenght)
                       .Take(lastPartitionLenght)
                       .ToArray();
                }
                else
                {
                    currPartition = inputList[index]
                        .Skip(i * partitionsLenght)
                        .Take(partitionsLenght)
                        .ToArray();
                }
                partitionsList.Add(new string(currPartition));
            }
            inputList.RemoveAt(index);
            inputList.InsertRange(index, partitionsList);

        }
    }
}

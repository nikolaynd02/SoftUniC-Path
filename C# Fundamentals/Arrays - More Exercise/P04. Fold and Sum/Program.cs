using System;
using System.Linq;

namespace P04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] upperRowBigin = new int[numArr.Length / 4];
            int[] upperRowEnd = new int[numArr.Length / 4];
            int[] lowerRow = new int[numArr.Length / 2];
            int[] upperRow = new int[numArr.Length / 2];
            int posUpperRowBegin = 0;
            int posUpperRowEnd = 0;
            int posLowerRow = 0;
            for(int i = 0; i < numArr.Length; i++)
            {
                if (i < numArr.Length / 4)
                {
                    upperRowBigin[posUpperRowBegin++]=numArr[i];
                }
                else if (i >= numArr.Length - numArr.Length / 4)
                {
                    upperRowEnd[posUpperRowEnd++] = numArr[i];
                }
                else
                {
                    lowerRow[posLowerRow++] = numArr[i];
                }
            }
            Array.Reverse(upperRowEnd);
            Array.Reverse(upperRowBigin);
            for(int i = 0; i < upperRow.Length; i++)
            {
                if (i < upperRowBigin.Length)
                {
                    upperRow[i] = upperRowBigin[i];
                }
                else
                {
                    upperRow[i] = upperRowEnd[i - upperRowEnd.Length];
                }
            }
            int[] sum = new int[numArr.Length / 2];
            for(int i = 0; i < lowerRow.Length; i++)
            {
                sum[i] = lowerRow[i] + upperRow[i];
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

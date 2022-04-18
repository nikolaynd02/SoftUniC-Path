using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Sum_of_GCP_and_LCM
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int NOD = 0;
            int NOK = 0;

            List<int> NODCandidates = new List<int>();

            for(int i = 1; i <= n; i++)
            {
                if (n % i == 0 && m % i == 0)
                {
                    NODCandidates.Add(i);
                }
            }
            NOD = NODCandidates[NODCandidates.Count - 1];

            List<int> nNOK = new List<int>();
            List<int> mNOK = new List<int>();
            int p = 1;
            while (true) // case of infinite loop
            {
                nNOK.Add(n * p);
                mNOK.Add(m * p);
                int NOKcandidate = FindNOK(nNOK, mNOK);
                if (NOKcandidate > 0) 
                {
                    NOK = NOKcandidate;
                    break;
                }
                p++;
                
            }

            Console.WriteLine(NOK + NOD);
            
        }

        static int FindNOK(List<int> n, List<int> m)
        {
            for(int i = 0; i < n.Count; i++)
            {
                if(m.Any(x => x == n[i]))
                {
                    return n[i];
                }
            }

            return -1;
        }
    }
}

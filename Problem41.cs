using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
namespace Euler
{
   
    class Program
    {
        public static bool isPrime(int num)
        {
            int upperBound = (int)Math.Floor(Math.Sqrt(num));
            for (int i = 2; i <= upperBound; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
       
        public static void Permutation(int DigitNum, int DigitCount, string NumRec, ref List<int> Permu, ref char[] nDigit, ref int[] SelectRec)
        {
            if (DigitCount == DigitNum + 1)
            {
                Permu.Add(Convert.ToInt32(NumRec));
            }
            else if (DigitCount <= DigitNum)
            {
                for (int i = 0; i <= DigitNum - 1; i++)
                {
                    if (SelectRec[i] == 0)
                    {
                        SelectRec[i] = 1;
                        Permutation(DigitNum, DigitCount + 1, NumRec + nDigit[i], ref Permu, ref nDigit, ref SelectRec);
                        SelectRec[i] = 0;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int n;
            char[] nDigit = {'1','2','3','4','5','6','7','8','9' };
            int[] SelectRec = new int[9];
            int MaxPanPrime = 2;
            for (n = 1; n <= 9; n++)
            {
                List<int> Permu = new List<int>();
                Permutation(n, 1, "", ref Permu, ref nDigit, ref SelectRec);
                foreach (int m in Permu)
                {
                    if (m > MaxPanPrime && isPrime(m))
                    {
                        MaxPanPrime = m;
                    }
                }
            }
                Console.Write("Max:{0}", MaxPanPrime);
            Console.ReadKey();
        }

    }
}

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
        public static void Permutation(int DigitCount, string NumRec, ref List<string> Permu, ref char[] nDigit, ref int[] SelectRec)
        {
            if (DigitCount == 11)
            {
                Permu.Add(NumRec);
            }
            else if (DigitCount <= 10)
            {
                for (int i = 0; i <= 9; i++)
                {
    
                    if (SelectRec[i] == 0)
                    {
                        if ((DigitCount != 1)||(DigitCount==1)&&(nDigit[i]!='0'))
                        {
                            SelectRec[i] = 1;
                            Permutation(DigitCount + 1, NumRec + nDigit[i], ref Permu, ref nDigit, ref SelectRec);
                            SelectRec[i] = 0;
                        }                        
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            char[] nDigit = {'0','1','2','3','4','5','6','7','8','9'};
            int[] Denom = { 2,3,5,7,11,13,17};
            int[] SelectRec = new int[10];
            bool isTarget;
            Int64 sum = 0;
            List<string> Permu = new List<string>();
            int PanInt = 0;
            Permutation(1, "", ref Permu, ref nDigit, ref SelectRec);
            foreach (string PanStr in Permu)
            {
                isTarget = true;
                for (int count = 1; count <= 7; count++)
                {
                    PanInt = Convert.ToInt32(PanStr.Substring(count, 3));
                    if (PanInt % Denom[count-1] != 0)
                    {
                        isTarget = false;
                        break;
                    }
                }
                if (isTarget)
                {
                    Console.WriteLine("{0}", Convert.ToInt64(PanStr));
                    sum += Convert.ToInt64(PanStr);
                }
            }
            Console.WriteLine("sum is:{0}", sum);
            Console.ReadKey();
        }

    }
}

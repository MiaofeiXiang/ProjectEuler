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
  
        public static void FindTarget(int Num, char[] SortedNumCh, string tempNum, ref int[] isChecked, int DigitNo)
        {
            if (DigitNo == 5)
            {
                int tempNumtoint = Convert.ToInt32(tempNum);
                int ThirdNum = 2 * tempNumtoint - Num;
                if (tempNumtoint > Num && isPrime(tempNumtoint) && isPrime(ThirdNum))
                {
                    string ThirdNumStr = ThirdNum.ToString();
                    char[] Arr = ThirdNumStr.ToArray();
                    Array.Sort(Arr);
                    if (new string(Arr) == new string(SortedNumCh))
                    {
                        Console.WriteLine("The sequence is:{0},{1},{2}", Num, tempNumtoint, ThirdNum);
                    }
                }               
            }
            else if (DigitNo <= 4)
            {
                for (int i = 0; i <= 3; i++)
                {
                    if (isChecked[i] == 0)
                    {
                        isChecked[i] = 1;
                        FindTarget(Num, SortedNumCh, tempNum + SortedNumCh[i], ref isChecked, DigitNo + 1);
                        isChecked[i] = 0;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<int> PrimeFourDig = new List<int>();
            
            int[] isChecked = new int[4];
           
            for (int i = 1000; i < 1e4 - 1; i++)
                if (isPrime(i))
                    PrimeFourDig.Add(i);
            foreach (int prime in PrimeFourDig)
            {
                string NumStr = prime.ToString();
                char[] NumCh = NumStr.ToArray();
                Array.Sort(NumCh);
                FindTarget(prime, NumCh, "", ref isChecked, 1);
            }
            Console.ReadKey();
        }

    }
}

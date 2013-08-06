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

        public static void CombPrime(int Num, char[] RepNumArr, List<int> RepLoc, ref int[] isChecked, int[] LocSelect, int RepLen, int DigNo, ref int PrimeNum, ref int targetNum)
        {
            int RepLocLen = RepLoc.Count;

            if (DigNo == RepLen + 1 && PrimeNum != 8)
            {
                string NumStr = Num.ToString();
                char[] NumArr = NumStr.ToArray();
                foreach (char Rep in RepNumArr)
                {
                    for (int Loc = 0; Loc < RepLen; Loc++)
                    {
                        NumArr[LocSelect[Loc]] = Rep;
                    }
                    if (isPrime(Convert.ToInt32(new string(NumArr))))
                        PrimeNum++;
                }
                if (PrimeNum == 8)
                {
                    targetNum = Num;
                    Console.Write("The smallest prime of eight prime number family is: {0} and the replaceable positions are:", Num);
                    for (int Loc = 0; Loc < RepLen; Loc++)
                    {
                        Console.Write(" {0}", LocSelect[Loc] + 1);
                    }
                }
                else
                {
                    PrimeNum = 1;
                }         
            }
            else if (DigNo <= RepLen)
            {
                for(int count = 0; count < RepLocLen; count++)
                {
                    if(isChecked[count]==0)
                    {
                        isChecked[count] = 1;
                        LocSelect[DigNo - 1] = RepLoc[count];
                        CombPrime(Num,RepNumArr,RepLoc, ref isChecked, LocSelect, RepLen, DigNo + 1, ref PrimeNum, ref targetNum);
                        isChecked[count] = 0;
                    }
                }
            }
            
        }
        static void Main(string[] args)
        {
            int PrimeFamilyCount = 0;
            int num = 2;
            int targetNum = 0;
            char[] RepNumArr0 = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] RepNumArr1 = { '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] RepNumArr2 = { '3', '4', '5', '6', '7', '8', '9' };
            bool ifzeroContain;
            bool ifoneContain;
            bool iftwoContain;
                                   
            while (targetNum==0)
            {
                string tempNumStr = num.ToString();
                ifzeroContain = tempNumStr.Contains('0');
                ifoneContain = tempNumStr.Contains('1');
                iftwoContain = tempNumStr.Contains('2');

                if ((ifzeroContain||ifoneContain||iftwoContain)&&isPrime(num))
                {
                    PrimeFamilyCount = 1;
                    if (ifzeroContain)
                    {
                        List<int> RepLoc = new List<int>();
                        int tempNumStrLen = tempNumStr.Length;
                        for (int i = 0; i < tempNumStrLen; i++)
                        {
                            if (tempNumStr[i] == '0')
                            {
                                RepLoc.Add(i);
                            }
                        }
                        int RepLocLen =  RepLoc.Count;
                        int[] isChecked = new int[RepLocLen];
                        int[] LocSelect = new int[RepLocLen];
                        for(int RepLen = 1; RepLen <= RepLocLen; RepLen++)
                        {
                            CombPrime(num, RepNumArr0, RepLoc, ref isChecked, LocSelect, RepLen, 1, ref PrimeFamilyCount, ref targetNum);
                        }                        
                    }
                   
                    if (ifoneContain)
                   {
                        List<int> RepLoc = new List<int>();
                        int tempNumStrLen = tempNumStr.Length;
                        for (int i = 0; i < tempNumStrLen; i++)
                        {
                            if (tempNumStr[i] == '1')
                            {
                                    RepLoc.Add(i);
                            }
                        }
                        int RepLocLen = RepLoc.Count;
                        int[] isChecked = new int[RepLocLen];
                        int[] LocSelect = new int[RepLocLen];
                        for (int RepLen = 1; RepLen <= RepLocLen; RepLen++)
                        {
                            CombPrime(num, RepNumArr1, RepLoc, ref isChecked, LocSelect, RepLen, 1, ref PrimeFamilyCount, ref targetNum);   
                        }                           
                   }
                    if (iftwoContain)
                    {
                        List<int> RepLoc = new List<int>();
                        int tempNumStrLen = tempNumStr.Length;
                        for (int i = 0; i < tempNumStrLen; i++)
                        {
                            if (tempNumStr[i] == '2')
                            {
                                RepLoc.Add(i);
                            }
                        }
                        int RepLocLen = RepLoc.Count;
                        int[] isChecked = new int[RepLocLen];
                        int[] LocSelect = new int[RepLocLen];
                        for (int RepLen = 1; RepLen <= RepLocLen; RepLen++)
                        {
                            CombPrime(num, RepNumArr2, RepLoc, ref isChecked, LocSelect, RepLen, 1, ref PrimeFamilyCount, ref targetNum);
                        }
                    }
                                                         
                }

                num++;
            }
            
            Console.ReadKey();
        }

    }
}

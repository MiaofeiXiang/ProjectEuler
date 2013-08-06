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
        static void Main(string[] args)
        {
            int Num = 11;
            int sum = 0;
            int TargetPrimeSum = 0;
            char highestDig;
            char lowestDig;
            string NumToStr;
            bool isTargetPrime;
            char[] HighAndLow = new char[]{'2','3','5','7'};
            while (TargetPrimeSum != 11)
            {
                if(isPrime(Num))
                {
                    NumToStr = Convert.ToString(Num);
                    int NumLen = NumToStr.Length;
                    highestDig = NumToStr[0];
                    lowestDig = NumToStr[NumLen-1];
                    if (HighAndLow.Contains(highestDig) && HighAndLow.Contains(lowestDig))
                    {
                        isTargetPrime = true;
                        string TempResult1 = NumToStr;
                        string TempResult2 = NumToStr;
                        for (int count = 0; count < NumLen - 1; count++)
                        {
                            TempResult1 = TempResult1.Substring(1,TempResult1.Length-1);
                            TempResult2 = TempResult2.Substring(0,TempResult2.Length-1);
                            if (!isPrime(Convert.ToInt32(TempResult1)) || !isPrime(Convert.ToInt32(TempResult2)))
                            {
                                isTargetPrime = false;
                                break;
                            }
                        }
                        if (isTargetPrime)
                        {
                            Console.WriteLine("{0}",Num);
                            sum += Num;
                            TargetPrimeSum++;
                        }
                    }
                }
                Num++;
            }
            Console.WriteLine("sum:{0}",sum);
            Console.ReadKey();

        }

    }
}

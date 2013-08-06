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
            List<string> PrimeNumRecord = new List<string>();
            int TargetSum = 0;
            bool isTargePrime;
            for (int i = 2; i < 1e6; i++)
            {
                if (isPrime(i))
                {
                    string tempStr = Convert.ToString(i);
                    if (!tempStr.Contains("0") && !tempStr.Contains("4")  && !tempStr.Contains("6") && !tempStr.Contains("8"))
                    {
                        if(i==2||i==5)
                            PrimeNumRecord.Add(tempStr);
                        else if (!tempStr.Contains("2") && !tempStr.Contains("5"))
                            PrimeNumRecord.Add(tempStr);
                    }
                }
            }
            foreach (string iter in PrimeNumRecord)
            {
                isTargePrime = true;
                int digitNum = iter.Length;
                string tempStr;
                string tempiter = iter;
                for (int count = 0; count < digitNum; count++)
                {
                    tempStr = tempiter.Substring(0, digitNum);
                    if (!PrimeNumRecord.Contains(tempStr))
                    {
                        isTargePrime = false;
                        break;
                    }
                    tempiter = tempiter.Substring(1, digitNum-1) + tempiter[0];
                }
                if (isTargePrime)
                {
                    Console.Write("{0} ", iter);
                    TargetSum++;
                }
                
            }
            Console.WriteLine("The total number of circular primes below one million is: {0}",TargetSum);
            Console.ReadKey();
        }

    }
}

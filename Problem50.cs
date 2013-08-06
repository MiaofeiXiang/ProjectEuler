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
            List<int> PrimeLst = new List<int>();
            int maxTermLen = 1;
            int termLen;
            int consecSum;
            int maxTermNum = 2;
            int lstLen = 0;
            int startpt;
            int OrgStartpt;
            for (int num = 2; num < 1e6; num++)
            {
                if (isPrime(num))
                {
                    lstLen = PrimeLst.Count;
                    startpt = lstLen - 1;
                    OrgStartpt = startpt; 
                    consecSum = 0;
                    termLen = maxTermLen + 1;

                    for (; startpt >= lstLen - termLen && startpt >= 0; startpt--)
                    {
                        consecSum += PrimeLst[startpt];
                        if (consecSum > num)
                        {
                            lstLen--;
                            termLen = maxTermLen + 1;
                            consecSum -= PrimeLst[OrgStartpt];
                            OrgStartpt--;
                        }
                        else if (startpt == lstLen - termLen && consecSum < num)
                        {
                            termLen++;
                        }
                        else if (startpt == lstLen - termLen && consecSum == num)
                        {                          
                            maxTermLen = termLen;
                            maxTermNum = num;
                        }
                    }
                        PrimeLst.Add(num);
                }
            }
            Console.WriteLine("The num {0} has the largest number of terms {1}", maxTermNum, maxTermLen);
            Console.ReadKey();
        }

    }
}

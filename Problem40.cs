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
       
        static void Main(string[] args)
        {
            int DigitNum = 0;
            int Count = 0;
            string CountStr;
            int TargetFindNo = 1;
            int Product = 1;
            while (TargetFindNo <= 1e6)
            {
                Count++;
                CountStr = Count.ToString();
                if (DigitNum < TargetFindNo && (DigitNum + CountStr.Length) >= TargetFindNo)
                {
                    Console.Write("{0} ",CountStr[TargetFindNo - DigitNum - 1]);
                    Product *= (CountStr[TargetFindNo - DigitNum - 1] - '0');
                    TargetFindNo *= 10;
                }
                DigitNum += CountStr.Length;
            }
            Console.Write("The product is:{0}",Product);
            Console.ReadKey();
        }

    }
}

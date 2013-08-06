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
        public static bool isTargetNum(string ConcatNum)
        {
            char[] ConcatChar = ConcatNum.ToCharArray();
            Array.Sort(ConcatChar);

            return new string(ConcatChar) == "123456789";
        }
       
        static void Main(string[] args)
        {
            int num1;
            int num2;
            int num3;
            int targetnum = 9;
            string numStr1;
            string numStr2;
            string numStr3;
            string result ="";
            bool isTarget;
            string bench = "918273645";
            for (num1 = 92; num1 <= 1e4 - 1; num1++)
            {                             
                
                numStr1 = num1.ToString();
                if(numStr1[0]=='9')
                {
                    num2 = num1*2;
                    num3 = num1*3;
                    numStr2 = num2.ToString();
                    numStr3 = num3.ToString();
                    isTarget = false;
                    if (numStr1.Length == 2 && numStr2.Length == 3 && numStr3.Length == 4)
                    {
                        result = numStr1 + numStr2 + numStr3;
                        isTarget = isTargetNum(result);
                    }
                    else if(numStr1.Length == 3 && numStr2.Length == 3 && numStr3.Length == 3)
                    {
                        result = numStr1 + numStr2 + numStr3;
                        isTarget = isTargetNum(result);
                    }
                    else if(numStr1.Length == 4 && numStr2.Length == 5)
                    {
                        result = numStr1 + numStr2;
                        isTarget = isTargetNum(result);
                    }
                    if (isTarget && string.Compare(result, bench) > 0)
                    {   
                        targetnum = num1;
                        bench = result;
                    }
                }
            }
            Console.WriteLine("The target num is: {0} and the nine num is: {1}.", targetnum, bench);
            Console.ReadKey();

        }

    }
}

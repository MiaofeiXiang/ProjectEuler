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
            int pValue;
            int a,b,c;
            int tempNum;
            int MaxNum = 0;
            int targetP = 0;
            for (pValue = 4; pValue <= 1000; pValue++)
            {
                tempNum = 0;
                for (c = 1; c < pValue / 2; c++)
                    for (a = 1; a < c; a++)
                    {
                        b = pValue - a - c;
                        if (b >= a)
                        {
                            if (a * a + b * b == c * c)
                            {
                                if (tempNum == 0)
                                    Console.Write("{0}", pValue);
                                Console.Write("({0},{1},{2}) ", a, b, c);
                                tempNum++;
                            }
                        }
                    }
                if (tempNum != 0)
                    Console.Write("\n");
                if (tempNum > MaxNum)
                {
                    MaxNum = tempNum;
                    targetP = pValue;
                }
            }
            Console.Write("Target p is:{0} and the max num is:{1}",targetP,MaxNum);
            Console.ReadKey();

        }

    }
}

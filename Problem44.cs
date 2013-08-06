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
            int MaxNum = 10000;
            int k, j;
            int nToD = 0;
            int SquaredNum1;
            int SquaredNum2;
            int ifSquared1;
            int ifSquared2;
            int tempResult1;
            int tempResult2;
            for (k = 1; k <= MaxNum-1 && nToD == 0; k++)
                for (j = k + 1; j <= MaxNum && nToD == 0; j++)
                {
                    SquaredNum1 = 36 * (k * k + j * j) - 12 * (k + j) + 1;
                    SquaredNum2 = 36 * (j * j - k * k) - 12 * (j - k) + 1;
                    ifSquared1 = (int)Math.Sqrt(SquaredNum1);
                    ifSquared2 = (int)Math.Sqrt(SquaredNum2);
                    tempResult1 = 1 - 6 * k - 6 * j + ifSquared1;
                    tempResult2 = 1 - 6 * j + 6 * k + ifSquared2;
                    if (ifSquared1 * ifSquared1 == SquaredNum1 && ifSquared2 * ifSquared2 == SquaredNum2)
                    {
                        if (tempResult1 % 6 == 0 && tempResult2 % 6 == 0)
                        {
                            nToD = j - k + tempResult2 / 6;
                            Console.WriteLine("The pair of (k,j) is:({0},{1})",k,j);
                        }
                    }
                }
            Console.WriteLine("The value of D is:{0}", nToD*(3*nToD-1)/2);
                    Console.ReadKey();
        }

    }
}

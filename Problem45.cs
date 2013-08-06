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
            Int64 n = 286;
            Int64 Tn;
            Int64 Squared1, Squared2;
            Int64 ifSquared1, ifSquared2;
            Int64 temp1, temp2;
            bool ifFind = false;
            while (!ifFind)
            {
                Tn = n * (n + 1) / 2;
                Squared1 = 1 + 24 * Tn;
                Squared2 = 1 + 8 * Tn;
                ifSquared1 = (Int64)Math.Sqrt(Squared1);
                ifSquared2 = (Int64)Math.Sqrt(Squared2);
                temp1 = 1 + ifSquared1;
                temp2 = 1 + ifSquared2;
                if (ifSquared1 * ifSquared1 == Squared1 && ifSquared2 * ifSquared2 == Squared2)
                {
                    if (temp1 % 6 == 0 && temp2 % 4 == 0)
                    {
                        Console.WriteLine("The next target Tn is:{0}", Tn);
                        ifFind = true;
                    }
                }
                n++;
            }
            Console.ReadKey();
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Numerics;

namespace LEETCODE
{

    class Program
    {
        static BigInteger commDivisor(BigInteger num, BigInteger denom)
        {
            BigInteger temp;
            while (denom != 0)
            {
                temp = num % denom;
                num = denom;
                denom = temp;
            }
            return num;
        }
        static BigInteger[] SquareRootPortion(int count, int num)
        {
            if (count == num)
                return new BigInteger[] { 2, 1 };
            else
            {
                BigInteger[] NumDenom = SquareRootPortion(count + 1, num);
                BigInteger numerator = NumDenom[1] + 2 * NumDenom[0];
                BigInteger denominator = NumDenom[0];
                BigInteger commDivisr = commDivisor(numerator, denominator);
                return new BigInteger[] { numerator / commDivisr, denominator / commDivisr };
            }
        }
        static void Main(string[] args)
        {
            BigInteger numerator;
            string numer = "";
            BigInteger denominator;
            string denom = "";
            BigInteger[] NumDenom;
            BigInteger commDivisr;
            int total = 0;
            for (int i = 1; i <= 1000; i++)
            {
                NumDenom = SquareRootPortion(1, i);
                numerator = NumDenom[1] + NumDenom[0];
                denominator = NumDenom[0];
                commDivisr = commDivisor(numerator, denominator);
                numerator /= commDivisr;
                denominator /= commDivisr;
                numer = numerator.ToString();
                denom = denominator.ToString();
                if (numer.Count() > denom.Count())
                    total++;
            }
            Console.WriteLine("The total is:{0}",total);
                Console.ReadLine();
        }
    }
}



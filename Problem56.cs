using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
namespace Euler
{
    
    class Program
    {

        static int digitalSum(BigInteger result)
        {
            string resultStr = result.ToString();
            char[] resultArr = resultStr.ToArray();
            int sum = 0;
            foreach (char i in resultArr)
                sum += (int)i - (int)'0';
            return sum;
        }
        static void Main(string[] args)
        {
            BigInteger num;
            BigInteger result;
            int max = 0;
            for (int a = 2; a < 100; a++)
            {
                num = new BigInteger(a);
                for (int b = 2; b < 100; b++)
                {
                    result = BigInteger.Pow(num, b);
                    int sum = digitalSum(result);
                    if (sum > max)
                        max = sum;
                    
                }
            }
            Console.Write("{0}", max);
            Console.ReadKey();
        }

    }
}

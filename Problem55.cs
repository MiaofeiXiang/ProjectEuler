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
        static bool isPalindrome(BigInteger num)
        {
            string numStr = num.ToString();
            char[] numArr = numStr.ToArray();
            Array.Reverse(numArr);
            return numStr == new string(numArr);
        }

        static void Main(string[] args)
        {
            int countLychrel = 0;
            bool isLychrel = true;

            for (int i = 1; i < 1e4; i++)
            {
                isLychrel = true;
                int times = 0;
                BigInteger num = new BigInteger(i);
                while (isLychrel && times <= 50)
                {
                    string numStr = num.ToString();
                    char[] numArr = numStr.ToArray();
                    Array.Reverse(numArr);
                    numStr = new string(numArr);
                    num += BigInteger.Parse(numStr);
                    if (isPalindrome(num))
                        isLychrel = false;
                    times++;
                }
                if (isLychrel)
                    countLychrel++;
            }
            Console.WriteLine("{0}", countLychrel);
            Console.ReadKey();
        }

    }
}

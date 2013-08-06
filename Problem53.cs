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
       
        public static bool isTargetNum(int n, int r)
        {
            int startPt = n - r + 1;
            int nTemp = n;
            int rTemp = r;
            int[] nArr = new int[160];
            int[] rArr = new int[160];
            int nDigitLen = 0;
            int rDigitLen = 0;
            int count = 0;
            while (nTemp != 0)
            {
                nArr[count] = nTemp % 10;
                nTemp = nTemp / 10;
                count++;
            }
            count = 0;
            while (rTemp != 0)
            {
                rArr[count] = rTemp % 10;
                rTemp = rTemp / 10;
                count++;
            }
            for (int i = startPt; i <= n-1; i++)
            {
                int AddNum = 0;
                int MultiNum = 0;
                for (int nArrCount = 0; nArrCount <= 159; nArrCount++)
                {
                    MultiNum = i * nArr[nArrCount] + AddNum;
                    if (MultiNum > 9)
                    {
                        nArr[nArrCount] = MultiNum % 10;
                        AddNum = MultiNum / 10;
                    }
                    else
                    {
                        nArr[nArrCount] = MultiNum;
                        AddNum = 0;
                    }
                }
            }

            for (int i = 1; i <= r-1; i++)
            {
                int AddNum = 0;
                int MultiNum = 0;
                for (int rArrCount = 0; rArrCount <= 159; rArrCount++)
                {
                    MultiNum = i * rArr[rArrCount] + AddNum;
                    if (MultiNum > 9)
                    {
                        rArr[rArrCount] = MultiNum % 10;
                        AddNum = MultiNum / 10;
                    }
                    else
                    {
                        rArr[rArrCount] = MultiNum;
                        AddNum = 0;
                    }
                }
            }
            count = 159;
            while (nArr[count] == 0)
            {
                count--;
            }
            nDigitLen = count + 1;
            count = 159;
            while (rArr[count] == 0)
            {
                count--;
            }
            rDigitLen = count + 1;
            if (nDigitLen > rDigitLen + 6)
                return true;
            else if (nDigitLen < rDigitLen + 6)
                return false;
            else
            {
                char[] nArrCh = new char[nDigitLen];
                char[] rArrCh = new char[nDigitLen];
                for (int i = 0; i <= nDigitLen - 1; i++)
                    nArrCh[i] = (char)(nArr[i] + '0' - 0);
                for (int i = 0; i <= nDigitLen - 1; i++)
                {
                    if (i >= 6)
                        rArrCh[i] = (char)(rArr[i-6] + '0' - 0);                       
                    else
                        rArrCh[i] = '0';
                }
                Array.Reverse(nArrCh);
                Array.Reverse(rArrCh);
                string nArrStr = new string(nArrCh);
                string rArrStr = new string(rArrCh);
                if (nArrStr.CompareTo(rArrStr) > 0)
                    return true;
                else
                    return false;
            }

        }
        static void Main(string[] args)
        {
            int n = 1;
            int r = 1;
            int sum = 0;
            for (n = 1; n <= 100; n++)
                for (r = 1; r <= n; r++)
                {
                    if (isTargetNum(n, r))
                        sum++;
                }
            Console.WriteLine("The sum of result bigger than a million is: {0}", sum);
                Console.ReadKey();
        }

    }
}

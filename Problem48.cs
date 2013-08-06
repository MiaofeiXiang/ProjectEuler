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

        public static void FindLastTenDig(int num, ref int[] LastTenDigit)
        {
            int[] NumLastTenDigit = new int[10];
            int ProdCount = 0;
            string numStr = num.ToString();
            int numLen = numStr.Length;
            int AddNum = 0;
            int CurNum = 0;
            int count = 9 - numLen + 1;
            foreach (char numch in numStr)
            {
                NumLastTenDigit[count] = numch - '0';
                count++;
            }
            for(ProdCount=1;ProdCount<=num-1;ProdCount++)
            {
                AddNum = 0;
                for (count = 9; count >= 0; count--)
                {
                    int tempNum = NumLastTenDigit[count] * num + AddNum;
                    if (tempNum > 9)
                    {
                        CurNum = tempNum % 10;
                        AddNum = tempNum / 10;
                    }
                    else
                    {
                        CurNum = tempNum;
                        AddNum = 0;
                    }
                    NumLastTenDigit[count] = CurNum;
                }
            }
            AddNum = 0;
            for (count = 9; count >= 0; count--)
            {
                int tempNum = NumLastTenDigit[count] + LastTenDigit[count] + AddNum;
                if (tempNum > 9)
                {
                    CurNum = tempNum % 10;
                    AddNum = tempNum / 10;
                }
                else
                {
                    CurNum = tempNum;
                    AddNum = 0;
                }
                LastTenDigit[count] = CurNum;
            }
        }
        static void Main(string[] args)
        {
            int[] LastTenDigit = new int[10];
            int num = 1;
            for (; num <= 1000; num++)
            {
                FindLastTenDig(num, ref LastTenDigit);
            }
            foreach (int i in LastTenDigit)
            {
                Console.Write("{0}", i);
            }
                Console.ReadKey();
        }

    }
}

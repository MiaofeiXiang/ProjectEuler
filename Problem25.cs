using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler
{
    class Program
    {
        public static int count = 2;
        public static int FiboThird(int[] fiboFirst, int[] fiboSecond)
        {
            int i;
            int tempNum;
            int AddNum = 0;
            count++;
            for (i = 0; i < 1000; i++)
            {
                tempNum = fiboFirst[i] + fiboSecond[i] + AddNum;
                if (tempNum > 9)
                {
                    AddNum = tempNum / 10;
                    fiboFirst[i] = tempNum % 10;                    
                }
                else
                {
                    fiboFirst[i] = tempNum;
                    AddNum = 0;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int[] fiboFirst = new int[1000];
            int[] fiboSecond = new int[1000];
            fiboFirst[0] = 1;
            fiboSecond[0] = 1;
            int countflag = 0;
            while (fiboFirst[999] == 0 && fiboSecond[999] == 0)
            {
                countflag = FiboThird(fiboFirst, fiboSecond);
                if (fiboFirst[999] == 0 && fiboSecond[999] == 0) countflag = FiboThird(fiboSecond, fiboFirst);
            }                      
            Console.Write("{0}", countflag);            
            Console.ReadKey();
        }
     }
}

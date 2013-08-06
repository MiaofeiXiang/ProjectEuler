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
        public static int RepeatDigitCount(int num)
        {
            int BufferNum = 2000;
            int[] NumToArray = new int[BufferNum];
            int startflag = 0;
            int count = 0;
            int numerator = 1;
            int denominator = num;
            double judgeNum = numerator / (double)denominator;
            int cycle = 0;
            bool Incycle;
            for (int i = 0; i < BufferNum; i++)             //store 2000 digits after the decimal point of number 1/num
            {
                NumToArray[i] = (int)(judgeNum * 10);
                numerator = numerator * 10 - denominator * NumToArray[i];   // everytime discard the digit already extracted
                judgeNum = numerator / (double)denominator;
            }

            for (int i = BufferNum - 1; i >= BufferNum - 100; i--)        //determine if 1/num has no cycle
            {
                if (NumToArray[i] == 0)
                    count++;
            }

            if (count == 100)
                return cycle;

            for (int i = 0; i < 60; i++)                            //find the cycle start point, stored in startflag
                for (int j = i + 1; j < BufferNum/2; j++)
                {
                    Incycle = false;                   
                    if (NumToArray[i] == NumToArray[j])
                    {
                        Incycle = true;
                        break;
                    }
                    if (j == (BufferNum / 2 - 1) && !Incycle)
                        startflag = i + 1;
                }
            Incycle = true;
            for (int cycleNum = BufferNum/2; cycleNum >= 1; cycleNum--)     //determine the smallest cycle number
            {
                for (int i = startflag; i <= BufferNum - 1 - cycleNum; i++)
                {
                    if (NumToArray[i] != NumToArray[i + cycleNum])
                    {
                        Incycle = false;
                        break;
                    }
                }
                if (Incycle)
                    cycle = cycleNum;
                else
                    Incycle = true;
            }
                return cycle;
           
            
        }
        static void Main(string[] args)
        {           
            int largestcycle = 0;
            int num = 0;
            for (int i = 2; i < 1000; i++)
            {
                int temp = RepeatDigitCount(i);
                if (temp > largestcycle)
                {
                    largestcycle = temp;
                    num = i;
                }
            }

            Console.Write("{0} has the largest {1} cycle", num,largestcycle);
            
            Console.ReadKey();
        }

     }
}

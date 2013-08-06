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
        public static int invokecount = 0;
        public static void NumPermut(int[] NumRecord, int[] print, int count)
        {
            if (count == 10)
            {
                invokecount++;
                if(invokecount == 1e6)
                {
                    foreach (int m in print)
                        Console.Write("{0}", m);
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (NumRecord[i] == 0)
                    {
                        NumRecord[i] = 1;
                        print[count] = i;
                        NumPermut(NumRecord, print,count + 1);
                        NumRecord[i] = 0;
                    }

                }

            }

        }
        static void Main(string[] args)
        {
            int[] NumRecord = new int[10];
            int[] print = new int[10];
            NumPermut(NumRecord, print,0);
            Console.ReadKey();
        }
     }
}

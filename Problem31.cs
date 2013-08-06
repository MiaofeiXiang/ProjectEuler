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
        static int[] coin = { 1, 2, 5, 10, 20, 50, 100, 200 };
        static int RecordNum = 0; 
        static void GenerateTwoPounds(int coinID, int sum, ref int[] coinNumRecord)
        {
            if (sum == 200) { RecordNum++; print(ref coinNumRecord); }
            else if (sum < 200 && coinID < 8)
            {
                int maxCoinNum = 200 / coin[coinID];
                for (int i = 0; i <= maxCoinNum; i++)
                {
                    coinNumRecord[coinID] = i;
                    GenerateTwoPounds(coinID + 1, sum + coin[coinID] * i, ref coinNumRecord);
                    coinNumRecord[coinID] = 0;
                }
            }
        }
        static void print(ref int[] coinNumRecord)
        {
            foreach(int m in coinNumRecord)
                Console.Write("\t{0}",m);
            Console.Write("\n");
        }
        
        static void Main(string[] args)
        {
            int[] coinNumRecord = new int[8];
            Console.WriteLine("Permutatin\t1p\t2p\t5p\t10p\t20p\t50p\t100p\t200p");
            GenerateTwoPounds(0,0,ref coinNumRecord);
            Console.Write("The total permutation num is {0}", RecordNum);
            Console.ReadKey();
        }

     }
}

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
            bool isFind = false;
            int num = 0;
            int numMulti;
            int multip;
            while (!isFind)
            {
                num++;
                isFind = true;
                string numStr = num.ToString();
                char[] numCh = numStr.ToArray();
                Array.Sort(numCh);
                numStr = new string(numCh);
                for (multip = 2; multip <= 6; multip++)
                {
                    numMulti = num * multip;
                    string numMultiStr = numMulti.ToString();
                    char[] numMultiCh = numMultiStr.ToArray();
                    Array.Sort(numMultiCh);
                    numMultiStr = new string(numMultiCh);
                    if (numMultiStr != numStr)
                    {
                        isFind = false;
                        break;
                    }
                }
            }
            Console.WriteLine("The first positive target integer is:{0}",num);
            Console.ReadKey();
        }

    }
}

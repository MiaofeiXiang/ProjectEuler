using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
//8-digit number is the upper bound
namespace Euler
{
    
    class Program
    {
        public static int CalcRecursively(int number)
        {
            if (number > 1)
                return number * CalcRecursively(number - 1);
            if (number <= 1)
                return 1;
            return 0;
        }
       
        static void Main(string[] args)
        {
            int upperBound = (int)Math.Pow(10,7) - 1;
            int[] FactorialRecord = new int[10];
            for (int i = 0; i <= 9; i++)
                FactorialRecord[i] = CalcRecursively(i);
            string varString;
            int FacSum = 0;
            for (int i = 20; i <= upperBound; i++)
            {
                varString = Convert.ToString(i);
                foreach (char Ch in varString)
                {
                    FacSum += FactorialRecord[Ch - '0'];
                }
                if (FacSum == i)
                    Console.WriteLine("{0}",i);
                FacSum = 0;
            }
            Console.ReadKey();
        }

    }
}

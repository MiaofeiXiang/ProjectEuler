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
        static bool isEqualDigitSum(int Num)
        {
            int Digit = 6;
            int DigitSum = 0;
            int tempNum = Num;
            while (tempNum / Power(10,Digit-1) == 0)
            {
                Digit--;
            }
            for (int n = 1; n <= Digit; n++)
            {
                DigitSum += Power(tempNum % 10, 5);
                tempNum = tempNum / 10;
            }
            return DigitSum == Num;
        }
        static int Power(int baseNum, int power)
        {
            int sum = 1;
            if (power == 0) return sum;
            for (int i = 1; i <= power; i++)
            {
                sum *= baseNum;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int Num = 2;
            List<int> Record = new List<int>();
            int Sum = 0;
            for (; Num < 1e6; Num++)
            {
                if (isEqualDigitSum(Num))
                    Record.Add(Num);
            }

            foreach (int m in Record)
                Sum += m;
            Console.WriteLine("{0}",Sum);
            Console.ReadKey();
        }

     }
}

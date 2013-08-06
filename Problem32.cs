using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
//only consider the situation that a_n and b_n are (1,4),(2,3) respectively
namespace Euler
{
    class Program
    {
        static int[] Num = new int[10];
        static int[] SelectedNumRecord = new int[6];
        struct AB
        {
            internal int a;
            internal int b;
            internal int a1;
            internal int b1;
            internal int[] abDigit;
        }
        static void GenerateAB(int SelectedNum, ref List<AB> CollectAB)
        {
            if (SelectedNum == 6)
            {
                AB ABValue;
                ABValue.a1 = SelectedNumRecord[1];
                ABValue.b1 = SelectedNumRecord[2] * 1000 + SelectedNumRecord[3] * 100 + SelectedNumRecord[4] * 10 + SelectedNumRecord[5];
                ABValue.a = SelectedNumRecord[1] * 10 + SelectedNumRecord[2];                
                ABValue.b = SelectedNumRecord[3] * 100 + SelectedNumRecord[4] * 10 + SelectedNumRecord[5];
                ABValue.abDigit = new int[5];
                ABValue.abDigit[0] = SelectedNumRecord[1];
                ABValue.abDigit[1] = SelectedNumRecord[2];
                ABValue.abDigit[2] = SelectedNumRecord[3];
                ABValue.abDigit[3] = SelectedNumRecord[4];
                ABValue.abDigit[4] = SelectedNumRecord[5];
                CollectAB.Add(ABValue);
                //Console.WriteLine("a:{0}\tb:{1}",ABValue.a,ABValue.b);
            }
            else if (SelectedNum < 6)
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (Num[i] != 1)
                        {
                            Num[i] = 1;
                            SelectedNumRecord[SelectedNum] = i;
                            GenerateAB(SelectedNum + 1, ref CollectAB);
                            Num[i] = 0;
                        }                      
                    }

                }

        }
        static void FindPandigital(ref List<AB> CollectAB,ref SortedSet<int> Pandigital)
        {
            foreach (AB Iterator in CollectAB)
            {
                int Product = Iterator.a * Iterator.b;
                int Product1 = Iterator.a1 * Iterator.b1;
                foreach(int i in Iterator.abDigit)
                    Num[i] = 1;
                if (isPandigital(Product))
                {
                    Pandigital.Add(Product);
                    Console.WriteLine("a:{0}\tb:{1}\tc:{2}", Iterator.a, Iterator.b, Product);
                }
                for(int i = 0; i <= 9; i++)
                    Num[i] = 0;
                foreach (int i in Iterator.abDigit)
                    Num[i] = 1;
                if (isPandigital(Product1))
                {
                    Pandigital.Add(Product1);
                    Console.WriteLine("a:{0}\tb:{1}\tc:{2}", Iterator.a1, Iterator.b1, Product1);
                }
                for (int i = 0; i <= 9; i++)
                    Num[i] = 0;
            }

        }
        static bool isPandigital(int Product)
        {
            int cDigitNum = 6;
            int cDigit;
            int tempNum = Product;
            while (Product / Power(10, cDigitNum - 1) == 0)
            {
                cDigitNum--;
            }
            if (cDigitNum == 4)
            {
                for (int n = 1; n <= cDigitNum; n++)
                {
                    cDigit = tempNum % 10;
                    if (cDigit == 0 || Num[cDigit] == 1)
                        return false;
                    Num[cDigit] = 1;
                    tempNum = tempNum / 10;
                }
                return true;
            }
            else
                return false;
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
            SortedSet<int> Pandigital = new SortedSet<int>();
            List<AB> CollectAB = new List<AB>();
            GenerateAB(1,ref CollectAB);

            FindPandigital(ref CollectAB, ref Pandigital);
            Console.WriteLine("The sum of Pandigital product is: {0}",Pandigital.Sum());
            Console.ReadKey();
        }

    }
}

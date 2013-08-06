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
        struct Fraction
        {
            internal int numer;
            internal int denom;
        }
        
        static void Main(string[] args)
        {
            List<Fraction> NumRecord = new List<Fraction>();
            int product_denom = 1;
            int product_numer = 1;
            for (int i = 10; i < 100; i++)
            {
                for (int j = 10; j < i; j++)
                {
                    int i_1 = i / 10;
                    int i_2 = i % 10;
                    int j_1 = j / 10;
                    int j_2 = j % 10;
                    Fraction temp = new Fraction();
                    if (i_1 == j_1 && i_1 * j_1 != 0 && i_2 != 0)
                    {
                        if (i_2 * j == j_2 * i)
                        {
                            temp.numer = j;
                            temp.denom = i;
                            NumRecord.Add(temp);
                        }
                    }

                    if (i_1 == j_2 && i_1 * j_2 != 0 && i_2 != 0)
                    {
                        if (i_2 * j == j_1 * i)
                        {
                            temp.numer = j;
                            temp.denom = i;
                            NumRecord.Add(temp);
                        }
                    }

                    if (i_2 == j_1 && i_2 * j_1 != 0)
                    {
                        if (i_1 * j == j_2 * i)
                        {
                            temp.numer = j;
                            temp.denom = i;
                            NumRecord.Add(temp);
                        }
                    }

                    if (i_2 == j_2 && i_2 * j_2 != 0)
                    {
                        if (i_1 * j == j_1 * i)
                        {
                            temp.numer = j;
                            temp.denom = i;
                            NumRecord.Add(temp);
                        }
                    }

                }
            }

            foreach (Fraction item in NumRecord)
            {
                Console.Write("{0}\t{1}\n", item.numer, item.denom);
                product_numer *= item.numer;
                product_denom *= item.denom;
            }
            int a = product_numer;
            int b = product_denom;
            int tempNum;
            while (b!=0)
            {
                tempNum = a % b;
                a = b;
                b = tempNum;
            }
            Console.WriteLine("The denominator is {0}.",product_denom/a);
            Console.ReadKey();
        }

    }
}

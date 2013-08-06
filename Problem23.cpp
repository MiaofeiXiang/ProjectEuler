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
        public static bool IsAbundant(int num)
        {
            int upperbound =(int)Math.Floor(Math.Sqrt(num));
            int sum = 0;
            for (int i = 2; i <= upperbound; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                    if (num / i != i)
                        sum += num / i;
                }
            }
            sum += 1;
           if (sum > num)
                return true;
            else 
                return false;
        }
        static void Main(string[] args)
        {
            int[] NumTypeRecord = new int[28125];
            int[] PlusRecord = new int[28125];
            int sum = 0;
            for (int i = 1; i <= 28123; i++)
            {
                if (NumTypeRecord[i] != -1 && IsAbundant(i))
                {
                    NumTypeRecord[i] = -1;
                    for (int m = 1; m <= i; m++)
                    {
                        if (NumTypeRecord[m] == -1)
                        {
                            if(m+i<=28124)
                            PlusRecord[m + i] = -2;
                        }
                    }
                }

            }

            for (int i = 1; i <= 28123; i++)
            {
                if (PlusRecord[i] != -2)
                    sum += i; 
            }
            Console.WriteLine("The sum is {0}", sum);
            Console.ReadKey();
        }
     }
}

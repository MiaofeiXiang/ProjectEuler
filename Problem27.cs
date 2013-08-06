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
        public static bool isPrime(int num)
        {
            int upperBound = (int)Math.Floor(Math.Sqrt(num));
            if (num >= 2)
            {
                for (int i = 2; i <= upperBound; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
            else return false;
            
        }

        static void Main(string[] args)
        {
            int a, b, n;
            long ProductAB = 0;
            int PrimeSum = 0;
           
           for (b = -999; b < 1000; b++)
            {
                if (!isPrime(b))
                    continue;               
                for (a = -999; a < 1000; a++)
                {
                    n = 1;
                    while (isPrime(n * n + a * n + b))
                    {
                        n++;
                    }
                    if (n > PrimeSum)
                    {
                        PrimeSum = n;
                        ProductAB = a * b;
                    }
                }
            }
            Console.WriteLine("{0}", ProductAB);
   
            Console.ReadKey();
        }

     }
}

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
        public static bool isPrime(int num)
        {
            int upperBound = (int)Math.Floor(Math.Sqrt(num));
            for (int i = 2; i <= upperBound; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        public static bool isOddComposite(int num)
        {
            if (num % 2 != 0 && (!isPrime(num)))
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            int num = 1;
            int temp;
            int ifSqr;
            bool isFind = false;
            List<int> PrimeList = new List<int>();
          
            while(!isFind)
            {
                num++;
                if(isPrime(num))
                    PrimeList.Add(num);
                if (isOddComposite(num))
                {
                    isFind = true;
                    foreach(int prime in PrimeList)
                    {
                        temp = num - prime;
                        ifSqr = (int)Math.Sqrt(temp / 2);
                        if (temp % 2 == 0 && ifSqr * ifSqr == temp / 2)
                        {
                            isFind = false;
                            break;
                        }                        
                    }
                }     
            }
            Console.WriteLine("{0}",num);
                Console.ReadKey();
        }

    }
}

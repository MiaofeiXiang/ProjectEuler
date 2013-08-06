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
        
        static void Main(string[] args)
        {
            int UpperRight = 1;
            int sum = 1;

            for (int i = 2; i <= 501; i++)
            {
                UpperRight = UpperRight + 8 * (i - 1);
                sum += 4 * UpperRight - 12 * (i - 1);                
            }
            Console.WriteLine("{0}",sum);
            Console.ReadKey();
        }

     }
}

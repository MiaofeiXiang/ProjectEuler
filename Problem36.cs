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
        public static string DecimalToBinary(int DecNum)
        {
            int CurrDigit = DecNum;
            string BinaryStr = "";
            while (CurrDigit >=1)
            {
                BinaryStr += Convert.ToString(CurrDigit % 2);
                CurrDigit = CurrDigit / 2;               
            }

            char[] arr = BinaryStr.ToCharArray();
            Array.Reverse(arr);
            BinaryStr = new string(arr);
            return BinaryStr;
        }
        public static bool isPalingdrom(string num)
        {
            char[] arr = num.ToCharArray();
	        Array.Reverse(arr);
            string PalingNum = new string(arr);
            return num == PalingNum;
        }
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1; i < 1e6; i++)
            {
                string NumToStr = Convert.ToString(i);
                if (isPalingdrom(NumToStr))
                {
                    string NumToBinaryStr = DecimalToBinary(i);
                    if (isPalingdrom(NumToBinaryStr))
                    {
                        sum += i;
                    }
                }
            }

            Console.WriteLine("{0}", sum);
            Console.ReadKey();
        }

    }
}

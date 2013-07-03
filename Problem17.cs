/*Number letter counts
Problem 17

If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 1; i <= 1000; i++)
            {
                count += Translate(i);
            }
            Console.WriteLine("The total character number is: {0}", count);
            Console.ReadKey();
        }

        static int Translate(int num)
        {
            int digit = num;
            int power;
            int count = 0;
            List<string> TransChar = new List<string>();
            for (power = 1; power <= 4; power++)
            {
                digit = digit % 10;
                if (power == 1)
                {
                    switch (digit)
                    {
                        case 0: if (num / 10 % 10 == 1) TransChar.Add("ten"); break;
                        case 1: if (num / 10 % 10 != 1) TransChar.Add("one"); else TransChar.Add("eleven"); break;
                        case 2: if (num / 10 % 10 != 1) TransChar.Add("two"); else TransChar.Add("twelve"); break;
                        case 3: if (num / 10 % 10 != 1) TransChar.Add("three"); else TransChar.Add("thirteen"); break;
                        case 4: if (num / 10 % 10 != 1) TransChar.Add("four"); else TransChar.Add("fourteen"); break;
                        case 5: if (num / 10 % 10 != 1) TransChar.Add("five"); else TransChar.Add("fifteen"); break;
                        case 6: if (num / 10 % 10 != 1) TransChar.Add("six"); else TransChar.Add("sixteen"); break;
                        case 7: if (num / 10 % 10 != 1) TransChar.Add("seven"); else TransChar.Add("seventeen"); break;
                        case 8: if (num / 10 % 10 != 1) TransChar.Add("eight"); else TransChar.Add("eighteen"); break;
                        case 9: if (num / 10 % 10 != 1) TransChar.Add("nine"); else TransChar.Add("nineteen"); break;
                        default: break;
                    }
                    if (num / 100 % 10 != 0 && digit != 0 && num / 10 % 10 == 0) TransChar.Add("and");
                }
                if (power == 2)
                {
                    switch (digit)
                    {
                        case 2: TransChar.Add("twenty"); break;
                        case 3: TransChar.Add("thirty"); break;
                        case 4: TransChar.Add("forty"); break;
                        case 5: TransChar.Add("fifty"); break;
                        case 6: TransChar.Add("sixty"); break;
                        case 7: TransChar.Add("seventy"); break;
                        case 8: TransChar.Add("eighty"); break;
                        case 9: TransChar.Add("ninety"); break;
                        default: break;
                    }
                    if (num / 100 % 10 != 0 && digit != 0) TransChar.Add("and");
                }
                if (power == 3)
                {
                    switch (digit)
                    {
                        case 1: TransChar.Add("onehundred"); break;
                        case 2: TransChar.Add("twohundred"); break;
                        case 3: TransChar.Add("threehundred"); break;
                        case 4: TransChar.Add("fourhundred"); break;
                        case 5: TransChar.Add("fivehundred"); break;
                        case 6: TransChar.Add("sixhundred"); break;
                        case 7: TransChar.Add("sevenhundred"); break;
                        case 8: TransChar.Add("eighthundred"); break;
                        case 9: TransChar.Add("ninehundred"); break;
                        default: break;
                    }
                }
                if (power == 4)
                {
                    switch (digit)
                    {
                        case 1: TransChar.Add("onethousand"); break;
                        default: break;
                    }
                }
                if (power == 1)
                    digit = num / 10;

                if (power == 2)
                    digit = num / 100;

                if (power == 3)
                    digit = num / 1000;

                if (power == 4)
                    digit = num / 10000;
            }
            TransChar.Reverse();
            foreach (string character in TransChar)
            {
                Console.Write(character);
                count += character.Length;
            }
            Console.Write("\n");
            return count;
        }
    }
}
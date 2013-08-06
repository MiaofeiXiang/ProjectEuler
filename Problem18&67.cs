using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo MyFile = new FileInfo("Diagonal.txt");
            StreamReader sr = MyFile.OpenText();
            int column = 100;
            int row = 100;
            int[,] NumArray = new int[row , column];
            int i = 0;
            int j = 0;
            int Digit;
            int rowcount = 1;
            int internalcount = 0;
            int maximumpath = 0;
    
            for(i = 0; i<=row-1; i++)
                for(j = 0; j<=column-1; j++)
                    NumArray[i,j] = 0;
            while (!sr.EndOfStream)
            {
                Digit = sr.Read();
                if (Digit >= '0' && Digit <= '9')
                {
                    internalcount++;
                    if (internalcount == 1)
                    {
                        i = rowcount - 1;
                        j = 0;
                    }
                   
                    Digit = Digit - '0';
                    if (Digit != 0)
                        NumArray[i,j] = Digit * 10;
                    Digit = sr.Read() - '0';
                    NumArray[i, j] += Digit;
                    j++;

                    if (internalcount == rowcount)
                    {
                        rowcount++;
                        internalcount = 0;
                    }
                    
                }
            }

           
            for (i = 1; i <= row - 1; i++)
                for (j = 0; j <= row - 1; j++)
                {
                    if (j == 0)
                        NumArray[i, j] += NumArray[i - 1, j];
                    else if (j == row - 1)
                        NumArray[i, j] += NumArray[i - 1, j - 1];
                    else
                        NumArray[i, j] += Math.Max(NumArray[i - 1, j - 1], NumArray[i - 1, j]);
                }
            maximumpath = NumArray[row - 1, 0];
            for (j = 1; j <= row - 1; j++)
                if(NumArray[row - 1, j] > maximumpath)
                    maximumpath = NumArray[row - 1, j];
            Console.WriteLine("The maximum path value is {0}.", maximumpath);           
            Console.ReadKey();
        }

    }
}
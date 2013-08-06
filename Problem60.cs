using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace LEETCODE
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
        static void Main(string[] args)
        {
            //HashSet<int> myHash = new HashSet<int>();
            List<List<int>> myList = new List<List<int>>();
            bool isFind = false;
            int i = 3;
            while (!isFind)
            {
                if (isPrime(i))
                {
                    //myHash.Add(i);
                    int Listlen = myList.Count();
                    bool isInserted = false;
                    for (int j = 0; j < Listlen; j++)
                    {
                        bool isInsert = true;
                       
                        int kLen = myList[j].Count();
                        List<int> Temp = myList[j];
                        string iNum;
                        string ListNum;
                        string strPre;
                        string strAfter;
                        for (int k = 0; k < kLen; k++)
                        {
                            iNum = i.ToString();
                            ListNum = Temp[k].ToString();
                            strPre = iNum + ListNum;
                            strAfter = ListNum + iNum;
                            if (!isPrime(int.Parse(strPre)) || !isPrime(int.Parse(strAfter)))
                            {
                                isInsert = false;
                                break;
                            }
                        }
                        if (isInsert)
                        {
                            myList[j].Add(i);
                            isInserted = true;
                            if (kLen + 1 == 4)
                            {
                                isFind = true;
                                foreach (int num in myList[j])
                                    Console.Write("{0} ", num);
                                break;
                            }
                        }
                       
                    }

                     if(!isInserted)
                    {
                        List<int> more = new List<int>();
                        more.Add(i);
                        myList.Add(more);
                    }
                        
                }
                i++;
            }

            Console.ReadLine();           
        }        
    }
}



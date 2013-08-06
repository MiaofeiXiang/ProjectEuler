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
        
        static void Main(string[] args)
        {
            List<int> WordsNumList = new List<int>();
            List<int> TrianNum = new List<int>();
            int TrianNumSum = 0;
            try
            {
                FileInfo MyFile = new FileInfo("words.txt");
                StreamReader sr = MyFile.OpenText();
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    string Oper = "";
                    string[] tempStrArray = tempStr.Split(new char[1] { ',' });
                    foreach (string i in tempStrArray)
                    {
                        Oper = i.Substring(1, i.Length - 2);
                        int StrNum = 0;
                        foreach (char iCh in Oper)
                            StrNum += iCh - 'A' + 1;
                        WordsNumList.Add(StrNum);
                    }
                }
                int LargestWordsNum = WordsNumList.Max();
                int TrianNumGen = 0;
                int count = 0;
                while (TrianNumGen <= LargestWordsNum)
                {
                    count++;
                    TrianNumGen += count;
                    TrianNum.Add(TrianNumGen);                    
                }
                foreach (int Potential in WordsNumList)
                {
                    if (TrianNum.Contains(Potential))
                        TrianNumSum++;
                }
                Console.WriteLine("The sum of Triangular Number is:{0}",TrianNumSum);
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("throw exception: {0}", e.GetType());
                Console.WriteLine("{0}", e.Message);
                Console.ReadKey();
            }
        }

    }
}

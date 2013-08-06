using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler
{
    class Program
    {
        static int NameValueNum(string name)
        {
            int namevaluecount = 0;
            char[] namechar = name.ToCharArray();
            foreach (char n in namechar)
                namevaluecount += (int)n - (int)'A' + 1;
            return namevaluecount;
        }
        static void Main(string[] args)
        {
            List<string> NamesList = new List<string>();
            try
            {
                FileInfo MyFile = new FileInfo("names.txt");
                StreamReader sr = MyFile.OpenText();
                int position = 1;
                int NameValueSum = 0;
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    string[] tempStrArray = tempStr.Split(new char[1] { ',' });
                    foreach(string i in tempStrArray)
                        NamesList.Add(i.Substring(1,i.Length-2));
                }
                NamesList.Sort(string.Compare);
                foreach (string i in NamesList)
                {
                    NameValueSum += NameValueNum(i)*position;
                    position++;
                }

                Console.WriteLine("The total name value is: {0}", NameValueSum);
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

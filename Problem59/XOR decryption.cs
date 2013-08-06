using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
namespace Euler
{
    
    class Program
    {

        static void Main(string[] args)
        {
            List<char> ciphertext = new List<char>();
            int cipherLen;
            int cipherIter;
            char decryptchar = 'a';
            char Key1 = 'a', Key2 = 'a', Key3 = 'a';
            int wordsum = 0;
            int plaincharsum = 0;
            int[] Key = new int[2]{0,0};
            try
            {
                FileInfo MyFile = new FileInfo("cipher1.txt");
                StreamReader sr = MyFile.OpenText();
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    string[] tempStrArray = tempStr.Split(new char[1] { ',' });
                    checked
                    {
                        foreach (string ascii in tempStrArray)
                        {
                            ciphertext.Add((char)int.Parse(ascii));
                        }
                    }
                }
                cipherLen = ciphertext.Count();
                for (char i = 'a'; i <= 'z'; i++)
                {
                    wordsum = 0;
                    for (cipherIter = 0; cipherIter < cipherLen; cipherIter+=3)
                    {
                        decryptchar = (char)(ciphertext[cipherIter] ^ i);
                        if ((decryptchar >= 'A' && decryptchar <= 'Z') || (decryptchar >= 'a' && decryptchar <= 'z'))
                        {
                            wordsum++;
                            if (wordsum > Key[1])
                            {
                                Key[0] = i;
                                Key[1] = wordsum;
                            }
                        }                           
                    }
  
                }
                Key1 = (char)Key[0];
                Key[0] = 0;
                Key[1] = 0;
                for (char i = 'a'; i <= 'z'; i++)
                {
                    wordsum = 0;
                    for (cipherIter = 1; cipherIter < cipherLen; cipherIter += 3)
                    {
                        decryptchar = (char)(ciphertext[cipherIter] ^ i);
                        if ((decryptchar >= 'A' && decryptchar <= 'Z') || (decryptchar >= 'a' && decryptchar <= 'z'))
                        {
                            wordsum++;
                            if (wordsum > Key[1])
                            {
                                Key[0] = i;
                                Key[1] = wordsum;
                            }
                        }
                    }

                }
                Key2 = (char)Key[0];
                Key[0] = 0;
                Key[1] = 0;
                for (char i = 'a'; i <= 'z'; i++)
                {
                    wordsum = 0;
                    for (cipherIter = 2; cipherIter < cipherLen; cipherIter += 3)
                    {
                        decryptchar = (char)(ciphertext[cipherIter] ^ i);
                        if ((decryptchar >= 'A' && decryptchar <= 'Z') || (decryptchar >= 'a' && decryptchar <= 'z'))
                        {
                            wordsum++;
                            if (wordsum > Key[1])
                            {
                                Key[0] = i;
                                Key[1] = wordsum;
                            }
                        }
                    }

                }
                Key3 = (char)Key[0];
           
                for(cipherIter = 0; cipherIter < cipherLen; cipherIter++)
                {
                    switch (cipherIter % 3)
                    {
                        case 0: decryptchar = (char)(Key1 ^ ciphertext[cipherIter]); break;
                        case 1: decryptchar = (char)(Key2 ^ ciphertext[cipherIter]); break;
                        case 2: decryptchar = (char)(Key3 ^ ciphertext[cipherIter]); break;
                    }
                    Console.Write("{0}", decryptchar);
                    plaincharsum += decryptchar;
                }
                Console.WriteLine("The character sum of the plain text is:{0}",plaincharsum);
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

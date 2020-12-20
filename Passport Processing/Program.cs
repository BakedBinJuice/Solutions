using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Passport_Processing
{
    class Processing
    {
        public void PassportProcessing()
        {
            var readData = System.IO.File.ReadAllLines(@"data.txt");
            string[] criterea = { "byr", "iry", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
            int count = 0;
            List<string> instanceGroup = new List<string>();
            for (int i = 0; i < readData.Length; i++)
            {
                string readLine = readData[i];
                char[] dataArray = readData[i].ToCharArray();
                if (readLine != "")
                {
                    for (int n = 0; n < readLine.Length; n++)
                    {
                        if (readLine[n].Equals(':'))
                        {
                            int x = n - 3;
                            int y = n - 2;
                            int z = n - 1;
                            string instance = readLine[x].ToString() + readLine[y].ToString() + readLine[z].ToString();
                            instanceGroup.Add(instance);
                        }
                    }
                }
                else
                {
                    if (instanceGroup.Count == criterea.Length)
                    {
                        count++;
                        //Console.WriteLine(count);
                    }
                    else if (instanceGroup.Count == 7)
                    {
                        if (instanceGroup.Contains("cid") == false)
                        {
                            count++;
                            //Console.WriteLine(count);
                        }
                    }
                    instanceGroup.Clear();
                }
            }
            Console.WriteLine(count);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Processing Processing = new Processing();
            Processing.PassportProcessing();
        }
    }
}

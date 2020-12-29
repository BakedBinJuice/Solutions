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
                            //find byr - year
                            if (instance == "byr" || instance == "iyr" || instance == "eyr")
                            {
                                int f;
                                x = n + 4;
                                y = n + 3;
                                z = n + 2;
                                f = n + 1;
                                string byrstr = readLine[f].ToString() + readLine[z].ToString() + readLine[y].ToString() + readLine[x].ToString();
                                int byr;
                                int.TryParse(byrstr, out byr);
                                if (instance == "byr")
                                {
                                    if (byr >= 1920 && byr <= 2002)
                                    {
                                        instanceGroup.Add(instance);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (instance == "iyr")
                                {
                                    if (byr >= 2010 && byr <= 2020)
                                    {
                                        instanceGroup.Add(instance);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (instance == "eyr")
                                {
                                    if (byr >= 2020 && byr <= 2030)
                                    {
                                        instanceGroup.Add(instance);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            else if (instance == "hgt")
                            {
                                try
                                {
                                    int f;
                                    int g;
                                    int v;
                                    v = n + 6;
                                    x = n + 5;
                                    y = n + 4;
                                    z = n + 3;
                                    f = n + 2;
                                    g = n + 1;
                                    string hgtstr = (readLine[g].ToString() + readLine[f].ToString() + readLine[z].ToString() + readLine[y].ToString() + readLine[x].ToString());
                                    string hgttype = Regex.Replace(hgtstr, "[^a-zA-Z]", "");
                                    string hgtval = Regex.Replace(hgtstr, "[^0-9]", "");
                                    int hgtint;
                                    Int32.TryParse(hgtval, out hgtint);
                                    if (hgttype == "cm")
                                    {
                                        if (hgtint >= 150 && hgtint <= 193)
                                        {
                                            instanceGroup.Add(instance);
                                        }
                                    }
                                    else if (hgttype == "in")
                                    {
                                        if (hgtint >= 59 && hgtint >= 76)
                                        {
                                            instanceGroup.Add(instance);
                                        }
                                    }
                                }
                                catch (System.IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        int f;
                                        int g;
                                        y = n + 4;
                                        z = n + 3;
                                        f = n + 2;
                                        g = n + 1;
                                        string hgtstr = (readLine[g].ToString() + readLine[f].ToString() + readLine[z].ToString() + readLine[y].ToString());
                                        string hgttype = Regex.Replace(hgtstr, "[^a-zA-Z]", "");
                                        string hgtval = Regex.Replace(hgtstr, "[^0-9]", "");
                                        int hgtint;
                                        Int32.TryParse(hgtval, out hgtint);
                                        if (hgttype == "cm")
                                        {
                                            if (hgtint >= 150 && hgtint <= 193)
                                            {
                                                instanceGroup.Add(instance);
                                            }
                                        }
                                        else if (hgttype == "in")
                                        {
                                            if (hgtint >= 59 && hgtint >= 76)
                                            {
                                                instanceGroup.Add(instance);
                                            }
                                        }
                                    }
                                    catch (System.IndexOutOfRangeException)
                                    {
                                        continue;
                                    }
                                }
                            }
                            else if (instance == "hcl")
                            {
                                string alpha = "abcdef";
                                string hclstr = "";
                                for (int h = n + 1; h <= n + 7 && h < readLine.Length; h++)
                                {
                                    hclstr += readLine[h].ToString();
                                }
                                if (hclstr[0] == '#')
                                {
                                    string hclcore = Regex.Replace(hclstr, "[^a-zA-Z-^0-9]", "");
                                    if (hclcore.Length == 6)
                                    {
                                        string hcllet = Regex.Replace(hclcore, "[^a-zA-Z]", "");
                                        foreach (var letter in hcllet)
                                        {
                                            if (alpha.ToLower().Contains(letter))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                instanceGroup.Clear();
                                                break;
                                            }
                                        }
                                        instanceGroup.Add(instance);
                                    }
                                }
                            }
                            else if (instance == "ecl")
                            {
                                string[] eyeList = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                x = n + 3;
                                y = n + 2;
                                z = n + 1;
                                string ecl = readLine[z].ToString() + readLine[y].ToString() + readLine[x].ToString();
                                foreach (var colour in eyeList)
                                {
                                    if (ecl == colour)
                                    {
                                        instanceGroup.Add(instance);
                                    }
                                }
                            }
                            else if (instance == "pid")
                            {
                                string pid = "";
                                for (int j = n + 1; j < n + 10 && j < readLine.Length; j++)
                                {
                                    pid += readLine[j].ToString();
                                }
                                if (pid.Length == 9)
                                {
                                    string eclInts = Regex.Replace(pid, "[^0-9]", "");
                                    if (eclInts.Length == 9)
                                    {
                                        instanceGroup.Add(instance);
                                    }
                                }
                            }
                            else if (instance == "cid")
                            {
                                instanceGroup.Add(instance);
                            }
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

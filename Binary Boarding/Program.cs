﻿using System;

namespace Binary_Boarding
{
    class BinaryBoarding
    {
        public decimal findMidNum(Char lu, double z, double y) 
        {
            decimal finalInt = 0;
            for (double x = 0; x < y; x = x + 0.1)
            {
                z += 0.1;
                y -= 0.1;
                if (z + 0.5 > y)
                {
                    if (lu == 'F' || lu == 'L')
                    {
                        finalInt = Math.Floor((decimal)z);
                        return finalInt;
                    }
                    else if (lu == 'B' || lu == 'R')
                    {
                        finalInt = Math.Ceiling((decimal)y);
                        return finalInt;
                    }
                }
            }
            return finalInt;

        }
        public void part1()
        {
            decimal rows = 0;
            decimal collumns = 0;
            string input = "FBFBBFFRLR";
            double startRange = 0;
            decimal startRangeDec = 0;
            double val = 127;
            decimal valDec = 127;
            double collumnRange = 0;
            decimal collumnRangeDec = 0;
            double collumnVal = 7;
            decimal collumnValDec = 7;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'F' || input[i] == 'B')
                {
                    startRange = System.Convert.ToDouble(startRangeDec);
                    val = System.Convert.ToDouble(valDec);
                    decimal foundNum = findMidNum(input[i], startRange, val);
                    if (input[i] == 'F')
                    {
                        valDec = System.Convert.ToDecimal(foundNum);
                    }
                    else if (input[i] == 'B')
                    {
                        startRangeDec = System.Convert.ToDecimal(foundNum);
                    }
                    if (startRangeDec == valDec)
                    {
                        Console.WriteLine(startRangeDec);
                        rows = startRangeDec;
                    }
                    else 
                    {
                        Console.WriteLine(startRangeDec + " - " + valDec);
                    }
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'L' || input[i] == 'R')
                {
                    collumnRange = System.Convert.ToDouble(collumnRangeDec);
                    collumnVal = System.Convert.ToDouble(collumnValDec);
                    decimal foundNum = findMidNum(input[i], collumnRange, collumnVal);
                    if (input[i] == 'L')
                    {
                        collumnValDec = System.Convert.ToDecimal(foundNum);
                    }
                    else if (input[i] == 'R')
                    {
                        collumnRangeDec = System.Convert.ToDecimal(foundNum);
                    }
                    if (collumnRangeDec == collumnValDec)
                    {
                        collumns = collumnRangeDec;
                        Console.WriteLine(collumns);
                    }
                    else
                    {
                        Console.WriteLine(collumnRangeDec + " - " + collumnValDec);
                    }
                }
            }
            decimal finalAnswer = rows * 8 + collumns;
            Console.WriteLine(finalAnswer);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryBoarding binaryBoarding = new BinaryBoarding();
            binaryBoarding.part1();
        }
    }
}

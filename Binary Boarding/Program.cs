using System;

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
                    decimal startMid = Math.Floor((decimal)z);
                    decimal endMid = Math.Ceiling((decimal)y);
                    if (lu == 'F')
                    {
                        finalInt = startMid;
                        return finalInt;
                    }
                    else if (lu == 'B')
                    {
                        finalInt = endMid;
                        return finalInt;
                    }
                }
            }
            return finalInt;

        }
        public void part1()
        {
            string input = "FBFBBFFRLR";
            double startRange = 0;
            double val = 127;
            decimal valDec = 127;
            for (int i = 0; i < input.Length; i++)
            {
                val = System.Convert.ToDouble(valDec);
                decimal foundNum = findMidNum(input[i], startRange, val);
                valDec = System.Convert.ToDecimal(foundNum);
                Console.WriteLine(val);
            }
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

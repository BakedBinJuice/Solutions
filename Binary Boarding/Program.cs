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
                    if (lu == 'F')
                    {
                        finalInt = Math.Floor((decimal)z);
                        return finalInt;
                    }
                    else if (lu == 'B')
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
            string input = "FBFBBFFRLR";
            double startRange = 0;
            decimal startRangeDec = 0;
            double val = 127;
            decimal valDec = 127;
            for (int i = 0; i < input.Length; i++)
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
                Console.WriteLine(startRangeDec + " - " + valDec);
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

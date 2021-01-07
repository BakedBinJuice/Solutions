using System;

namespace Binary_Boarding
{
    class BinaryBoarding
    {
        public void part1()
        {
            string input = "FBFBBFFRLR";
            double startRange = 0;
            double endRange = 127;

            for (int i = 0; i < input.Length; i++)
            {
                for (double x = 0; x < endRange; x = x + 0.1)
                {
                    startRange += 0.1;
                    endRange -= 0.1;
                    int startMid = (int)Math.Round(startRange);
                    int  endMid = (int)Math.Round(endRange);
                    //Console.WriteLine(startRange + " " + endRange);
                    if (startMid == endMid)
                    {
                        Console.WriteLine(startMid + " " + endMid);
                        break;
                    }
                }
                break;
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

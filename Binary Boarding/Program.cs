using System;

namespace Binary_Boarding
{
    class BinaryBoarding
    {
        public void part1()
        {
            string input = "FBFBBFFRLR";
            int range = 127;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'F')
                {
                    range = range / 2;
                    Console.WriteLine("lower " + "0 through " + range);
                }
                else if (input[i] == 'B')
                {
                    int x = range;
                    range = range / 2;
                    Console.WriteLine("upper " + range + " though " + x);
                }
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

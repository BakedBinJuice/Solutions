using System;

namespace Day_1_2020
{
    class Find2020 {
        public void readData(){
            string[] data = System.IO.File.ReadAllLines(@"data.txt");

            Console.WriteLine("Searching File...");

            foreach (var lineRead in data) {
                int lineInt = int.Parse(lineRead);
                int mainInt = lineInt;

                foreach (var line in data) {
                    int intLine = int.Parse(line);
                    int checkSum = mainInt + intLine;
                    //Console.WriteLine(mainInt + " + " + intLine + " = " + checkSum);

                    if (checkSum == 2020) {
                        Console.WriteLine("Found Sum => " + mainInt + " + " + intLine + " = " + checkSum);
                        int finalSum = mainInt * intLine;
                        Console.WriteLine(mainInt + " * " + intLine + " = " + finalSum);
                        //System.Environment.Exit(1);
                    }

                    foreach (var thirdLine in data) {
                        int line3 = int.Parse(thirdLine);
                        int checkSum2 = mainInt + intLine + line3;
                        //Console.WriteLine(mainInt + " + " + intLine + " + " + line3 + " = " + checkSum2);

                        if (checkSum2 == 2020) {
                            Console.WriteLine("Found Sum => " + mainInt + " + " + intLine + " + " + line3 + " = " + checkSum2);
                            int finalSum2 = mainInt * intLine * line3;
                            Console.WriteLine(mainInt + " * " + intLine + " * " + line3 + " = " + finalSum2);
                            System.Environment.Exit(1);
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Find2020 = new Find2020();
            Find2020.readData();
        }
    }
}

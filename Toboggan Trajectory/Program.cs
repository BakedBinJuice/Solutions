using System;
using System.Collections.Generic;

namespace Toboggan_Trajectory
{
    class Trajectory
    {
        public void trajectory()
        {
            var readData = System.IO.File.ReadAllLines(@"data.txt");
            int treeCount = 0;
            var width = readData[0].Length;
            int colIndex = 0;
            for (int rowIndex = 0; rowIndex < readData.Length; rowIndex++)
            {
                if (readData[rowIndex][colIndex % width] == '#')
                {
                    treeCount++;
                }
                colIndex += 3;
            }
            Console.WriteLine(treeCount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Trajectory Trajectory = new Trajectory();
            Trajectory.trajectory();
        }
    }
}

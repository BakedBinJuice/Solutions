using System;

namespace Toboggan_Trajectory
{
    class Trajectory
    {
        public void trajectoryPart1()
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
            Console.WriteLine("Part1:");
            Console.WriteLine(treeCount);

            int[] rightMoves = { 1, 3, 5, 7, 1 };
            int[] downMoves = { 1, 1, 1, 1, 2 };

            Console.WriteLine("\nPart2:");

            for (int i = 0; i < 5; i++)
            {
                int rightMove = rightMoves[i];
                int downMove = downMoves[i];
                Console.WriteLine(trajectoryPart2(readData, rightMove, downMove));
            }
            Console.WriteLine(treeCount);
        }

        public int trajectoryPart2(string[] readData, int rightMove, int downMove)
        {
            int treeCount = 0;
            int width = readData[0].Length;
            int colIndex = 0;
            for (int rowIndex = 0; rowIndex < readData.Length; rowIndex = rowIndex + downMove)
            {
                if (readData[rowIndex][colIndex % width] == '#')
                {
                    treeCount++;
                }
                colIndex += rightMove;
            }
            return (treeCount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Trajectory Trajectory = new Trajectory();
            Trajectory.trajectoryPart1();
        }
    }
}

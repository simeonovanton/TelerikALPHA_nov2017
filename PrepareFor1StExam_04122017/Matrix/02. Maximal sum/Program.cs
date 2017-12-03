using System;

namespace Maximum_Sum
{
    class MaxSum
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            int lines = int.Parse(numbers[0]);
            int strings = int.Parse(numbers[1]);

            int[,] matrix = new int[lines, strings];

            for (int row = 0; row < lines; row++)
            {
                var values = (Console.ReadLine().Split(' '));
                for (int column = 0; column < strings; column++)
                {
                    matrix[row, column] = int.Parse(values[column]);
                }
            }

            Console.WriteLine(BestSum(matrix));
        }
        static int BestSum(int[,] matrix)
        {
            int bestSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + // row 1
                              matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + // row 2 
                              matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2]; // row 3

                    if (bestSum < sum)
                    {
                        bestSum = sum;
                    }
                }
            }
            return bestSum;
        }

    }
}

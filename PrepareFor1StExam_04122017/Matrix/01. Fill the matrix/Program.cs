using System;

namespace Matrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string pattern = Console.ReadLine();

            switch (pattern)
            {
                case "a": PatternA(matrix); break;
                case "b": PatternB(matrix); break;
                case "c": PatternC(matrix); break;
                case "d": PatternD(matrix); break;
                default:
                    break;
            }
            //Print
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == (n - 1))
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PatternD(int[,] matrix)
        {
            int row = 0;
            int col = 0;
            string direction = "down";
            for (int i = 0; i < (matrix.GetLength(0) * matrix.GetLength(1)); i++)
            {
                matrix[row, col] = i + 1;
                switch (direction)
                {
                    case "down":
                        if (row >= matrix.GetLength(0) - 1 || matrix[row + 1, col] != 0)
                        {
                            direction = "right";
                        };
                        break;
                    case "right":
                        if (col >= matrix.GetLength(1) - 1 || matrix[row, col + 1] != 0)
                        {
                            direction = "up";
                        };
                        break;
                    case "up":
                        if (row <= 0 || matrix[row - 1, col] != 0)
                        {
                            direction = "left";
                        };
                        break;
                    case "left":
                        if (col <= 0 || matrix[row, col - 1] != 0)
                        {
                            direction = "down";
                        }; break;
                }
                switch (direction)
                {
                    case "down":
                        row++;
                        break;
                    case "right":
                        col++; break;
                    case "up":
                        row--; break;
                    case "left":
                        col--; break;
                }
            }
        }

        private static void PatternC(int[,] matrix)
        {
            int counter = 1;
            //First half of matrix
            for (int reversedRow = matrix.GetLength(0); reversedRow >= 0; reversedRow--)
            {
                for (int col = 0; col < matrix.GetLength(0) - reversedRow; col++)
                {
                    if (col == 0)
                    {
                        matrix[reversedRow, col] = counter;
                        counter++;
                    }
                    else
                    {
                        matrix[(reversedRow + col), col] = counter;
                        counter++;
                    }
                }
            }
            // Second half of matrix
            for (int col = 1; col <= matrix.GetLength(1) - 1; col++)
            {
                for (int row = 0; row < (matrix.GetLength(0) - col); row++)
                {
                    if (row == 0)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                    else
                    {
                        matrix[row, (col + row)] = counter;
                        counter++;
                    }
                }
            }
        }

        private static void PatternB(int[,] matrix)
        {
            int counter = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
        }

        private static void PatternA(int[,] matrix)
        {
            int counter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //fill cols first 
                    matrix[col, row] = counter;
                    counter++;
                }
            }
        }
    }
}

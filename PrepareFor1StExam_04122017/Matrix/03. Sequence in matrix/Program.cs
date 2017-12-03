using System;

namespace _03.Sequence_in_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);

            string[,] matrix = new string[a, b];
            for (int row = 0; row < a; row++)
            {
                var tempString = (Console.ReadLine().Split(' '));
                for (int column = 0; column < b; column++)
                {
                    matrix[row, column] = tempString[column]; // parse numbers for column
                }
            }

            int[,] maxSequence = new int[a, b];
            for (int row = 0; row < a; row++)
            {
                for (int col = 0; col < b; col++)
                {
                    maxSequence[row, col] = 1;
                }
            }

            MasterMatrixCalculation(a, b, matrix, maxSequence);

            int result = 0;
            for (int row = 0; row < a; row++)
            {
                for (int col = 0; col < b; col++)
                {
                    if (result < maxSequence[row, col])
                    {
                        result = maxSequence[row, col];
                    }
                }
            }

            Console.WriteLine(result);
        }
        static void MasterMatrixCalculation(int n, int m, string[,] matrix, int[,] maxSequence)
        {
            //matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    //create a sub matrix for check each element of master matrix
                    //top side
                    for (int top = 0; top < 3; top++)
                    {
                        if (((row - 1) < 0) || (((col - 1) + top < 0) || (((col - 1) + top) > m - 1)))
                        {
                            continue;
                        }
                        else
                        {
                            if (matrix[(row - 1), ((col - 1) + top)] == matrix[row, col])
                            {
                                maxSequence[row, col] += maxSequence[(row - 1), ((col - 1) + top)];
                                maxSequence[(row - 1), ((col - 1) + top)] = 0;
                            }
                        }
                    }

                    //right side
                    if (!((col + 1) > m - 1))
                    {
                        if (matrix[row, (col + 1)] == matrix[row, col])
                        {
                            maxSequence[row, col] += maxSequence[row, (col + 1)];
                            maxSequence[row, (col + 1)] = 0;
                        }
                    }

                    //left side
                    if (!((col - 1) < 0))
                    {
                        if (matrix[row, (col - 1)] == matrix[row, col])
                        {
                            maxSequence[row, col] += maxSequence[row, (col - 1)];
                            maxSequence[row, (col - 1)] = 0;
                        }
                    }

                    //bottom side
                    for (int bottom = 0; bottom < 3; bottom++)
                    {
                        if (((row + 1) > n - 1) || (((col - 1) + bottom < 0) || (((col - 1) + bottom) > m - 1)))
                        {
                            continue;
                        }
                        else
                        {
                            if (matrix[(row + 1), ((col - 1) + bottom)] == matrix[row, col])
                            {
                                maxSequence[row, col] += maxSequence[(row + 1), ((col - 1) + bottom)];
                                maxSequence[(row + 1), ((col - 1) + bottom)] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
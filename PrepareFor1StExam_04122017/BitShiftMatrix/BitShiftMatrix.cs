using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class BitShiftMatrix
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int moves = int.Parse(Console.ReadLine());
        int[] code = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int coef = Math.Max(rows, cols);

        //Manage position input
        int[][] positionToGo = new int[code.Length][];
        for (int i = 0; i < code.Length; i++)
        {
            positionToGo[i] = new int[] { code[i] / coef, code[i] % coef };
        }

        //Making the matrix field
        BigInteger[,] matrix = new BigInteger[rows, cols];

        for (int row = rows - 1; row >= 0; row--)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = (BigInteger)Math.Pow(2, col) * (BigInteger)Math.Pow(2, rows - row - 1);
            }
        }
        // Test print matrix
        //for (int row = 0; row < rows; row++)
        //{
        //    for (int col = 0; col < cols; col++)
        //    {
        //        Console.Write("{0, 4}",matrix[row, col]);
        //    }
        //    Console.WriteLine();
        //}
        //return;


        int[] currentPosition = { rows - 1, 0 };
        BigInteger sum = matrix[currentPosition[0], currentPosition[1]];

        matrix[currentPosition[0], currentPosition[1]] = 0;

        // Passing matrix
        for (int i = 0; i < moves; i++)
        {
            //columns first
            for (int nextPosition = Math.Min(currentPosition[1], positionToGo[i][1]);
                nextPosition <= Math.Max(currentPosition[1], positionToGo[i][1]);
                nextPosition++)
            {
                sum += matrix[currentPosition[0], nextPosition];
                matrix[currentPosition[0], nextPosition] = 0;
            }
            currentPosition[1] = positionToGo[i][1];

            //rows second
            for (int nextPosition = Math.Min(currentPosition[0], positionToGo[i][0]);
                nextPosition <= Math.Max(currentPosition[0], positionToGo[i][0]);
                nextPosition++)
            {
                sum += matrix[nextPosition, currentPosition[1]];
                matrix[nextPosition, currentPosition[1]] = 0;
            }
            currentPosition[0] = positionToGo[i][0];
        }
        Console.WriteLine(sum);

    }
}


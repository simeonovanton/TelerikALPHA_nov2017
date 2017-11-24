using System;

public class Program
{
    public static void Main()
    {
        int[,] matrix =
        {
            {1, 2},
            {3, 4}
        };

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, 4}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
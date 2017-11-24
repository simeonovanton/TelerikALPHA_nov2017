using System;

public class Program
{
    public static void Main()
    {
        // Read from the Console. It could be read from any source (ex: file)
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                // Interpolation strings
                Console.Write($"matrix[{row},{column}] = ");
                matrix[row, column] = int.Parse(Console.ReadLine());
            }
        }
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                // Interpolation strings
                Console.Write($"matrix[{row},{column}] = " + matrix[row, column] + " ");
            }
            Console.WriteLine();
        }
    }
}
 
using System;

class FindLargestArea
{
    // Performs depth-first search recursively. Returns number of matching elements found.
    static int DepthFirstSearch(int[,] matrix, bool[,] discovered, int startColumn,
        int startRow, int searchValue)
    {
        int elementsFound;

        // If index is out of range, element was already visited or doesn't match the search
        // value then return zero and finish recursion.
        if ((startColumn < 0) || (startColumn >= matrix.GetLength(0)) || (startRow < 0) ||
            (startRow >= matrix.GetLength(1)) || discovered[startColumn, startRow] ||
            (matrix[startColumn, startRow] != searchValue))
        {
            return 0;
        }

        // Mark element as discovered so we won't count it again.
        discovered[startColumn, startRow] = true;
        elementsFound = 1;

        // Recursively check all neighbour elements.
        for (int row = startRow - 1; row < startRow + 2; row++)
        {
            for (int column = startColumn - 1; column < startColumn + 2; column++)
            {
                elementsFound += DepthFirstSearch(matrix, discovered, column, row, searchValue);
            }
        }

        return elementsFound;
    }

    static void Main()
    {
        string[] input;
        int columnCount;
        int rowCount;
        int[,] matrix;
        bool[,] discovered;
        int bestLength = 0;
        int currentLength;

        // Read the matrix.
        Console.Write("Enter the number of columns: ");
        columnCount = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of rows: ");
        rowCount = int.Parse(Console.ReadLine());

        matrix = new int[columnCount, rowCount];
        discovered = new bool[columnCount, rowCount];

        for (int i = 0; i < rowCount; i++)
        {
            Console.Write("Enter row #{0}: ", i);
            input = Console.ReadLine().Split(" ".ToCharArray(), columnCount, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < input.Length; j++)
            {
                matrix[j, i] = int.Parse(input[j]);
            }
        }

        // Perform depth-first search for every element and store the biggest value.
        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                currentLength = DepthFirstSearch(matrix, discovered, column, row, matrix[column, row]);

                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                }
            }
        }

        // Print the result.
        Console.WriteLine("The longest sequence found has {0} elements.", bestLength);
    }
}
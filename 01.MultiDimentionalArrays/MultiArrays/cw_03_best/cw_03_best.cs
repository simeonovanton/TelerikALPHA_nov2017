using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class cw_03_best
{
    // Performs depth-first search recursively. Returns number of matching elements found.
    static int DepthFirstSearch(int[,] matrix, bool[,] discovered, int startRow,
        int startColumn, int searchValue)
    {

        // If index is out of range, element was already visited or doesn't match the search
        // value then return zero and finish recursion.
        if ((startRow < 0) || (startRow >= matrix.GetLength(0)) || (startColumn < 0) ||
            (startColumn >= matrix.GetLength(1)) || discovered[startRow, startColumn] ||
            (matrix[startRow, startColumn] != searchValue))
        {
            return 0;
        }

        int elementsFound;

        // Mark element as discovered so we won't count it again.
        discovered[startRow, startColumn] = true;
        elementsFound = 1;

        // Recursively check all neighbour elements.
        for (int row = startRow - 1; row <= startRow + 1; row++)
        {
            for (int column = startColumn - 1; column <= startColumn + 1; column++)
            {
                elementsFound += DepthFirstSearch(matrix, discovered, row, column, searchValue);
            }
        }

        return elementsFound;
    }

    static void Main()
    {
        string[] nAndM = Console.ReadLine().Split(' ').ToArray();
        int n = int.Parse(nAndM[0]);
        int m = int.Parse(nAndM[1]);
        int[,] arr = new int[n, m];

        string[] inputString = new string[m];

        // Input the matrix

        for (int i = 0; i < n; i++)
        {
            inputString = Console.ReadLine().Split(' ').ToArray();
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = int.Parse(inputString[j]);
            }
        }

        int currentMaxArea = 0;
        int maxArea = 0;
        bool[,] traversed = new bool[arr.GetLength(0), arr.GetLength(1)];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                currentMaxArea = DepthFirstSearch(arr, traversed, i, j, arr[i, j]);
                if (currentMaxArea > maxArea)
                {
                    maxArea = currentMaxArea;
                }
            }
           
        }
        Console.WriteLine(maxArea);

    }
}


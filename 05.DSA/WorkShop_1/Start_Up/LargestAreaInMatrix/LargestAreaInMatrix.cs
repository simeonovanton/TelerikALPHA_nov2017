using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrix
{
    class LargestAreaInMatrix
    { 
        private static int largestArea = 0;
        private static int tempLargeArea = 0;
        private static int[] Rows = new int[] {1, 0, -1, 0};
        private static int[] Cols = new int[] {0, -1, 0, 1};
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            int[,] matrix = new int[n, m];
            bool[,] visited = new bool[n, m];
            ReadMatrix(matrix);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    tempLargeArea = 0;
                    FindPath(i, j, matrix, visited);
                }
            }
            Console.WriteLine(largestArea);
        }

        private static void ReadMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                var tempLineInput = Console.ReadLine().Split().Select(int.Parse).ToList();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = tempLineInput[j];
                }
            }
        }

        private static void FindPath(int row, int col, int[,] matrix, bool[,] visited)
        {
            if (!CheckIsIn(row, col, matrix) || visited[row, col])
            {
                //Do what have to do!!! - Print current largest area
                if (tempLargeArea > largestArea)
                {
                    largestArea = tempLargeArea;
                }
                return;
            }
            visited[row, col] = true;
            tempLargeArea++;
            for (int i = 0; i < 4; i++)
            {
                if (CheckIsIn(row + Rows[i], col + Cols[i], matrix)
                    && matrix[row, col] == matrix[row + Rows[i], col + Cols[i]])
                {
                    FindPath(row + Rows[i], col + Cols[i], matrix, visited);
                    //tempLargeArea--;
                }
            }
        }

        private static bool CheckIsIn(int row, int col, int[,] arr)
        {
            return row > -1 && row < arr.GetLength(0) && col > -1 && col < arr.GetLength(1);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_02_Maximal_Sum
{
    class cw_02_Maximal_Sum
    {
        static void Main()
        {
            string[] nAndM = Console.ReadLine().Split(' ');
            int n = int.Parse(nAndM[0]);
            int m = int.Parse(nAndM[1]);
            int[,] arr = new int[n, m];
            long maxSum = long.MinValue;
            // Reading the input matrix            
            for (int row = 0; row < n; row++)
            {
                int[] tempInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < m; col++)
                {
                    arr[row, col] = tempInput[col];
                }
                Array.Clear(tempInput, 0, tempInput.Length);
            }
            // Paging the matrix from left to right and from top to bottom
            for (int row = 0; row < n - 2; row++)
            {
                for (int col = 0; col < m - 2; col++)
                {
                    long currentSum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            currentSum += arr[row + i, col + j];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}

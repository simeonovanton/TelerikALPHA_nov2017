using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_02
{
    class cw_02
    {
        static void Main()
        {
            string[] nAndM = Console.ReadLine().Split(' ').ToArray();
            int n = int.Parse(nAndM[0]);
            int m = int.Parse(nAndM[1]);
            int[,] arr = new int[n,m];

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

            long maxSum = long.MinValue;
            long tempMaxSum = 0;

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    tempMaxSum = 0;
                    tempMaxSum = arr[i - 1, j - 1] + arr[i - 1, j] + arr[i - 1, j + 1]
                                + arr[i, j - 1] + arr[i, j] + arr[i, j + 1]
                                + arr[i + 1, j - 1] + arr[i + 1, j] + arr[i + 1, j + 1];
                    if (tempMaxSum >= maxSum)
                    {
                        maxSum = tempMaxSum;
                    }
                }
            }

            Console.WriteLine(maxSum);

        }
    }
}

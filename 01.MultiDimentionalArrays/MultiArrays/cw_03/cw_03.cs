using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_03
{
    class cw_03
    {
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

            // For each node/element of the matrix - begins Depth - First Search
            int largestArea = 1;
            int[] currentIndex = new int[2];
            int[] lastNodeIndex = new int[2];

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    int currentLargestArea = 1;
                    bool[,] traversed = new bool[arr.GetLength(0), arr.GetLength(1)];
                    traversed[row, col] = true;
                    int counter = 1;
                    currentIndex[0] = row;
                    currentIndex[1] = col;
                    lastNodeIndex[0] = currentIndex[0];
                    lastNodeIndex[1] = currentIndex[1];

                    while (counter <= n * m)
                    {
                        currentIndex[0] = lastNodeIndex[0];
                        currentIndex[1] = lastNodeIndex[1];

                        if (currentIndex[0] + 1 < arr.GetLength(0))
                        {
                            if (
                                traversed[currentIndex[0] + 1, currentIndex[1]] == false
                                 &&
                                arr[currentIndex[0], currentIndex[1]] == arr[currentIndex[0] + 1, currentIndex[1]]
                                )
                            {
                                currentLargestArea++;
                                currentIndex[0] = currentIndex[0] + 1;
                                counter++;
                                traversed[currentIndex[0], currentIndex[1]] = true;
                                lastNodeIndex[0] = currentIndex[0];
                                lastNodeIndex[1] = currentIndex[1];
                            }
                        }

                        if (currentIndex[0] - 1 >= 0)
                        {
                            if (
                                traversed[currentIndex[0] - 1, currentIndex[1]] == false
                                 &&
                                arr[currentIndex[0], currentIndex[1]] == arr[currentIndex[0] - 1, currentIndex[1]]
                                )
                            {
                                currentLargestArea++;
                                currentIndex[0] = currentIndex[0] - 1;
                                counter++;
                                traversed[currentIndex[0], currentIndex[1]] = true;
                                lastNodeIndex[0] = currentIndex[0];
                                lastNodeIndex[1] = currentIndex[1];
                            }
                        }

                        if (currentIndex[1] + 1 < arr.GetLength(1))
                        {
                            if (
                                traversed[currentIndex[0], currentIndex[1] +1] == false
                                 &&
                                arr[currentIndex[0], currentIndex[1]] == arr[currentIndex[0], currentIndex[1] + 1]
                                )
                            {
                                currentLargestArea++;
                                currentIndex[1] = currentIndex[1] + 1;
                                counter++;
                                traversed[currentIndex[0], currentIndex[1]] = true;
                                lastNodeIndex[0] = currentIndex[0];
                                lastNodeIndex[1] = currentIndex[1];
                            }
                        }

                        if (currentIndex[1] - 1 >= 0)
                        {
                            if (
                                traversed[currentIndex[0], currentIndex[1]] == false
                                 &&
                                arr[currentIndex[0], currentIndex[1]] == arr[currentIndex[0], currentIndex[1] - 1]
                                )
                            {
                                currentLargestArea++;
                                currentIndex[1] = currentIndex[1] - 1;
                                counter++;
                                traversed[currentIndex[0], currentIndex[1] - 1] = true;
                                lastNodeIndex[0] = currentIndex[0];
                                lastNodeIndex[1] = currentIndex[1];
                            }
                        }

                    }
                    if (currentLargestArea >= largestArea)
                    {
                        largestArea = currentLargestArea;
                    }

                }
            }
            Console.WriteLine(largestArea);
        }
    }
}

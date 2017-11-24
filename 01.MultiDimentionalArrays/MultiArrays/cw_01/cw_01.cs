using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_01
{
    class cw_01
    {
        static void Main()
        {
            int nextColumn;
            int nextRow;
            int counter = 1;
            int currentRow;
            int currentColumn;

            int n = int.Parse(Console.ReadLine());

            int[,] matr = new int[n, n];

            char rule = char.Parse(Console.ReadLine());

            switch (rule)
            {
                case 'a':
                    for (int row = 0; row < matr.GetLength(0); row++)
                    {
                        for (int col = 0; col < matr.GetLength(1); col++)
                        {
                            matr[row, col] = 1 + col * n + row;
                        }
                    }
                    break;
                case 'b':
                    for (int row = 0; row < matr.GetLength(0); row++)
                    {
                        for (int col = 0; col < matr.GetLength(1); col++)
                        {
                            if (col % 2 == 0)
                            {
                                matr[row, col] = 1 + col * n + row;
                            }
                            else
                            {
                                matr[row, col] = (col + 1) * n - row;
                            }
                        }
                    }
                    break;
                case 'c':
                    // First part - Left/Down triangle
                    currentRow = n - 1;
                    currentColumn = 0;
                    while (true)
                    {
                        matr[currentRow, currentColumn] = counter;
                    }


                    // nextColumn = 0;
                    // nextRow = n - 1;
                    // counter = 1;
                    // while (counter <= n * n)
                    // {
                    //     currentColumn = nextColumn;
                    //     currentRow = nextRow;
                    //     matr[currentRow, currentColumn] = counter;
                    //     counter++;
                    //
                    //     // Propagade the numbers in top-left to bottom-right direction.
                    //     // Next diagonal starts at the row above or top of the next column if we are on top row.
                    //     while ((++currentColumn < n) && (++currentRow < n))
                    //     {
                    //         matr[currentRow, currentColumn] = counter++;
                    //     }
                    //
                    //     if (nextRow > 0)
                    //     {
                    //         nextRow--;
                    //     }
                    //     else
                    //     {
                    //         nextColumn++;
                    //     }
                    // }
                    break;
                case 'd':

                    currentRow = 0;
                    currentColumn = 0;
                    // Go Down ---------------------
                    goDown:
                    if (counter > n * n)
                    {
                        break;
                    }
                    //if (counter != 1)
                    //{
                    //    currentColumn++;
                    //}
                    while (currentRow < n - 1)
                    {
                        matr[currentRow, currentColumn] = counter;
                        counter++;
                        if (matr[currentRow + 1, currentColumn] != 0)
                        {
                            currentColumn++;
                            break;
                        }
                        currentRow++;
                    }
                    goto goRight;
                    // Go Right ---------------------

                    goRight:
                    if (counter > n * n)
                    {
                        break;
                    }
                    //currentColumn--;
                    while (currentColumn < n - 1)
                    {
                        matr[currentRow, currentColumn] = counter;
                        counter++;
                        if (matr[currentRow, currentColumn + 1] != 0)
                        {
                            currentRow--;
                            break;
                        }
                        currentColumn++;
                    }
                    goto goUp;

                    // Go Up ---------------------

                    goUp:
                    if (counter > n * n)
                    {
                        break;
                    }
                    //currentRow++;
                    while (currentRow > 0)
                    {                       
                        matr[currentRow, currentColumn] = counter;
                        counter++;
                        if (matr[currentRow - 1, currentColumn] != 0)
                        {
                            currentColumn--;
                            break;
                        }
                        currentRow--;
                    }
                    goto goLeft;

                    // Go Left ---------------------

                    goLeft:
                    if (counter > n * n)
                    {
                        break;
                    }
                    //currentColumn++;
                    while (currentColumn > 0)
                    {                        
                        matr[currentRow, currentColumn] = counter;
                        counter++;
                        if (matr[currentRow, currentColumn - 1] != 0)
                        {
                            currentRow++;
                            break;
                        }
                        currentColumn--;
                    }
                    goto goDown;




                    break;
                default:
                    break;
            }

            // Printing the matrix
            for (int row = 0; row < matr.GetLength(0); row++)
            {
                for (int col = 0; col < matr.GetLength(1); col++)
                {

                    //Console.Write("{0, 3}", matr[row, col]);
                    if (col != matr.GetLength(1) - 1)
                    {
                        Console.Write(matr[row, col] + " ");
                    }
                    else
                    {
                        Console.Write(matr[row, col]);
                   
                    }

                }

                Console.WriteLine();
            }
        }
    }
}

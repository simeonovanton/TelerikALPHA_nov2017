using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task_3
{
    static void Main()
    {
        int[] rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = rc[0];
        int cols = rc[1];

        int[][] p1 = new int[rows][];
        int[][] p2 = new int[rows][];
        bool[,]b1 = new bool[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                b1[i,j] = false;
            }
        }
        bool[,] b2 = new bool[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                b2[i, j] = false;
            }
        }


        for (int i = 0; i < rows; i++)
        {
            p1[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
        for (int i = 0; i < rows; i++)
        {
            p2[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        do
        {
            string input1 = Console.ReadLine();
          
            if (input1 == "END")
            {
                break;
            }
            string[] input = input1.Split(' ').ToArray();
            string p = input[0];
            int row = int.Parse(input[1]);
            int col = int.Parse(input[2]);
            if (p == "P1")
            {
                if (p1[row][col] == 0 && b1[row, col] == false)
                {
                    Console.WriteLine("Missed");
                    b1[row, col] = true;
                }
                else if (p1[row][col] == 0 && b1[row,col] == true)
                {
                    Console.WriteLine("Try again!");
                }
                else if (p1[row][col] == 1 && b1[row,col] == false)
                {
                    p1[row][col] = 0;
                    b1[row,col] = true;
                    Console.WriteLine("Booom");
                }
               
            }
            else if (p == "P2")
            {
                if (p2[row][col] == 0 && b2[row, col] == false)
                {
                    Console.WriteLine("Missed");
                    b2[row, col] = true;
                }
                else if (p2[row][col] == 0 && b2[row, col] == true)
                {
                    Console.WriteLine("Try again!");
                }
                else if (p2[row][col] == 1 && b2[row, col] == false)
                {
                    p2[row][col] = 0;
                    b2[row, col] = true;
                    Console.WriteLine("Booom");
                }
            }
            
        } while (true);
        int countP1 = 0;
        int countP2 = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (p1[i][j] == 1)
                {
                    countP1++;
                }
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (p2[i][j] == 1)
                {
                    countP2++;
                }
            }
        }
        Console.WriteLine("{0}:{1}", countP1, countP2);
    }
}


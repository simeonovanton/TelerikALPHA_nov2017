using System;

class Program
{
    static void Main()
    {
        var rowsCols = Console.ReadLine().Split(' ');
        var rows = int.Parse(rowsCols[0]);
        var cols = int.Parse(rowsCols[1]);

        var boardP1 = new int[rows, cols];
        var boardP2 = new int[rows, cols];
        var visitedP1 = new bool[rows, cols];
        var visitedP2 = new bool[rows, cols];

        var tanksP1 = 0;
        var tanksP2 = 0;

        for (int row = 0; row < rows; row++)
        {
            var line = Console.ReadLine().Split();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == "1")
                {
                    tanksP1++;
                }
               
            }
            
            for (int col = 0; col < cols; col++)
            {
                boardP1[row, col] = int.Parse(line[col]);
            }
        }


        for (int row = rows - 1; row >= 0; row--)
        {
            var line = Console.ReadLine().Split();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == "1")
                {
                    tanksP2++;
                }

            }
            for (int col = 0; col < cols; col++)
            {
                boardP2[row, col] = int.Parse(line[col]);
            }
        }

        //Console.WriteLine("------------");
        //PrintMatrix(boardP1);
        //Console.WriteLine("------------");
        //PrintMatrix(boardP2);


        while (true)
        {
            var command = Console.ReadLine();

            if (command == "END")
            {
                Console.WriteLine("{0}:{1}", tanksP1, tanksP2);
                break;
            }

            var commandParts = command.Split(' ');
            var player = commandParts[0];
            var bombRow = int.Parse(commandParts[1]);
            var bombCol = int.Parse(commandParts[2]);

            if (player == "P1")
            {
                // drop bomb on tank

                if (boardP2[bombRow, bombCol] == 1)
                {
                    Console.WriteLine("Booom");
                    boardP2[bombRow, bombCol] = 0;
                    visitedP2[bombRow, bombCol] = true;
                    tanksP2--;
                    if (tanksP2 <= 0)
                    {
                        Console.WriteLine("{0}:{1}", tanksP1, tanksP2);
                        break;
                    }
                }
                // drop bomb but tank
                else if (boardP2[bombRow, bombCol] == 0)
                {
                    if (visitedP2[bombRow, bombCol] == true)
                    {
                        Console.WriteLine("Try again!");
                    }
                    else
                    {
                        Console.WriteLine("Missed");
                        visitedP2[bombRow, bombCol] = true;
                    }

                }
                else if (visitedP2[bombRow, bombCol] == true)
                {
                    Console.WriteLine("Try again!");
                }

            }
            else if (player == "P2")
            {
                // drop bomb on tank
                if (boardP1[bombRow, bombCol] == 1)
                {
                    Console.WriteLine("Booom");
                    boardP1[bombRow, bombCol] = 0;
                    visitedP1[bombRow, bombCol] = true;
                    tanksP1--;
                    if (tanksP1 <= 0)
                    {
                        Console.WriteLine("{0}:{1}", tanksP1, tanksP2);
                        break;
                    }
                }
                // drop bomb but tank
                else if (boardP1[bombRow, bombCol] == 0)
                {
                    if (visitedP1[bombRow, bombCol] == true)
                    {
                        Console.WriteLine("Try again!");
                    }
                    else
                    {
                        Console.WriteLine("Missed");
                        visitedP1[bombRow, bombCol] = true;
                    }

                }
                else if (visitedP1[bombRow, bombCol] == true)
                {
                    Console.WriteLine("Try again!");
                }
            }
            else
            {
                throw new Exception("Invalid input");
            }
        }

    }



    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    Console.Write(matrix[row, col]);
                }
                else
                {
                    Console.Write(matrix[row, col] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}


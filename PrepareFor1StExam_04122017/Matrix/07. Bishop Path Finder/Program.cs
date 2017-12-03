using System;
using System.Linq;

namespace BishopPathFinder
{
    class BishopPath
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();
            int numberOfCommands = int.Parse(Console.ReadLine());
            var commands = new string[numberOfCommands];
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = Console.ReadLine();
            }

            int[,] filledBoard = FillChessboard(dimentions);
            int sumOfVisited = ExecuteCommands(filledBoard, commands);
            //PrintIntBoard(filledBoard);
            Console.WriteLine(sumOfVisited);

        }

        private static int ExecuteCommands(int[,] filledBoard, string[] commands)
        {

            int totalSum = 0;
            int currentRow = filledBoard.GetLength(0) - 1;
            int currentCol = 0;

            bool[,] visited = new bool[filledBoard.GetLength(0), filledBoard.GetLength(1)];
            foreach (var command in commands)
            {
                var tokens = command.Split(' ');
                string direction = tokens[0];
                int numberOfMoves = int.Parse(tokens[1]);
                for (int i = 0; i < numberOfMoves - 1; i++)
                {
                    visited[currentRow, currentCol] = true;
                    switch (direction)
                    {
                        case "UR":
                        case "RU":
                            if (currentRow != 0 && currentCol != filledBoard.GetLength(1) - 1)
                            {
                                currentRow--;
                                currentCol++;
                            }; break;
                        case "LU":
                        case "UL":
                            if (currentRow != 0 && currentCol != 0)
                            {
                                currentRow--;
                                currentCol--;
                            }; break;
                        case "DL":
                        case "LD":
                            if (currentRow != filledBoard.GetLength(0) - 1 && currentCol != 0)
                            {
                                currentRow++;
                                currentCol--;
                            }; break;
                        case "RD":
                        case "DR":
                            if (currentRow != filledBoard.GetLength(0) - 1 && currentCol != filledBoard.GetLength(1) - 1)
                            {
                                currentRow++;
                                currentCol++;
                            }; break;
                    }
                    if (!visited[currentRow, currentCol])
                    {
                        totalSum += filledBoard[currentRow, currentCol];
                    }
                }
            }

            //PrintBoolBoard(visited);
            return totalSum;
        }

        private static int[,] FillChessboard(int[] dimentions)
        {
            var boardRows = dimentions[0];
            var boardCols = dimentions[1];

            int[,] board = new int[boardRows, boardCols];
            int currentRow = board.GetLength(0) - 1;
            int currentCol = 0;
            int currentFillValue = 0;
            int increment = 3;

            for (int x = currentRow; x >= 0; x--)
            {
                var fillValue = currentFillValue;
                for (int y = currentCol; y < board.GetLength(1); y++)
                {
                    board[x, y] = fillValue;
                    fillValue += increment;
                }
                currentFillValue += 3;
            }

            return board;
        }
        private static void PrintBoolBoard(bool[,] filledBoard)
        {
            for (int i = 0; i < filledBoard.GetLength(0); i++)
            {
                for (int j = 0; j < filledBoard.GetLength(1); j++)
                {
                    Console.Write("{0} ", filledBoard[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static void PrintIntBoard(int[,] filledBoard)
        {
            for (int i = 0; i < filledBoard.GetLength(0); i++)
            {
                for (int j = 0; j < filledBoard.GetLength(1); j++)
                {
                    Console.Write("{0} ", filledBoard[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
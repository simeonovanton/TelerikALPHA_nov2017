using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTrackInLabirynth
{
    public class Coord
    {
        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public  int X { get; set; }
        public  int Y { get; set; }
    }


    class BackTracking
    {
        static Stack<Coord> stack = new Stack<Coord>();

        static char[,] lab =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        static void Main()
        {
            FindPath(0, 0);
        }
        

        static bool InRange(int row, int  col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPath(int row, int col)
        {
            if (!InRange(row, col))
            {
                // Out of area
                return;
            }

            if (lab[row, col] == 'e')
            {
                // Printing all the path
                PrintPath(row, col);
            }
           
            if (lab[row, col] != ' ')
            {
                //The current cell is not free
                return;
            }
            // Mark the cells as visited
            lab[row, col] = 's';
            stack.Push(new Coord(row, col));

            //Call the methot Itself for all directions
            FindPath(row, col - 1); // Left
            FindPath(row - 1, col); // Up
            FindPath(row, col + 1); // Right
            FindPath(row + 1, col); // Down

            //Mark the cells as free
            lab[row, col] = ' ';
            stack.Pop();
        }

        static void PrintPath(int finalRow, int finalCol)
        {
            Console.WriteLine("Found exit:");
                var newStack = stack.Reverse().ToArray();
                foreach (var tempCoord in newStack)
                {
                    Console.WriteLine($"[{tempCoord.X}, {tempCoord.Y}] ->");
                }
                Console.WriteLine($"[{finalRow}, {finalCol}]");
            Console.WriteLine();
        }
    }
}

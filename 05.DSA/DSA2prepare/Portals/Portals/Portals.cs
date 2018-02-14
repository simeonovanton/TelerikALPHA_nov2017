using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    public class Coord
    {
        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Portals
    {
        public static int R;
        public static int C;
        public static int startR;
        public static int startC;
        public static int[,] lab;
        public static int maxPower = 0;
        public static int accumulatedPower = 0;
        public static Stack<Coord> coordStack = new Stack<Coord>();
        public static Stack<int> powerStack = new Stack<int>();

        static void Main()
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            startR = xy[0];
            startC = xy[1];
            int[] rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            R = rc[0];
            C = rc[1];
            lab = new int[R, C];
            for (int i = 0; i < R; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < C; j++)
                {
                    if (line[j] != "#")
                    {
                        lab[i, j] = int.Parse(line[j]);
                    }
                    else
                    {
                        lab[i, j] = -1;
                    }
                }
            }
            FindMaxPower(startR, startC);
            Console.WriteLine(maxPower);
        }

        public static void FindMaxPower(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }

            if (lab[row, col] == -1)
            {
                return;
            }

            int currentPower = lab[row, col];
            powerStack.Push(currentPower);
            accumulatedPower += currentPower;
            if (accumulatedPower > maxPower)
            {
                maxPower = accumulatedPower;
            }
            //Mark the cell as visired
            lab[row, col] = -1;
            FindMaxPower(row, col - currentPower); //Left
            FindMaxPower(row - currentPower, col); //Up
            FindMaxPower(row, col + currentPower); //Right
            FindMaxPower(row - currentPower, col); //Down
            //Mark the cell as unvisited
            lab[row, col] = powerStack.Pop();
            accumulatedPower -= currentPower;

            //// Call the method itself for all directions

            ////Left
            //if (InRange(row, col - currentPower) && lab[row, col - currentPower] != -1)
            //{
            //    powerStack.Push(currentPower);
            //    accumulatedPower += currentPower;
            //    if (accumulatedPower > maxPower)
            //    {
            //        maxPower = accumulatedPower;
            //    }
            //    //Mark the cell as visired
            //    lab[row, col] = -1;
            //    FindMaxPower(row, col - currentPower); //Left
            //    //Mark the cell as unvisited
            //    lab[row, col] = powerStack.Pop();
            //    accumulatedPower -= currentPower;

            //}
            ////else
            ////{
            ////    return;
            ////}

            ////Up
            //if (InRange(row - currentPower, col) && lab[row - currentPower, col] != -1)
            //{
            //    powerStack.Push(currentPower);
            //    accumulatedPower += currentPower;
            //    if (accumulatedPower > maxPower)
            //    {
            //        maxPower = accumulatedPower;
            //    }
            //    //Mark the cell as visired
            //    lab[row, col] = -1;
            //    FindMaxPower(row - currentPower, col); //Up
            //    //Mark the cell as unvisited
            //    lab[row, col] = powerStack.Pop();
            //    accumulatedPower -= currentPower;
            //}
            ////else
            ////{
            ////    return;
            ////}

            ////Right
            //if (InRange(row, col + currentPower) && lab[row, col + currentPower] != -1)
            //{
            //    powerStack.Push(currentPower);
            //    accumulatedPower += currentPower;
            //    if (accumulatedPower > maxPower)
            //    {
            //        maxPower = accumulatedPower;
            //    }
            //    //Mark the cell as visired
            //    lab[row, col] = -1;
            //    FindMaxPower(row, col + currentPower); //Right
            //    //Mark the cell as unvisited
            //    lab[row, col] = powerStack.Pop();
            //    accumulatedPower -= currentPower;
            //}
            ////else
            ////{
            ////    return;
            ////}

            ////Down
            //if (InRange(row + currentPower, col) && lab[row + currentPower, col] != -1)
            //{
            //    powerStack.Push(currentPower);
            //    accumulatedPower += currentPower;
            //    if (accumulatedPower > maxPower)
            //    {
            //        maxPower = accumulatedPower;
            //    }
            //    //Mark the cell as visired
            //    lab[row, col] = -1;
            //    FindMaxPower(row - currentPower, col); //Down
            //    //Mark the cell as unvisited
            //    lab[row, col] = powerStack.Pop();
            //    accumulatedPower -= currentPower;
            //}
            ////else
            ////{
            ////    return;
            ////}
        }

        public static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}

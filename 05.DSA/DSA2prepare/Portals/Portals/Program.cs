using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Program
    {
        public static int R;
        public static int C;
        public static int startR;
        public static int startC;
        public static char[,] labirynth;

        static void Main()
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            startR = xy[0];
            startC = xy[1];
            int[] rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            R = rc[0];
            C = rc[1];
            labirynth = new char[R, C];
            for (int i = 0; i < R; i++)
            {
                char[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < C; j++)
                {
                    labirynth[i, j] = line[j];
                }
            }
        }
    }
}

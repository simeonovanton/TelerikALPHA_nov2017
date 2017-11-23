using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    class Practice_01
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagg = new int[rows][];

            for (int row = 0; row < jagg.GetLength(0); row++)
            {
                jagg[row] = new int[ ];
            }
        }
    }
}

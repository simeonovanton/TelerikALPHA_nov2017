using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start_Up
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            var buildings = Console.ReadLine()

                .Split().Select(x => int.Parse(x)).ToArray();

            Stack<int> jumpsPerBuilding = new Stack<int>();
            int[] maxJumpsMatrix = new int[N];
            int maxJump = 0;
            for (int i = 0; i < N - 1; i++)
            {
                int maxJumps = 0;
                for (int j = i + 1; j < N; j++)
                {
                    if (buildings[i] < buildings[j] )
                    {
                        jumpsPerBuilding.Push(buildings[j]);
                        if (jumpsPerBuilding.Count >= maxJumps)
                        {
                            maxJumps = jumpsPerBuilding.Count;
                        }
                    }
                    else
                    {
                        jumpsPerBuilding.Clear();
                    }
                }
                maxJumpsMatrix[i] = maxJumps;
            }

            foreach (var jump in maxJumpsMatrix)
            {
                if (jump >= maxJump)
                {
                    maxJump = jump;
                }
            }

            Console.WriteLine(maxJump);
            Console.WriteLine(string.Join(" ", maxJumpsMatrix));
        }   
    }
}

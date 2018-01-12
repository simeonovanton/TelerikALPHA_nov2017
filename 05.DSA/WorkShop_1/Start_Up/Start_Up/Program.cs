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

            //var buildings = Console.ReadLine()

            //    .Split().Select(x => int.Parse(x)).ToArray();
            var stringBuildings = Console.ReadLine().Split();
            int maxHeight = int.MinValue;
            int[] buildings = new int[N];
            for (int i = 0; i < N; i++)
            {
                if (int.Parse(stringBuildings[i]) > maxHeight)
                {
                    maxHeight = int.Parse(stringBuildings[i]);
                }
                buildings[i] = int.Parse(stringBuildings[i]);
            }

            LinkedList<int> jumpsPerBuilding = new LinkedList<int>();
            //Stack<int> jumpsPerBuilding = new Stack<int>();

            int[] maxJumpsMatrix = new int[N];
            int totalJumps = 0;
            for (int i = 0; i < N; i++)
            {
                int counter = 0;
                int currentBuilding = buildings[i];

                //if (buildings[i] == maxHeight)
                //{
                //    continue;
                //}
               
                for (int j = i + 1; j < N; j++)
                {
                    if (currentBuilding == maxHeight)
                    {
                        break;
                    }
                    if (currentBuilding < buildings[j])
                    {
                        counter++;
                        currentBuilding = buildings[j];
                    }
                }
                if (counter > totalJumps)
                {
                    totalJumps = counter;
                }
                jumpsPerBuilding.AddLast(counter);
                //jumpsPerBuilding.Push(counter);
            }


            //var newJumps = jumpsPerBuilding.Reverse();
            Console.WriteLine(totalJumps);
            // Console.WriteLine(string.Join(" ", newJumps));
             Console.WriteLine(string.Join(" ", jumpsPerBuilding));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    class Actions
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            bool[] visited = new bool[n];
            int[] numberOfParents = new int[n];
            List<int>[] children = new List<int>[n];

            for (int i = 0; i < m; i++)
            {
                int[] instruction = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parent = instruction[0];
                int child = instruction[1];

                if (children[parent] == null)
                {
                    children[parent] = new List<int>();
                }
                children[parent].Add(child);
                numberOfParents[child]++;
            }

            TopologicalSort(n, visited, numberOfParents, children);
        }

        private static void TopologicalSort(int n, bool[] visited, int[] numberOfParents, List<int>[] children)
        {
            bool areAllVisited = false;
            while (!areAllVisited)
            {
                areAllVisited = true;
                for (int i = 0; i < n; i++)
                {
                    if (numberOfParents[i] == 0 && visited[i] == false)
                    {
                        Console.WriteLine(i);
                        visited[i] = true;
                        //check if problem exists!
                        if (children[i] != null)
                        {
                            foreach (var child in children[i])
                            {
                                numberOfParents[child]--;
                            }
                        }
                        areAllVisited = false;
                        break;
                    }
                }
            }
        }
    }
}

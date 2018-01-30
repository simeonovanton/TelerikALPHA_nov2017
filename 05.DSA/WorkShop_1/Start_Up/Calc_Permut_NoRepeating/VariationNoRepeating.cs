using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Permutation
{
    class Calc_Permutation
    {
        static void Main()
        {
            Console.WriteLine("Generating repeatable permutations:\n" +
                "Please enter N=");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter K=");
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];
            bool[] visited = new bool[n];
            Permutations(0, k, n, arr, visited);
        }

        public static void Permutations(int index, int k, int n, int[] arr, bool[] visited)
        {
            if (index >= k)
            {
                PrintArray(arr);
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        arr[index] = i;
                        Permutations(index + 1, k, n, arr, visited);
                        visited[i] = false;
                    }
                }
            }
        }

        public static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}

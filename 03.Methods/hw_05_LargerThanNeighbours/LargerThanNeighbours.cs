using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_05_LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static int CheckForLargerElements(int[] arr)
        {
            int counter = 0;
            //if (arr[0] > arr[1])
            //{
            //    counter++;
            //}
            //if (arr[arr.Length - 1] > arr[arr.Length - 2])
            //{
            //    counter++;
            //}
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] >= arr[i - 1] && arr[i] >= arr[i + 1])
                {
                    counter++;
                }
            }
            return counter;
        }
        static void Main()
        {
            Console.ReadLine();
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(CheckForLargerElements(arr));
        }
    }
}

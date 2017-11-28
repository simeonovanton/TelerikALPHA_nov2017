using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_06_FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static int FirstLarger(int[] array)
        {
            //int index = 0;
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] >= array[i - 1] && array[i] >= array[i + 1])
                {
                    //index = i;
                    return i;
                }
            }

            return -1;
        }

        static void Main()
        {
            Console.ReadLine();
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(FirstLarger(arr));

        }
    }
}

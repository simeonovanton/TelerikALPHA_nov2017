using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class BubbleSort
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BubbleSortMethod(ref arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubbleSortMethod(ref int[] array)
        {
            bool swapped = false;
            while (!swapped)
            {
                swapped = true;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = false;
                    }
                }
            }
        }
    }
}

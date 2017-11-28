using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_04_AppearanceCount
{
    class AppearanceCount
    {
        static int SearchInArray(int[] array, int num)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (num == array[i])
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
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(SearchInArray(arr, number));


        }
    }
}

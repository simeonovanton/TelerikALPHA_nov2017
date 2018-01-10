using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchImplemetation
{
    public class Program
    {
        public static void Main()
        {
            int[] array = { 1, 5, 15, 30, 47, 56, 89, 101 };
            int value = 56;

            Console.WriteLine(BinarySearch(value, array, 0, array.Length - 1));

        }

        List<int> example = new List<int>();
        LinkedList<int> example2 = new LinkedList<int>();
        // IEnumerable<int> enums = new IEnumerable<int>();


        //public static int BinarySearch(int value, int[] arr, int minInd, int maxInd)
        //{
        //    enums.Aggregate(5);
        //    enums.Aggregate(6);
        //    enums.Aggregate(7);
        //    enums.Aggregate(8);
        //    enums.Aggregate(9);
        //    foreach (var item in enums)
        //    {
        //        Console.Write(item + " ");
        //    }

            return 0;//Binary(array, minIndex, maxIndex);
        }
    }
}

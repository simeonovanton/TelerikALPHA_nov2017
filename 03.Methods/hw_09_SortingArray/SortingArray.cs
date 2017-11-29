using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortingArray
{
    static int[] SortArray_Ascending( int[] array)
    {
        int buffer = 0;
        for (int i = array.Length - 1; i > 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (array[i] < array[j])
                {
                    buffer = array[j];
                    array[j] = array[i];
                    array[i] = buffer;
                }
            }
        }
        return array;
    }

    static string IntArrayToString(int[] array)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < array.Length; i++)
        {
            sb.Append(array[i]);
            if (i == array.Length - 1)
            {
                break;
            }
            sb.Append(' ');
        }
        return sb.ToString();
    }

    static void Main()
    {
        Console.ReadLine(); //Unnecessary

        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] sortedArray = SortArray_Ascending(arr);

        Console.WriteLine(IntArrayToString(sortedArray));
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumberAsArray
{
    //Method calculates the sum of the two arrays
    static int[] SumNumbersAsArrays(int[] array_1, int[] array_2)
    {
        int length = array_1.Length >= array_2.Length ? array_1.Length : array_2.Length;
        int[] sum = new int[length];
        int rest = 0;

        for (int i = 0; i < length; i++)
        {
            if (i >= array_1.Length)
            {
                sum[i] = array_2[i] + rest;
            }
            else if (i >= array_2.Length)
            {
                sum[i] = array_1[i] + rest;
            }
            else
            {
                sum[i] = array_1[i] + array_2[i] + rest;
            }

            if (sum[i] >= 10)
            {
                sum[i] = sum[i] % 10;
                rest = 1;
            }
            else
            {
                rest = 0;
            }
        }
        return sum;
    }

    static void Main()
    {
        Console.ReadLine(); //Unnecessary

        //Reading two strings
        int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        StringBuilder sb = new StringBuilder();
        int[] result = SumNumbersAsArrays(arr1, arr2);
        for (int i = 0; i < result.Length; i++)
        {
            sb.Append(result[i]);
            if (i == result.Length - 1)
            {
                break;
            }
            sb.Append(' ');

        }
        Console.WriteLine(sb);
    }
}


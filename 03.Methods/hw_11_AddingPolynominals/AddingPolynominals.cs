using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AddingPolynominals
{
    static int[] SumPolynoms(int[] arr1, int[] arr2)
    {
        int[] add = new int[arr1.Length];
        for (int i = 0; i < arr1.Length; i++)
        {
            add[i] = arr1[i] + arr2[i];
        }
        return add;
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
        Console.ReadLine(); //Why?

        int[] p1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] p2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int[] sum = SumPolynoms(p1, p2);

        Console.WriteLine(IntArrayToString(sum));
    }
}


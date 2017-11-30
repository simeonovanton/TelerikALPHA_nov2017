using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class IntegerCalculations
{
    static int ArrayMin(int[] arr)
    {
        int minimum = int.MaxValue;
        foreach (var item in arr)
        {
            if (item < minimum)
            {
                minimum = item;
            }
        }
        return minimum;
    }

    static int ArrayMax(int[] arr)
    {
        int maximum = int.MinValue;
        foreach (var item in arr)
        {
            if (item > maximum)
            {
                maximum = item;
            }
        }
        return maximum;
    }

    static float ArrayAverage(int[] arr)
    {
        float average = 0;
        average =(float) ArraySum(arr) / arr.Length;

        return average;
    }

    static int ArraySum(int[] arr)
    {
        int sum = 0;
        foreach (var item in arr)
        {
            sum += item;
        }

        return sum;
    }

    static long ArrayProduct(int[] arr)
    {
        long product = 1;
        foreach (var item in arr)
        {
            product *= item;
        }

        return product;
    }

    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine(ArrayMin(input));
        Console.WriteLine(ArrayMax(input));
        Console.WriteLine("{0:0.00}",ArrayAverage(input));
        Console.WriteLine(ArraySum(input));
        Console.WriteLine(ArrayProduct(input));
    }
}


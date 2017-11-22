using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Task_3
    {
        static void Main()
        {
            string input = Console.ReadLine();

            long[] arr1 = input.Split(' ').Select(str => long.Parse(str)).ToArray();

            BigInteger[] arr2 = new BigInteger[arr1.Length - 1];

            for (int i = 0; i < arr1.Length - 1; i++)
            {
                if (arr1[i + 1] >= arr1[i])
                {
                    arr2[i] = arr1[i + 1] - arr1[i];
                }
                else
                {
                    arr2[i] = arr1[i] - arr1[i + 1];

                }

            }

            for (int i = 0; i < arr2.Length - 1; i++)
            {
                if (arr2[i] % 2 == 0 && arr2[i] != 0)
                {
                    arr2[i + 1] = 0;
                }
            }
            BigInteger sum = 0;

            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] % 2 == 0)
                {
                    sum += arr2[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_02_GetLargestNumber
{
    class GetLargestNumber
    {
        static long GetMax(long a, long b)
        {
            return a >= b ? a : b;
        }
        static void Main()
        {
            long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
            Console.WriteLine(GetMax(GetMax(input[0], input[1]), input[2]));
        }
    }
}

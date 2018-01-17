using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OredredSetTest
{
    class OrderedSetTest
    {
        static void Main()
        {
            OrderedSet<int> set = new OrderedSet<int>(new int[] {5, 2, 1, 9, 7, 4, 3});
            foreach (var value in set)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            Console.WriteLine(set.Range(3, true, 6, true));
            IEnumerable<int> list = set.Range(3, true, 6, true);
            foreach (var value in list)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }
    }
}

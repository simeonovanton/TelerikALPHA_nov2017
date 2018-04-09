using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariationWithRepeat
{
    class Program
    {
        public int n;
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            GenerateVariations(0);
        }
        static void GenerateVariations(int index)
        {
            if (index >= k)
                Print(arr);
            else
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(index + 1);
                }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class FactorialCalc
    {
        public static int n = 0;
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{n}! = {Factorial(n)}");
        }

        public static long Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
           
            return n * Factorial(n - 1);
        }
    }
}

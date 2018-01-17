using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacchiWithoutMemorization
{
    class FibonacchiWithMemorization
    {
        static decimal[] fib = new decimal[1000];

        static void Main()
        {
            Console.WriteLine("Въведете число: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Fibonacci(n)}");

        }

        static decimal Fibonacci(int n)
        {
            if (fib[n] == 0)
            {

                if (n == 1 || n == 2)
                {
                    fib[n] = 1;
                }
                else
                {
                    fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                }
                
            }
            return fib[n];
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3
{
    class Expressions
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int n = input.Length;
            int[] digits = new int[n];
            for (int i = 0; i < n; i++)
            {
                digits[i] = input[i] - '0';
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();

        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            Console.Write(input[i]);
        }
        Console.WriteLine();
    }
}

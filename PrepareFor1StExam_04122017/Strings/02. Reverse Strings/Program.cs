using System;
using System.Linq;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine().ToCharArray().Reverse().ToArray();
            Console.WriteLine(inputString);
        }
    }
}
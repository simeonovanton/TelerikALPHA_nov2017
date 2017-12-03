using System;

namespace StringLength
{
    class LengthOfString
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string paddedString = inputString.PadRight(20, '*');

            Console.WriteLine(paddedString);
        }
    }
}
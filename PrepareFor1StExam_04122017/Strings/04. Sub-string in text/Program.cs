using System;

namespace Sub_string_in_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine().ToLower();
            string textToCheck = Console.ReadLine().ToLower();
            int startIndex = 0;
            int numberOfOccurrences = 0;

            while ((startIndex = textToCheck.IndexOf(pattern, startIndex, StringComparison.CurrentCultureIgnoreCase)) != -1)
            {
                numberOfOccurrences++;
                startIndex++;
            }

            Console.WriteLine(numberOfOccurrences);
        }
    }
}
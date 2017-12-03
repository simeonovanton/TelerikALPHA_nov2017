using System;
using System.Text.RegularExpressions;

namespace ParseTags
{
    class ParseTags
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = "<upcase>(.*?)</upcase>";
            string result = Regex.Replace(input, pattern, word => word.Groups[1].Value.ToUpper());

            Console.WriteLine(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace ParseTagsRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, @"<upcase>(.*?(?=<\/))<\/upcase>");

            foreach (Match match in matches)
            {
                input = input.Replace(match.Groups[0].ToString(), match.Groups[1].ToString().ToUpper());
            }

            Console.WriteLine(input);

        }
    }
}

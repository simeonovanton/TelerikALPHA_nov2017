using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Slogan
{
    class Slogan
    {
        public static HashSet<string> impossibleInputs = new HashSet<string>();
        public static List<string> totalResults = new List<string>();
        public static List<string> result = new List<string>();
        public static string output = string.Empty;
        public static int inputLength = 0;

        static void Main()
        {
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    List<string> wordsToSearch = Console.ReadLine().Trim().Split().ToList();
                    List<string> words = wordsToSearch.OrderByDescending(x => x.Length).ToList();
                    string input = Console.ReadLine();
                    inputLength = input.Length;
                    FindWords(words, input);
                    if (totalResults.Count > 0)
                    {
                        output = string.Join(" ", totalResults[0]);
                    }
                    else
                    {
                        output = "NOT VALID";
                    }
                    Console.WriteLine(output);
                    result.Clear();
                    totalResults.Clear();
                }
        }

        public static void FindWords(List<string> words, string input)
        {
            if (impossibleInputs.Contains(input))
            {
                return;
            }
            if (totalResults.Count > 0)
            {
                return;
            }
            if (input == string.Empty)
            {
                totalResults.Add(string.Join(" ", result));
                return;
            }
                foreach (var word in words)
                {
                    if (input.StartsWith(word))
                    {
                        result.Add(word);
                        string restOfString = input.Substring(word.Length);
                        FindWords(words, restOfString);
                        result.Remove(word);
                    }
                }
            impossibleInputs.Add(input);
                //return;
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Extract_Sentances
{
    class ExtractSentenceWithMatchingWord
    {
        static void Main(string[] args)
        {
            // Regex Solution 
            //string pattern = Console.ReadLine();
            //string input = Console.ReadLine();

            //Regex regExPattern = new Regex(string.Format(@"([^.]*?[^a-zA-Z0-9]{0}[^a-zA-Z0-9][^.]*\.)", pattern));

            //var matchCollection = regExPattern.Matches(input);

            //var result = Enumerable.Range(0, matchCollection.Count)
            //                       .Select(index => matchCollection[index].Value)
            //                       .ToList();

            //Console.WriteLine(string.Join("", result));

            // Non-regex Solution 
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string[] sentences = text.Split('.');

            StringBuilder temp = new StringBuilder(); // Is possible with char[]
            StringBuilder result = new StringBuilder();

            foreach (var sentence in sentences)
            {
                temp.Clear();
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (char.IsLetter(sentence[i]) == false)
                    {
                        temp.Append(sentence[i]);
                    }
                }
                char[] splitChars = temp.ToString().ToCharArray();
                string[] words = sentence.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                if (Array.IndexOf(words, word) > -1)
                {
                    result.Append(sentence.Trim());
                    result.Append(". ");
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
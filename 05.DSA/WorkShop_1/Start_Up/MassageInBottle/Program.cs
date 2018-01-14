using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageInBottle
{
    class Program
    {
        public static Dictionary<string, char> dict = new Dictionary<string, char>();
        public static string message = "";
        public static string code = "";
        public static int possibleMessages = 0;
        static int messageIndex = 0;
        static StringBuilder sb = new StringBuilder();
        public static List<string> solutions = new List<string>();

        static void Main()

        {
            message = Console.ReadLine();
            code = Console.ReadLine();
            int endIndex = 0;
            string newSubcode = "";

            for (int i = 0; i < code.Length; i++)
            {
                if (Char.IsLetter(code[i]))
                {
                    endIndex = i;
                    do
                    {
                        endIndex++;
                    } while (!Char.IsLetter(code[endIndex]) && ((endIndex + 1) < code.Length));

                    if (endIndex + 1 < code.Length)
                    {
                        newSubcode = code.Substring(i + 1, endIndex - i - 1);
                    }
                    else
                    {
                        newSubcode = code.Substring(i + 1, endIndex - i);
                    }
                    dict.Add(newSubcode, code[i]);
                }
            }

            FindSequence(messageIndex);
            solutions.Sort();
            Console.WriteLine(solutions.Count);
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }

        }

        public static void FindSequence(int messageIndex)
        {
            if (messageIndex == message.Length)
            {
                solutions.Add(sb.ToString());
                return;
            }
            foreach (var key  in dict)
            {
                if (message.Substring(messageIndex).StartsWith(key.Key))
                {
                    sb.Append(key.Value);
                    FindSequence(messageIndex + key.Key.Length);
                    sb.Length--;
                }
            }
    
        }
    }
}

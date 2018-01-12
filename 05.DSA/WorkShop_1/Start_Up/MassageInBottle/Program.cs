using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageInBottle
{
    class Program
    {
        public static Dictionary<int, char> dict = new Dictionary<int, char>();

        static void Main()
        {
            string message = Console.ReadLine();
            string code = Console.ReadLine();

            int newSubcode = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (Char.IsLetter(code[i]))
                {
                    int endIndex = i;
                    do
                    {
                        endIndex++;
                    } while (Char.IsLetter(code[endIndex]));
                    newSubcode = int.Parse(code.Substring(i + 1, endIndex - 1));
                }
                dict.Add(newSubcode, code[i]);
            }
            
        }

        public static string FindSequence(int index, string message)
        {
            string subMessage = null;
            return subMessage;
        }
    }
}

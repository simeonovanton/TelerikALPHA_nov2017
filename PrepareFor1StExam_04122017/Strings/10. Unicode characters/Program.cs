using System;
using System.Text;

namespace UnicodeCharacters
{
    class ConvertStringToUnicode
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            foreach (char c in inputString)
            {
                sb.AppendFormat("\\u{0:X4}", (uint)c);
            }

            string result = sb.ToString();
            Console.Write(result);
        }
    }
}
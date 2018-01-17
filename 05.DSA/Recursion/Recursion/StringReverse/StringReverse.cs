using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace StringReverse
{
    class StringReverse
    {
        public static void Main(string[] args)
        {
            string s = "Recursion";
            s = RecursivelyReverseString(s);
            Console.WriteLine(s);
        }

        public static string RecursivelyReverseString(string str)
        {
            if (str.Length > 0)
            {
                var newStr = str.Substring(0, str.Length - 1);
                 var res = str[str.Length - 1] + RecursivelyReverseString(newStr);
                return res;
            }
            else
            {
                return str;
            }
        }
    }
}

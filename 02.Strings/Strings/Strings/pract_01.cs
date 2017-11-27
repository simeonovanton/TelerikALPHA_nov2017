using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class pract_01
    {
        static void Main()
        {
            string str1 = "Hello";
            string str2 = "hello";
           

            Console.WriteLine(str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase));

            string text = "Telerik Academy";
            string text1 = "Alpha";

            string space = " ";

            string newText = string.Concat(text, space, text1, space, "Rocks!", space, "Yes, Rocks!");
            Console.WriteLine(newText);
            Console.WriteLine(newText.IndexOf('R'));

            Console.WriteLine("// Splitting");
            text = "Telerik Academy";

            string[] arr = text.Split(' ');

            Console.WriteLine(arr.Length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main()
        {
            List<int> integers = new List<int> { 1, 2, 3, 4, 5 };
            integers.IncreaseWith(5);
            Console.WriteLine(string.Join(", ", integers));
            
        }
    }
}

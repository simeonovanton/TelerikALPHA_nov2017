using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Transfer_7
{
    static int SevenToDecimal(string seven)
    {
        int result = 0;

        foreach (var item in seven)
        {
            result = result * 7 + (item - '0');
        }
        return result;
    }

    static void Main()
    {
        string seven = Console.ReadLine();
        Console.WriteLine(SevenToDecimal(seven));
    }
}


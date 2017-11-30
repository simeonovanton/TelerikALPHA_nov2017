using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        sb.Append(input);
        if (input.Length < 20)
        {
            for (int i = 20 - input.Length; i > 0 ; i--)
            {
                sb.Append('*');
            }
        }
        Console.WriteLine(sb.ToString());
    }
}


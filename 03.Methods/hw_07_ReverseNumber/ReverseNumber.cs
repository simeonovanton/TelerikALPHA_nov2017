using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ReverseNumber
    {
        static string Reverse(string str)
    {
        StringBuilder sb = new StringBuilder();
        for (int index = str.Length - 1; index >= 0; index--)
        {
            sb.Append(str[index]);
        }
        return sb.ToString(); ;
    }
        static void Main()
        {
        string input = Console.ReadLine();
        Console.WriteLine(Reverse(input));
    }
    }


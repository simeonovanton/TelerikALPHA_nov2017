using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Transfer
{
    static int AlphaToDecimal(char[] str)
    {
        int result = 0;
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < str.Length; i++)
        {
            result = result * 26 + alphabet.IndexOf(str[i]);
        }
        return result;
    }
    static void Main()
    {
        char[] alpha = Console.ReadLine().ToCharArray();
        Console.WriteLine(AlphaToDecimal(alpha));
    }
}


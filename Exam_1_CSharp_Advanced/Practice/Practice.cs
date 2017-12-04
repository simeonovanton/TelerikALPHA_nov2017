using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Practice
{
    static void Main(string[] args)
    {
        char[] alpha = Console.ReadLine().ToCharArray();
        char sign = Console.ReadLine()[0];
        string seven = Console.ReadLine();
        int resultDec = 0;

        int alphaDec = AlphaToDecimal(alpha);
        int sevenDec = SevenToDecimal(seven);

        switch (sign)
        {
            case '+': resultDec = alphaDec + sevenDec;
                break;
            case '-': resultDec = alphaDec - sevenDec;
                break;
            default:
                break;
        }

        Console.WriteLine(DecToNineBase(resultDec));
    }

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
    static int SevenToDecimal(string seven)
    {
        int result = 0;

        foreach (var item in seven)
        {
            result = result * 7 + (item - '0');
        }
        return result;
    }
    static int DecToNineBase(int incomResult)
    {
        int result = 0;
        do
        {
            int reminder = incomResult % 9;
            result = result / 9;
            result = reminder + result; ;

           //remainder = number % n;
           //number /= n;
           //result = remainder.ToString() + result;
        } while (incomResult > 0);
        
        return result;
    }
}


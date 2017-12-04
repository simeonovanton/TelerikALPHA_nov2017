using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Transfer_10_to_9_base
{
    static int DecToNineBase(int incomResult)
    {
        int result = 0;
        string text = "" ;
        do
        {
            int reminder = incomResult % 9;
            incomResult = result / 9;
            text = text + reminder;

        } while (incomResult > 0);
        result = int.Parse(text);
        return result;
    }
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(DecToNineBase(num));
    }
}


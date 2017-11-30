using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ExtractSentenses
{
    static void Main()
    {
        string word = Console.ReadLine();
        string str = Console.ReadLine();
        //string str = "0.23.567.9";

        int indexWord = 0;
        int indexDotFirst = 0;
        int indexDotLast = 0;

        while (true)
        {
            if (indexWord == -1)
            {
                break;
            }

            indexWord = str.IndexOf(word, indexWord + 1);

            if (indexWord == -1)
            {
                break;
            }

            indexDotFirst = str.LastIndexOf('.', indexWord);
            if (indexDotFirst == -1)
            {
                indexDotFirst = 0;
            }

            indexDotLast = str.IndexOf('.', indexWord);

            int sentenceLength = indexDotLast - indexDotFirst;
            if (isLetter(str[indexWord - 1]))
            {
                Console.WriteLine(str.Substring(indexDotFirst + 1, sentenceLength));

            }
        }
    }
}

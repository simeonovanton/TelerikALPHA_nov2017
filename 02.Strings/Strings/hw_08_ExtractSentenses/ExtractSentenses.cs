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
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            if (indexWord == -1)
            {
                break;
            }

            indexWord = str.IndexOf(word, indexWord);

            if (indexWord == -1)
            {
                break;
            }
            
            if (!Char.IsLetter(str[indexWord - 1]) && !Char.IsLetter(str[indexWord + word.Length]))
            {
                indexDotFirst = str.LastIndexOf('.', indexWord);

                if (indexDotFirst == -1)
                {
                    indexDotFirst = -1;
                }

                indexDotLast = str.IndexOf('.', indexWord);

                int sentenceLength = indexDotLast - indexDotFirst;

                if (indexDotFirst == -1)
                {
                    sb.Append(str.Substring(indexDotFirst + 1, sentenceLength).Trim());
                }
                else
                {
                    sb.Append(" ");
                    sb.Append(str.Substring(indexDotFirst + 1, sentenceLength).Trim());

                }
                //Console.Write(str.Substring(indexDotFirst + 1, sentenceLength).Trim());

            }
 
            indexWord++;
        }
        Console.WriteLine(sb.ToString());
    }
}

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
        int sentenceLength = 0;

        while (true)
        {
            if (indexWord == -1)
            {
                break;
            }

            indexWord = str.IndexOf(word, indexWord, StringComparison.CurrentCultureIgnoreCase);

            if (indexWord == -1)
            {
                break;
            }
            if (indexWord == 0)
            {
                if (Char.IsLetter(str[indexWord + word.Length]))
                {
                    indexWord++;
                    continue;
                }
            }
            else
            {
                if (Char.IsLetter(str[indexWord - 1]) || Char.IsLetter(str[indexWord + word.Length]))
                {
                    indexWord++;
                    continue;
                }
            }
           
            
            if (indexWord == 0)
            {
                if (!Char.IsLetter(str[indexWord + word.Length]))
                {
                    indexDotFirst = str.LastIndexOf('.', indexWord);

                    indexDotLast = str.IndexOf('.', indexWord);
                    if (indexDotLast == -1)
                    {
                        indexDotLast = str.Length - 1;
                    }

                    if (indexDotFirst == -1)
                    {
                        indexDotFirst = 0;
                        sentenceLength = indexDotLast + 1;
                    }
                    else
                    {
                        sentenceLength = indexDotLast - indexDotFirst;
                    }

                    if (indexDotFirst == 0)
                    {
                        sb.Append(str.Substring(indexDotFirst, sentenceLength));
                    }
                    else
                    {
                        sb.Append(str.Substring(indexDotFirst + 1, sentenceLength));
                    }
                }
            }
            else
            {
                if (!Char.IsLetter(str[indexWord - 1]) && !Char.IsLetter(str[indexWord + word.Length]))
                {
                    indexDotFirst = str.LastIndexOf('.', indexWord);

                    indexDotLast = str.IndexOf('.', indexWord);
                    if (indexDotLast == -1)
                    {
                        indexDotLast = str.Length - 1;
                    }

                    if (indexDotFirst == -1)
                    {
                        indexDotFirst = 0;
                        sentenceLength = indexDotLast + 1;
                    }
                    else
                    {
                        sentenceLength = indexDotLast - indexDotFirst;
                    }

                    if (indexDotFirst == 0)
                    {
                        sb.Append(str.Substring(indexDotFirst, sentenceLength));
                    }
                    else
                    {
                        sb.Append(str.Substring(indexDotFirst + 1, sentenceLength));
                    }
                }
            }
            indexWord++;
        }
        Console.WriteLine(sb.ToString());
    }
}

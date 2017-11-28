using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class hw_05_ParseTags
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string openTag = "<upcase>";
        string closeTag = "</upcase>";
        StringBuilder output = new StringBuilder();
        bool toUpper = false;
        int i = 0;

        while (i < input.Length)
        {
            if (input[i] == '<' && (i + 1 < input.Length && input[i + 1] == 'u'))
            {
                toUpper = true;

                i = UpdatePosition(input, i);
            }

            if (input[i] == '<' && (i + 1 < input.Length && input[i + 1] == '/'))
            {

                toUpper = false;

                i = UpdatePosition(input, i);
                continue;
            }

            if (i < input.Length)
            {
                if (toUpper)
                {
                    output.Append(input[i].ToString().ToUpper());
                }
                else
                {
                    output.Append(input[i].ToString());
                }

                i++;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(output);

    }

    private static int UpdatePosition(string input, int i)
    {
        while (input[i] != '>')
        {
            ++i;
        }
        i++;
        return i;
    }
}


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
        int index = 0;

        //while ((index + openTag.Length) < input.Length && (index + closeTag.Length) < input.Length)
        while (index < input.Length)
        {
            if ((index + openTag.Length) < input.Length )
            {
                if (input.Substring(index, openTag.Length) == openTag)
                {
                    toUpper = true;
                    index += openTag.Length;
                }
            }

            if ((index + closeTag.Length) < input.Length)
            {
                if (input.Substring(index, closeTag.Length) == closeTag)
                {
                    toUpper = false;
                    index += closeTag.Length;
                }
            }
           

            if (toUpper)
            {
                output.Append(Char.ToUpper(input[index]));
            }
            else
            {
                output.Append(input[index]);
            }

            index++;
        }
        Console.WriteLine(output);

    }
}


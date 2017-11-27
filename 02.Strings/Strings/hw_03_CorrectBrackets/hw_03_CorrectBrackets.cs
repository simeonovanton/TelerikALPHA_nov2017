using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class hw_03_CorrectBrackets
{
    static void Main()
    {
        string input = Console.ReadLine();

        //First condition is the opening bracket to be first, and the last bracket to be closing
        int firstOpenBracketPosition = input.IndexOf('(');
        int firstCloseBracketPosition = input.IndexOf(')');
        int lastOpenBracketPosition = input.LastIndexOf('(');
        int lastCloseBracketPosition = input.LastIndexOf(')');

        if (firstOpenBracketPosition < firstCloseBracketPosition && lastOpenBracketPosition < lastCloseBracketPosition)
        {
            // Second condition is: the number of opening and closing brackets to be equal
            int countOpenBracket = 0;
            int countCloseBracket = 0;
            foreach (var item in input)
            {
                if (item == '(')
                {
                    countOpenBracket++;
                }
                if (item == ')')
                {
                    countCloseBracket++;
                }
            }

            if (countOpenBracket == countCloseBracket)
            {
                Console.WriteLine("Correct");
                return;
            }

        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}
//                              ()))((()

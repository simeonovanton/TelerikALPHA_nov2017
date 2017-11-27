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
        int balance = 0;

        int firstOpenBracket = input.IndexOf('(');
        int firstCloseBracket = input.IndexOf(')');
        int lastOpenBracket = input.LastIndexOf('(');
        int lastCloseBracket = input.LastIndexOf(')');

        foreach (var item in input)
        {
            if (item == '(')
            {
                balance++;
            }
            if (item == ')')
            {
                balance--;
            }
            if (balance < 0)
            {
                Console.WriteLine("Incorrect");
                return;
            }
        }

       
        if (firstOpenBracket < firstCloseBracket && lastOpenBracket < lastCloseBracket && balance == 0)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }

    }
}


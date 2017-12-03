using System;

namespace CorrectBrackets
{
    class Brackets
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            int closingBracket = 0;
            int openingBracket = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracket++;
                }
                else if (expression[i] == ')')
                {
                    closingBracket++;
                }
            }

            Console.WriteLine(openingBracket == closingBracket ? "Correct" : "Incorrect");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingBrackets
{
    class Program
    {
        //        Example:

        //    1 + (2 - (2+3) * 4 / (3+1)) * 5

        //Result:

        //    (2+3) | (3+1) | (2-(2+3) * 4 / (3+1))


        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            string input = " 1 + (2 - (2+3) * 4 / (3+1)) * 5";
            input = input.Trim();
            //int openIndex = 0;
            //int closeIndex = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Any())
                    {
                        if (input[i] == ')')
                        {
                            int startIndex = stack.Pop();
                            sb.Append(input.Substring(startIndex, i - startIndex + 1));
                            if (stack.Any())
                            {
                                sb.Append(" | ");
                            }
                        }
                    }
                    else
                    {
                        if (input[i] == ')')
                        {
                            stack.Push(i);
                        }
                    }
                }
            }

            Console.WriteLine(sb.ToString());
            if (stack.Any())
            {
                foreach (var item in stack)
                {
                    Console.WriteLine("( or ) at position:" + item);
                }
            }
        }
    }
}

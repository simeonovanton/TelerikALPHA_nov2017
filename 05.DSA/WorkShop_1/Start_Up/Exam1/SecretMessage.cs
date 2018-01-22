using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    class SecretMessage
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Stack<int> brackets = new Stack<int>();
            Stack<int> digits = new Stack<int>();
            int multiplyDigit = 1;

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    brackets.Push(i);
                }
                else
                {
                        if (input[i] == '}')
                        {
                            int startIndex = brackets.Pop();

                            if (input[startIndex - 1] != -1 && Char.IsDigit(input[startIndex - 1]))
                            {
                                multiplyDigit = input[startIndex - 1] - '0';
                            }

                            for (int j = 0; j < multiplyDigit; j++)
                            {
                                sb.Append(input.Substring(startIndex + 1, i - startIndex - 1));
                            }
                            
                            //if (brackets.Any())
                            //{
                            //    sb.Append(" | ");
                            //}
                        }
                    //input = sb.ToString();
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}

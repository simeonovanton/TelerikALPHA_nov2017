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
            StringBuilder head = new StringBuilder();
            StringBuilder tail = new StringBuilder();
            Stack<int> brackets = new Stack<int>();
            Stack<int> digits = new Stack<int>();
            int multiplyDigit = 1;
            int multiplyNumber = 1;

            string input = Console.ReadLine();
           
            while(!(input.IndexOf('{') != -1) )
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '{' || Char.IsDigit(input[i]))
                    {
                        head.Append(input.Substring(0, i));
                        break;
                    }

                }
                //Console.WriteLine(head.ToString());
                for (int i = input.Length - 1; i > -1; i--)
                {
                    if (input[i] == '}' && i != input.Length - 1)
                    {
                        tail.Append(input.Substring(i + 1, input.Length - 1 - i));
                        break;
                    }
                }
                //Console.WriteLine(tail.ToString());

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
                                multiplyNumber = 0;
                                for (int d = startIndex - 1; d > -1; d--)
                                {
                                    if (Char.IsDigit(input[d]))
                                    {
                                        multiplyNumber = multiplyDigit = input[d] - '0';
                                        if (d - 1 != -1)
                                        {
                                            multiplyNumber = multiplyNumber + multiplyDigit * (int)Math.Pow(10, startIndex - 1 - d);
                                        }
                                    }
                                }
                                //multiplyDigit = input[startIndex - 1] - '0';
                            }

                            for (int j = 0; j < multiplyNumber; j++)
                            {
                                sb.Append(input.Substring(startIndex + 1, i - startIndex - 1));
                            }
                        }
                        //input = sb.ToString();
                    }
                }
               
                input = sb.ToString();
                input = head.ToString() + input + tail.ToString();
            }
            
            Console.WriteLine(input);
        }
    }
}

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
            string input = Console.ReadLine();

            while (input.IndexOf('{') != -1)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder numberSb = new StringBuilder();
                StringBuilder head = new StringBuilder();
                StringBuilder tail = new StringBuilder();
                Stack<int> brackets = new Stack<int>();
                Stack<int> digits = new Stack<int>();
                int startIndex = 0;
                int indexFirstDigit = 0;
                int multiplier = 1;

                for (int i = 0; i < input.Length; i++)
                {
                    //int multiplyDigit = 0;
                    // multiplyNumber = 0;

                    //Finding the multiplying number before the brackets
                    if (char.IsNumber(input[i]))
                    {
                        if (digits.Any() == false)
                        {
                            digits.Push(i);
                         }
                        numberSb.Append(input[i]);
                    }
                    else if (numberSb.ToString().Length > 0)
                    {
                        multiplier = int.Parse(numberSb.ToString());
                        numberSb.Clear();
                        if (digits.Any())
                        {
                            indexFirstDigit = digits.Pop();
                        }
                    }
                    //End finding the multiplying number

                    if (input[i] == '{')
                    {
                        brackets.Push(i);
                    }
                    else
                    {
                        if (input[i] == '}')
                        {
                            startIndex = brackets.Pop();
                            
                            //HEAD
                            head.Append(input.Substring(0, indexFirstDigit));
                            //HEAD

                            //TAIL
                            tail.Append(input.Substring(i + 1));
                            //TAIL

                            //CORE
                            for (int j = 0; j < multiplier; j++)
                            {
                                sb.Append(input.Substring(startIndex + 1, i - startIndex - 1));
                            }
                            //CORE

                            input = sb.ToString();
                            input = head.ToString() + input + tail.ToString();
                            sb.Clear();
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}

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
                StringBuilder head = new StringBuilder();
                StringBuilder tail = new StringBuilder();
                Stack<int> brackets = new Stack<int>();
                Stack<int> digits = new Stack<int>();
                int multiplier = 1;

                for (int i = 0; i < input.Length; i++)
                {
                    int multiplyDigit = 0;
                    int multiplyNumber = 0;

                    //Finding the multiplying number before the brackets
                    if (input[i] > 47 && input[i] < 58)
                    {
                        digits.Push(i);
                        if (i > 0)
                        {
                            int tempigitIndex = digits.Pop();
                            if (Char.IsDigit(input[i - 1]))
                            {
                                continue;
                            }
                            else
                            {
                                digits.Push(tempigitIndex);
                            }
                        }

                        multiplyDigit = input[i] - 48;
                        multiplyNumber = multiplyNumber * 10 + multiplyDigit;
                        int j = i + 1;
                        while (input[j] > 47 && input[j] < 58)
                        {
                            multiplyDigit = input[j] - 48;
                            multiplyNumber = multiplyNumber * 10 + multiplyDigit;
                            j++;
                        }
                        if (multiplyNumber != 0)
                        {
                            multiplier = multiplyNumber;
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
                            int startIndex = brackets.Pop();
                            int indexFirstDigit = digits.Pop();
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
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}

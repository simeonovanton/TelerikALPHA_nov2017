using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    class Passwords
    {
        static void Main()
        {
            int passwordLength = int.Parse(Console.ReadLine());
            string path = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            List<string> results = new List<string>();
            int[] template = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int[] templateMask = { 9, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] resultArr = new int[passwordLength];
            bool[] visitedArr = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                int digit = template[templateMask[i]];
                GetResult(digit, i, resultArr, visitedArr, path);
                if (results.Count >= k)
                {
                    Console.WriteLine(results[k - 1]);
                    break;
                }
            }

            //Recursive method
            void GetResult(int digit, int index, int[] resultArray, bool[] visitedArray, string pathStr)
            {
                if (results.Count >= k)
                {
                    return;
                }
                if (!visitedArray[templateMask[index]])
                {
                    resultArr[index] = digit;
                    if (index == 9)
                    {
                        results.Add(string.Join("", resultArray));
                        return;
                    }
                    if (pathStr[index] == '<')
                    {
                        if (templateMask[index] > 0)
                        {
                            visitedArray[templateMask[index]] = true;
                            digit = template[templateMask[index] - 1];
                            index++;
                            GetResult(digit, index, resultArr, visitedArr, path);
                            index--;
                            visitedArray[templateMask[index]] = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (pathStr[index] == '=')
                    {
                        visitedArray[templateMask[index]] = true;
                        digit = template[templateMask[index]];
                        index++;
                        GetResult(digit, index, resultArr, visitedArr, path);
                        index--;
                        visitedArray[templateMask[index]] = false;
                    }
                    else if (pathStr[index] == '>')
                    {
                        if (templateMask[index] < 9)
                        {
                            visitedArray[templateMask[index]] = true;
                            digit = template[templateMask[index] + 1];
                            index++;
                            GetResult(digit, index, resultArr, visitedArr, path);
                            index--;
                            visitedArray[templateMask[index]] = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

            }
        }
    }
}

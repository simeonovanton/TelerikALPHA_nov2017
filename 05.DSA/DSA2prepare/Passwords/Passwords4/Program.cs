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


            bool[] visitedArr = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                int[] resultArr = new int[passwordLength];
                GetResult(i, resultArr, visitedArr, path);
            }

            //Recursive method
            void GetResult(int index, int[] resultArray, bool[] visitedArray, string pathStr)
            {
                if (results.Count >= k)
                {
                    return;
                }
                if (!visitedArray[templateMask[index]])
                {
                    var test = resultArray.Count();
                    //if (templateMask[index] == 9)
                    //{
                    //    results.Add(string.Join("", resultArray));
                    //    return;
                    //}
                    if (pathStr[index] == '<')
                    {
                        if (templateMask[index] > 0)
                        {
                            resultArray[templateMask[index]] = template[templateMask[index]];
                            visitedArray[templateMask[index]] = true;
                            index++;
                            GetResult(index, resultArray, visitedArr, path);
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
                        resultArray[templateMask[index]] = template[templateMask[index]];
                        visitedArray[templateMask[index]] = true;
                        index++;
                        GetResult(index, resultArray, visitedArr, path);
                        index--;
                        visitedArray[templateMask[index]] = false;
                    }
                    else if (pathStr[index] == '>')
                    {
                        if (templateMask[index] < 9)
                        {
                            resultArray[templateMask[index]] = template[templateMask[index]];
                            visitedArray[templateMask[index]] = true;
                            index++;
                            GetResult(index, resultArray, visitedArr, path);
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

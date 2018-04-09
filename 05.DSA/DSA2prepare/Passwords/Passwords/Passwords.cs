using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    //public class MyPassword : IComparable<MyPassword>
    //{
    //    public string MyPass { get; set; }

    //    public int CompareTo(MyPassword other)
    //    {
    //        return this.MyPass.CompareTo(other.MyPass);
    //    }
    //}

    class Passwords
    {
        static void Main()
        {
            //SortedSet<MyPassword> theSet = new SortedSet<MyPassword>();
            int passwordLength = int.Parse(Console.ReadLine());
            string path = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            List<string> results = new List<string>();
            int[] template = {1,2,3,4,5,6,7,8,9,0};
            int[] templateMask = {9,0,1,2,3,4,5,6,7,8};
            int[] resultArr = new int[passwordLength];
            bool[] visitedArr = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                int index = template[templateMask[i]];
                GetResult(index, resultArr, visitedArr);
                if (results.Count == k)
                {
                    Console.WriteLine(results[k - 1]);
                    break;
                }
            }

            void GetResult(int index, int[] resultArray, bool[] visitedArray)
            {
                if (index >= passwordLength)
                {
                    results.Add(string.Join("",resultArray));
                }
                else if (results.Any())
                {
                    if (results.Count == k)
                    {
                        Console.WriteLine(results[k - 1]);
                        return;
                    }
                }
                else if (!visitedArray[index])
                {
                    //for (int i = 0; i < 10; i++)
                    //{
                        visitedArray[index] = true;
                        resultArray[index] = index;
                    if (index >= 9)
                    {
                        index = 10;
                        GetResult(index, resultArr, visitedArr);
                        return;
                    }
                        //switch <, =, >
                        switch (path[index])
                        {
                            case '<':   GetResult(index - 1, resultArr, visitedArr);
                                        break;
                            case '=':   GetResult(index, resultArr, visitedArr);
                                break;
                            case '>':   GetResult(index + 1, resultArr, visitedArr);
                                break;
                            default:
                                break;
                        }
                        
                        visitedArray[index] = false;
                    //}
                }
            }
        }
    }
}

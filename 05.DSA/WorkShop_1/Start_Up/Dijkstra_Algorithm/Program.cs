using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Dejkstra
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("file.in");
            StreamWriter sw = new StreamWriter("file.out");

            int n;
            String s;
            int.TryParse(sr.ReadLine(), out n);
            int[,] g = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                s = sr.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    var allNums = Regex.Matches(@s, @"\d+");
                    g[i, j] = int.Parse(allNums[j].Value);
                }
            }
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
                d[i] = 200000;
            d[0] = 0;

            bool[] mark = new bool[n];
            for (int i = 0; i < n; i++)
                mark[i] = false;

            int min = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!mark[j] && d[j] < d[min])
                    {
                        min = j;
                    }
                }
                mark[min] = true;
                sw.WriteLine((i + 1) + ")y = x" + (min + 1) + ";");
                for (int j = 0; j < n; j++)
                {
                    if (!mark[j])
                    {
                        if ((d[min] + g[min, j]) < d[j])
                        {
                            sw.WriteLine("d(x" + (j + 1) + ") = min{" + inf(d[j]) + ", " + inf(d[min]) + "+" + inf(g[min, j]) + "} = " + (d[min] + g[min, j]) + ";");
                            d[j] = d[min] + g[min, j];
                        }
                        else
                            sw.WriteLine("d(x" + (j + 1) + ") = min{" + inf(d[j]) + ", " + inf(d[min]) + "+" + inf(g[min, j]) + "} = " + inf(d[j]) + ";");
                    }
                }
                for (int k = min; k < n; k++)
                    if (!mark[k]) min = k;
            }
            //for (int i = 0; i < n; i++)
            //sw.WriteLine(d[i]);

            sw.WriteLine("The shortest path: " + d[d.Length - 1]);

            sw.Close();
        }
        private static String inf(int i)
        {
            String s;
            if (i == 200000)
                s = "b";
            else
                s = i.ToString();
            return s;
        }
    }
}

using System;
using System.Text;
using System.Diagnostics;


class pract_02
{
    static void Main()
    {
        int count = 10000;
        string str = string.Empty;
        StringBuilder strBuilder = new StringBuilder();
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < count; i++)
        {
            str += i;
        }
        sw.Stop();
        Console.WriteLine($"String concatenate: {sw.ElapsedMilliseconds}");

        sw.Reset();
        sw.Start();
        for (int i = 0; i < count; i++)
        {
            strBuilder.Append(i);
        }
        sw.Stop();
        Console.WriteLine($"StringBuilder append: {sw.ElapsedMilliseconds}");

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Task_2
    {
        static void Main()
        {
            int b1 = int.Parse(Console.ReadLine());
            int b2 = int.Parse(Console.ReadLine());
            int b3 = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            int ll = 0;
            for (int i = 1; i <= l; i++)
            {
                ll += i;
            }

            long[] b = new long[ll];
            b[0] = b1;
            b[1] = b2;
            b[2] = b3;

            for (int i = 3; i < ll; i++)
            {
                b[i] = b[i - 1] + b[i - 2] + b[i - 3];
            }

            int counter = 0;
            for (int i = 1; i <= l; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    if (k < i)
                    {
                        Console.Write("{0} ", b[counter]);
                        counter++;
                    }
                    else
                    {
                        Console.Write("{0}", b[counter]);
                        counter++;
                    }

                }
                Console.WriteLine();
            }
        }
    }
}

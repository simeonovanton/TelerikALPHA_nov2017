﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Singelton x = Singelton.Instance;
            Singelton y = Singelton.Instance;

            Console.WriteLine(x == y);


        }
    }
}

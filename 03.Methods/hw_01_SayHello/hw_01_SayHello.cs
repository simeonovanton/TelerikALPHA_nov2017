using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_01_SayHello
{
    class hw_01_SayHello
    {
        static string AskName()
        {
            return Console.ReadLine();
        }

        static void PrintName(string name)
        {
            Console.WriteLine("Hello," + " " + name + "!");
        }

        static void Main(string[] args)
        {
            PrintName(AskName());
        }
    }
}

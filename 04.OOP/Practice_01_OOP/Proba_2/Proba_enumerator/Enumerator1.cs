using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba_enumerator
{
    public enum DaysOfWeek
    {
        Mon = 1, Tue, Wen, Thu, Fri, Sat, Sun
    }
    public class Program
    {
        static void Main()
        {
            DaysOfWeek day = DaysOfWeek.Mon;
            Console.WriteLine(day +" " + (int)DaysOfWeek.Mon);
            Console.WriteLine("===================");
            for (int i = 1; i <= 7; i++)
            {
                Console.WriteLine((DaysOfWeek)i + " " + (int)(DaysOfWeek)i);
                Console.WriteLine((DaysOfWeek)7);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_13_1
{
    class Task_13_1
    {
        static void Main()
        {
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            
            string[] months = new string[] {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};

            month -= 1;
            day -= 1;
            if (day == 0)
            {
                day = 31;
            }

            Console.WriteLine("{0}-{1}-{2}", day, months[month], year);

        }
    }
}

using dbDemos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbDemos.Client
{
    public class Program
    {
        static void Main()
        {
            using (var ctx = new TelerikAcademyContext())
            {
                Console.WriteLine(ctx.Addresses.Count());

                var sb = new StringBuilder();
                foreach (var address in ctx.Addresses)
                {
                    sb.Clear();
                    sb.AppendLine("===================");
                    //Console.WriteLine(address.AddressID);
                    sb.AppendLine(address.Town.Name);
                    sb.AppendLine(address.AddressText);
                    sb.AppendLine("Employees count: " + address.Employees.Count.ToString());
                    sb.AppendLine("Town ID: " + address.TownID.ToString());
                    Console.WriteLine(sb);
                }
            }
        }
    }
}

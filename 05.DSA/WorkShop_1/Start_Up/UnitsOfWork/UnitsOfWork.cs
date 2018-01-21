using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitsOfWork
{
    class UnitsOfWork
    {
        public class Unit
        {
            public Unit()
            {

            }
            public string Name  { get; set; }
            public string Type  { get; set; }
            public int Attack  { get; set; }

        }
        static void Main()
        {
            SortedDictionary<string, Unit> dictionary = new SortedDictionary<string, Unit>();
           // SortedSet<Unit> sortedSet = new SortedSet<Unit>();
           
        }
    }
}

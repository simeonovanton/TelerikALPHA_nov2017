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
        private static SortedDictionary<string, Unit> dictionary = new SortedDictionary<string, Unit>();
        private static string[] command;

        private class Unit
        {
            public Unit(string name, string type, int attack)
            {
                this.Name = name;
                this.Type = type;
                this.Attack = attack;
            }
            public string Name  { get; set; }
            public string Type  { get; set; }
            public int Attack  { get; set; }
        }

        static void Main()
        {
            command = Console.ReadLine().Trim().Split().ToArray();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        break;
                    case "remove":
                        break;
                    case "find":
                        break;
                    case "power":
                        break;
                    default:
                        break;
                }
            }
           
        }

        private static void AddUnit()
        {
            Unit unitToAdd = new Unit(command[1], command[2], int.Parse(command[3]));
        }
    }
}

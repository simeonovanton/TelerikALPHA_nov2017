using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitsOfWork
{
    public class UnitsOfWork
    {
        public static Dictionary<string, Unit> dictionaryOfUnits = new Dictionary<string, Unit>();
        public static Dictionary<string, SortedSet<Unit>> unitByType = new Dictionary<string, SortedSet<Unit>>();
        public static SortedSet<Unit> unitByAttack = new SortedSet<Unit>();
        public static string[] command;
        public static StringBuilder resultBuilder = new StringBuilder();

        public class Unit : IComparable<Unit>
        {
            public Unit(string name, string type, int attack)
            {
                this.Name = name;
                this.Type = type;
                this.Attack = attack;
            }
            public string Name { get; set; }
            public string Type { get; set; }
            public int Attack { get; set; }

            public int CompareTo(Unit other)
            {
                if (this.Attack == other.Attack)
                {
                    return this.Name.CompareTo(other.Name);
                }
                else
                {
                    return this.Attack.CompareTo(other.Attack) * -1;
                }
            }

            public override string ToString()
            {
                return $"{this.Name}[{this.Type}]({this.Attack})";
            }
        }

        static void Main()
        {
            string commands;

            while ((commands = Console.ReadLine()) != "end")
            {
                string[] command = commands.Trim().Split().ToArray();
                switch (command[0])
                {
                    case "add":
                        AddUnit(command); break;
                    case "remove":
                        RemoveUnit(command); break;
                    case "find":
                        FindByType(command); break;
                    case "power":
                        Power(command); break;
                    default:
                        break;
                }
            }
            Console.WriteLine(resultBuilder.ToString());
        }

        public static void AddUnit(string[] command)
        {
            var unitToAdd = new Unit(command[1], command[2], int.Parse(command[3]));
            if (dictionaryOfUnits.ContainsKey(unitToAdd.Name))
            {
                resultBuilder.AppendLine($"FAIL: {unitToAdd.Name} already exists!");
            }
            else
            {
                if (!unitByType.ContainsKey(command[2]))
                {
                    unitByType.Add(command[2], new SortedSet<Unit>());
                }
                //TODO check 10 !!!!!
                if (unitByType[command[2]].Count == 10)
                {
                    if (unitByType[command[2]].Last().CompareTo(unitToAdd) == -1)
                    {
                        unitByType[command[2]].Remove(unitByType[command[2]].Last());
                        unitByType[command[2]].Add(unitToAdd);
                    }
                }
                unitByType[command[2]].Add(unitToAdd);
                dictionaryOfUnits.Add(unitToAdd.Name, unitToAdd);
                unitByAttack.Add(unitToAdd);
                resultBuilder.AppendLine($"SUCCESS: {unitToAdd.Name} added!");
            }
        }

        public static void RemoveUnit(string[] command)
            {
                if (dictionaryOfUnits.ContainsKey(command[1]))
                {
                    Unit unitToRemove = dictionaryOfUnits[command[1]];
                    unitByType[unitToRemove.Type].Remove(unitToRemove);
                    unitByAttack.Remove(unitToRemove);
                    dictionaryOfUnits.Remove(command[1]);
                    resultBuilder.AppendLine($"SUCCESS: {command[1]} removed!");
                }
                else
                {
                    resultBuilder.AppendLine($"FAIL: {command[1]} could not be found!");
                }
            }

            public static void FindByType(string[] command)
            {
                if (unitByType.ContainsKey(command[1]))
                {
                    resultBuilder.AppendLine(string.Format("RESULT: {0}", string.Join(", ", unitByType[command[1]].Take(10))));
                }
                else
                {
                    resultBuilder.AppendLine("RESULT: ");
                }

            }

            public static void Power(string[] command)
            {
                int number = int.Parse(command[1]);
                resultBuilder.AppendLine(string.Format("RESULT: {0}", string.Join(", ", unitByAttack.Take(number))));
            }
        }
    }

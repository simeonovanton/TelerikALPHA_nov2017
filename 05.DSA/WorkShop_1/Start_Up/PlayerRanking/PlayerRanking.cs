using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class PlayerRanking
    {
        public static BigList<Player> playerRankList = new BigList<Player>();
        public static Dictionary<string, OrderedSet<Player>> playersByType = new Dictionary<string, OrderedSet<Player>>();

        static void Main()
        {
            string command = null;
            while ((command = Console.ReadLine()) != "end")
            {
                var commandAsArr = command.Split().ToArray();
                var firstComm = commandAsArr[0];
                switch (firstComm)
                {
                    case "add":
                        string name = commandAsArr[1];
                        string type = commandAsArr[2];
                        int age = int.Parse(commandAsArr[3]);
                        int position = int.Parse(commandAsArr[4]);
                        Player player = new Player(name, type, age, position);

                        if (playersByType.ContainsKey(type))
                        {
                            if (playersByType[type].Count == 5)
                            {
                                Player lastPlayer = playersByType[type][4];
                                if (lastPlayer.CompareTo(player) < 0)
                                {
                                    playersByType[type].RemoveLast();
                                    playersByType[type].Add(player);
                                }
                            }
                        }
                        else
                        {
                            //make dict
                            playersByType[type] = new OrderedSet<Player>();
                            playersByType[type].Add(player);
                        }
                      
                            playerRankList.Insert(position - 1, player);
                        Console.WriteLine(player.ToString());
                        break;

                    case "find": break;
                    case "ranklist": break;
                    default:
                        break;
                }
            }
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }

        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public int CompareTo(Player other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Age.CompareTo(other.Age) * -1;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        public override string ToString()
        {
            return string.Format($"Added player {this.Name} to position {this.Position}");
        }
    }
}

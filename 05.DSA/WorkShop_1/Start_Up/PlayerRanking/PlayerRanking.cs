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
            try
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
                                    if (lastPlayer.CompareTo(player) > 0)
                                    {
                                        playersByType[type].Remove(lastPlayer);
                                        playersByType[type].Add(player);
                                    }
                                }
                                else
                                {
                                    playersByType[type].Add(player);
                                }
                            }
                            else
                            {
                                playersByType[type] = new OrderedSet<Player>();
                                playersByType[type].Add(player);
                            }

                            playerRankList.Insert(position - 1, player);
                            Console.WriteLine(player);
                            break;

                        case "find":
                            string typeSearch = string.Empty;
                            typeSearch = commandAsArr[1];
                            if (playersByType.ContainsKey(typeSearch) && playersByType[typeSearch].Count > 0)
                            {
                                var sb1 = new StringBuilder();
                                sb1.Append($"Type {typeSearch}: ");

                                foreach (var item in playersByType[typeSearch])
                                {
                                    sb1.Append($"{item.Name}({item.Age}); ");

                                }
                                string output1 = (sb1.Remove(sb1.Length - 2, 2)).ToString();
                                Console.WriteLine(output1);
                            }
                            else
                            {
                                Console.WriteLine($"Type {typeSearch}: ");
                            }
                            break;
                        case "ranklist":
                            int startRank = int.Parse(commandAsArr[1]);
                            int endRank = int.Parse(commandAsArr[2]);
                            var sb = new StringBuilder();
                            int rank = startRank;
                            foreach (var item in playerRankList.Range(startRank - 1, endRank))
                            {
                                sb.Append($"{rank}. {item.Name}({item.Age}); ");
                                rank++;
                            }
                           //for (int i = startRank - 1; i < endRank; i++)
                           //{
                           //    sb.Append($"{i + 1}. {playerRankList[i].Name}({playerRankList[i].Age}); ");
                           //}

                            string output = (sb.Remove(sb.Length - 2, 2)).ToString();
                            Console.WriteLine(output);

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }

    public class Player : IComparable
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
        
        public override string ToString()
        {
            return string.Format($"Added player {this.Name} to position {this.Position}");
        } 

        public int CompareTo(object obj)
        {
            var other = obj as Player;
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Age.CompareTo(other.Age) * -1;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }
    }
}

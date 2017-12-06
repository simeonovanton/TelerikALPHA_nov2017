using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPoter_4D
{
    class HarryPotter_4D
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = dimensions[0];
            int b = dimensions[1];
            int c = dimensions[2];
            int d = dimensions[3];

            string[,,,] cubeLike = new string[a, b, c, d];
            //Read HP Coordinates
            int[] hpCoord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            cubeLike[hpCoord[0], hpCoord[1], hpCoord[2], hpCoord[3]] = "@";

            List<string[]> basiilisks = new List<string[]>();
            int s = int.Parse(Console.ReadLine());
            for (int i = 0; i < s; i++)
            {
                // Input of basilisks names and positions
                string[] inputBasilisk = Console.ReadLine().Split(' ').ToArray();
                //Keep record of basilisk's name and positions
                basiilisks[i] = inputBasilisk;
                cubeLike[int.Parse(inputBasilisk[1]), int.Parse(inputBasilisk[2]),
                    int.Parse(inputBasilisk[3]), int.Parse(inputBasilisk[4])] = inputBasilisk[0];
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                int deltaCurrCoord = int.Parse(command[2]);
                foreach (var item in basiilisks)
                {
                    if (command[0] == item[0])
                    {
                        switch (command[1])
                        {
                            case "A":   item[0] = "0"; // TODO
                                break;
                            case "B":
                                break;
                            case "C":
                                break;
                            case "D":
                                break;
                            default:
                                break;
                        }
                    }
                }

            }

        }
    }
}

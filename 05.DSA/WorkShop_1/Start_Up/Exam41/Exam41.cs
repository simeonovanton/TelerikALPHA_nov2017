using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Exam4
{
    public class Node : IComparable
    {
        public int Value { get; set; }
        public List<int> Children { get; set; }
        public int parentsCount;
        public bool isVisited { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Node;
            return this.Value.CompareTo(other.Value);
        }

    }
    class DogsPaper
    {
        public static OrderedDictionary<int, Node> nodes = new OrderedDictionary<int, Node>();
        
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                Node parent = new Node();
                Node child = new Node();
                switch (command[2])
                {
                    case "before":
                        parent.Value = int.Parse(command[0]);
                        child.Value = int.Parse(command[3]);
                        break;
                    case "after":
                        child.Value = int.Parse(command[0]);
                        parent.Value = int.Parse(command[3]);
                        break;
                    default:
                        break;
                }

                if (!nodes.ContainsKey(parent.Value))
                {
                    nodes.Add(parent.Value, new Node());
                    nodes[parent.Value].Value = parent.Value;
                    nodes[parent.Value].Children = new List<int>();
                    nodes[parent.Value].Children.Add(child.Value);
                    if (!nodes.ContainsKey(child.Value))
                    {
                        nodes[child.Value] = new Node();
                    }
                    nodes[child.Value].Value = child.Value;
                    nodes[child.Value].parentsCount++;
                }
                else
                {
                    if (nodes[parent.Value].Children == null)
                    {
                        nodes[parent.Value].Children = new List<int>();
                    }
                    if (!nodes[parent.Value].Children.Contains(child.Value))
                    {
                        nodes[parent.Value].Children.Add(child.Value);
                        if (!nodes.ContainsKey(child.Value))
                        {
                            nodes[child.Value] = new Node();
                        }
                        nodes[child.Value].Value = child.Value;
                        nodes[child.Value].parentsCount++;
                    }
                }   
                    
            }
            int counter = 0;
            while (counter != nodes.Count)
            {
                foreach (KeyValuePair<int, Node> node in nodes)
                {
                    if (node.Value.parentsCount == 0 && node.Value.isVisited == false)
                    {
                        if (node.Value.Value == 0 && counter == 0)
                        {
                            continue;
                        }
                        Console.Write(node.Value.Value);
                        node.Value.isVisited = true;
                        counter++;
                        if (node.Value.Children != null)
                        {
                            foreach (var child in node.Value.Children)
                            {
                                nodes[child].parentsCount--;
                            }
                        }
                        break;
                    }
                }
            }

            Console.WriteLine();

        }
    }
}

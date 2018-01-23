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

            List<int> results = new List<int>();
            foreach (var nodee in nodes)
            {
                int counter = 0;
                StringBuilder sb = new StringBuilder();
                if (nodee.Value.parentsCount == 0)
                {
                    nodee.Value.isVisited = true;
                    sb.Append(nodee.Value.Value);
                    counter++;
                    if (nodee.Value.Children != null)
                    {
                        foreach (var child in nodee.Value.Children)
                        {
                            nodes[child].parentsCount--;
                        }
                    }
                }
                
                while (counter != nodes.Count)
                {
                    foreach (var node in nodes)
                    {
                        if (node.Value.parentsCount == 0 && node.Value.isVisited == false)
                        {
                            //Console.Write(node.Value.Value);
                            sb.Append(node.Value.Value);
                            node.Value.isVisited = true;
                            counter++;
                            if (node.Value.Children != null)
                            {
                                foreach (var child in node.Value.Children)
                                {
                                    nodes[child].parentsCount--;
                                }
                            }

                        }
                    }
                }
                string output;
                if (sb[0] == '0')
                {
                    output = sb.ToString();
                    output = output.Substring(1);
                }
                else
                {
                    output = sb.ToString();
                }

                int number = int.Parse(output);
                results.Add(number);
                foreach (var nodeee in nodes)
                {
                    nodeee.Value.isVisited = false;
                }
            }


            results.Sort();
            Console.WriteLine(results[0]);

        }
    }
}

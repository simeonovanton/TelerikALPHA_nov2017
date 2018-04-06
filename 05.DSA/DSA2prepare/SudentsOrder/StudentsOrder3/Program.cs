using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOrder
{
    public class Node
    {
        public Node(string value, Node previous, Node next)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }
        public Node Previous { get; set; }
        public Node Next { get; set; }
        public string Value { get; set; }
    }

    class StudentsOrder
    {
        static void Main()
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int studentsNum = input1[0];
            int shiftingNum = input1[1];

            string[] names = Console.ReadLine().Split().ToArray();

            Dictionary<string, Node> dict = new Dictionary<string, Node>();
            dict.Add(names[0], new Node(names[0], null, null));
            for (int i = 1; i < studentsNum; i++)
            {
                Node node = new Node(names[i], dict[names[i - 1]], null);
                dict[names[i - 1]].Next = node;
                dict.Add(names[i], node);
            }

            for (int i = 0; i < shiftingNum; i++)
            {
                string[] shifters = Console.ReadLine().Split().ToArray();
                string shifter1 = shifters[0];
                string shifter2 = shifters[1];
                Node nodeToBeFirst = dict[shifter1];
                Node nodeToBeSecond = dict[shifter2];

                //Excluding nodeToBeFirst from his current position
                if (nodeToBeFirst.Next != null)
                {
                    if (nodeToBeFirst.Previous != null)
                    {
                        nodeToBeFirst.Previous.Next = nodeToBeFirst.Next;
                        nodeToBeFirst.Next.Previous = nodeToBeFirst.Previous; nodeToBeFirst.Next.Previous = nodeToBeFirst.Previous;
                    }
                    else
                    {
                        nodeToBeFirst.Next.Previous = null;
                    }
                }
                else
                {
                    nodeToBeFirst.Previous.Next = null;
                }

                //Including nodeToBeFirst in the new position
                if (nodeToBeSecond.Previous != null)
                {
                    nodeToBeSecond.Previous.Next = nodeToBeFirst;
                    nodeToBeFirst.Previous = nodeToBeSecond.Previous;
                }
                else
                {
                    nodeToBeFirst.Previous = null;
                }
                nodeToBeFirst.Next = nodeToBeSecond;
                nodeToBeSecond.Previous = nodeToBeFirst;
            }

            var firstNode = dict.Where(x => x.Value.Previous == null).FirstOrDefault().Value;
            while (firstNode.Next != null)
            {
                Console.Write($"{firstNode.Value} ");
                firstNode = firstNode.Next;
            }
            Console.Write($"{firstNode.Value}");
            Console.WriteLine();
        }
    }
}

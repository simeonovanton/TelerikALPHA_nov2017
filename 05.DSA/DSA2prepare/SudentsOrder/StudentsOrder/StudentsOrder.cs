using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOrder
{
    public class Node<T>
    {
        public Node(string value , Node<T> previous, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
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

            Dictionary<string, Node<string>> dict = new Dictionary<string, Node<string>>(); 

            for (int i = 0; i < studentsNum; i++)
            {
                Node<string> node = new Node<string>(names[i], null, null);

                if (i == 0)
                {
                    node.Previous = null;
                }
                if (i == studentsNum - 1)
                {
                    node.Next = null;
                }
                dict.Add(names[i], node);
                var oldNode = node;
            }

            for (int i = 0; i < shiftingNum; i++)
            {
                string[] shifters = Console.ReadLine().Split().ToArray();
                string shifter1 = shifters[0];
                string shifter2 = shifters[1];

                //Node<string> nodeToBeFirst = dict[shifter1];
                //Node<string> nodeToBeSecond = dict[shifter2];

                //var leftNodeToBeSecond = nodeToBeSecond.Previous;
                //var rightNodeToBeSecond = nodeToBeSecond.Next;
                //var leftNodeToBeFirst = nodeToBeFirst.Previous;
                //var rightNodeToBeFirst = nodeToBeFirst.Next;

                //if (nodeToBeFirst.Next == nodeToBeSecond && nodeToBeSecond.Previous == nodeToBeFirst)
                //{
                //    break;
                //}
                //nodeToBeFirst.Next = nodeToBeSecond;
                //nodeToBeFirst.Previous = nodeToBeSecond.Previous;
                //leftNodeToBeSecond.Next = nodeToBeFirst;
                //nodeToBeSecond.Previous = nodeToBeFirst;

                //leftNodeToBeFirst.Next = rightNodeToBeFirst;
                //rightNodeToBeFirst.Previous = leftNodeToBeFirst;
            }

            var first = dict.Where(x => x.Value.Previous == null).FirstOrDefault();
            Node<string> firstNode = first.Value;
            var list = new List<string>();
            while (firstNode.Next != null)
            {
                list.Add(firstNode.Value);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}

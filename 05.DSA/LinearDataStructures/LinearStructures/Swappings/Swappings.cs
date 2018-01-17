using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Swappings

{

    class Node : IEnumerable<int>

    {

        public Node(int val)

        {

            this.Value = val;

            this.Left = null;

            this.Right = null;

        }

        public int Value { get; }

        public Node Right { get; private set; }

        public Node Left { get; private set; }

        public void Connect(Node node)

        {

            if (node != null)

            {

                this.Right = node;
                node.Left = this;

            }

            //if (this != null)

            //{



            //}

        }

        public void Disconnect()

        {

            if (this.Right != null)

            {

                this.Right.Left = null;

            }

            if (this.Left != null)

            {

                this.Left.Right = null;

            }

            this.Right = null;

            this.Left = null;

        }

        public IEnumerator<int> GetEnumerator()

        {

            var node = this;

            while (node != null)

            {

                yield return node.Value;

                node = node.Right;

            }

        }

        IEnumerator IEnumerable.GetEnumerator()

        {

            return GetEnumerator();

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            int n = int.Parse(Console.ReadLine());

            var swappingNums = Console.ReadLine()

                .Split().Select(x => int.Parse(x)).ToArray();

            var nodes = Enumerable.Range(0, n + 1)

                .Select(x => new Node(x)).ToArray();

            //List<Node> nodess = new List<Node>();

            //for (int i = 1; i <= n; i++)
            //{
            //    nodess.Add(new Node(i));
            //}

            for (int i = 1; i < n; i++)

            {

                nodes[i].Connect(nodes[i + 1]);

            }

            var head = nodes[1];

            var tail = nodes[n];

            for (int i = 0; i < swappingNums.Length; i++)

            {

                var num = swappingNums[i];

                var newHead = nodes[num].Right;

                var newTail = nodes[num].Left;

                nodes[num].Disconnect();

                if (tail != nodes[num])

                {

                    tail.Connect(nodes[num]);

                }

                else

                {

                    newHead = nodes[num];

                }

                if (head != nodes[num])

                {

                    nodes[num].Connect(head);

                }

                else

                {

                    newTail = nodes[num];

                }

                head = newHead;

                tail = newTail;

            }



            Console.WriteLine(string.Join(" ", head));



        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swappings
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());
            int[] nums = Console.ReadLine().Split(new char[] { ' ' }).Select(Int32.Parse).ToArray();

            Dictionary<int, ListNode> dictionary = new Dictionary<int, ListNode>();

            ListNode first = new ListNode(1);
            first.Previous = null;

            //First Way Of NodesCreating
            //ListNode currentNode = first;
            //dictionary.Add(currentNode.Value, currentNode);

            ListNode last = new ListNode(N);
            last.Next = null;

            dictionary.Add(1, first);
            dictionary.Add(N, last);

            ListNode currentNode;
            ListNode previousNode;
            for (int i = 2; i < N; i++)
            {
                currentNode = new ListNode(i);
                previousNode = dictionary[i - 1];
                previousNode.Next = currentNode;
                currentNode.Previous = previousNode;
                dictionary.Add(i, currentNode);
                //First Way Of NodesCreating
                //currentNode.Next = new ListNode(i);
                //currentNode.Next.Previous = currentNode;
                //currentNode = currentNode.Next;
                //dictionary.Add(currentNode.Value, currentNode);
            }
            dictionary[N - 1].Next = last;
            last.Previous = dictionary[N - 1];

            //First Way Of NodesCreating
            //currentNode.Next = last;
            //currentNode.Next.Previous = currentNode;
            //currentNode = currentNode.Next;
            //dictionary.Add(currentNode.Value, currentNode);

            for (int i = 0; i < nums.Length; i++)
            {
                int currentBorder = nums[i];
                ListNode currentBorderNode = dictionary[currentBorder];
                if (currentBorderNode != first && currentBorderNode != last)
                {
                    //ListNode newFirst = dictionary[currentBorderNode.Next.Value];
                    //currentBorderNode.Next = first;
                    //first.Previous = currentBorderNode;
                    //ListNode newLast = currentBorderNode.Previous;
                    //newLast.Next = null;
                    //currentBorderNode.Previous.Next = null;

                    //first = newFirst;
                    //first.Previous = null;
                    //last.Next = currentBorderNode;
                    //currentBorderNode.Previous = last;
                    //last = newLast;

                    ListNode newFirst = currentBorderNode.Next;
                    ListNode newLast = currentBorderNode.Previous;

                    currentBorderNode.Previous.Next = null;
                    currentBorderNode.Next.Previous = null;

                    currentBorderNode.Previous = last;
                    last.Next = currentBorderNode;
                    currentBorderNode.Next = first;
                    first.Previous = currentBorderNode;

                    first = newFirst;
                    last = newLast;
                    first.Previous = null;
                    last.Next = null;
                }
                else if (currentBorderNode == first)
                {
                    ListNode newFirst = first.Next;
                    first.Previous = last;
                    last.Next = first;
                    last = last.Next;
                    last.Next = null;
                    first = newFirst;
                    first.Previous = null;
                }
                else if (currentBorderNode == last)
                {
                    ListNode newLast = last.Previous;
                    last.Next = first;
                    first.Previous = last;
                    first = first.Previous;
                    first.Previous = null;
                    last = newLast;
                    last.Next = null;
                }
            }

            ListNode curNode = first;
            if (curNode != null)
            {
                Console.Write(curNode.Value);
                curNode = curNode.Next;
            }
            for (; curNode != null;)
            {
                Console.Write(" " + curNode.Value);
                curNode = curNode.Next;
            }
            Console.WriteLine();
        }
    }

    class ListNode
    {
        private int value;
        private ListNode next;
        private ListNode previous;

        public ListNode(int value)
        {
            this.Value = value;
        }

        public int Value { get { return this.value; } set { this.value = value; } }
        public ListNode Next { get { return this.next; } set { this.next = value; } }
        public ListNode Previous { get { return this.previous; } set { this.previous = value; } }
    }
}
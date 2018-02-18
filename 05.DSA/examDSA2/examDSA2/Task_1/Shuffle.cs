using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Shuffle
    {
        static void Main()
        {
            var nAndK = Console.ReadLine().Split();
            int n = int.Parse(nAndK[0]);
            int k = int.Parse(nAndK[1]);
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(new LinkedListNode<int>(1));
            for (int i = 2; i <= n; i++)
            {
                list.AddLast(new LinkedListNode<int>(i));
            }

            int nodeToMove = 0;
            int nodeToGoAfter = 0;
            for (int i = 0; i < k; i++)
            {
                nodeToMove = input[i];
                if (nodeToMove % 2 == 0)
                {
                    nodeToGoAfter = nodeToMove / 2;
                }
                else
                {
                    nodeToGoAfter = nodeToMove * 2;
                }

                if (nodeToMove == nodeToGoAfter)
                {
                    continue;
                }
                list.Remove(nodeToMove);
                LinkedListNode<int> toMove = new LinkedListNode<int>(nodeToMove);
                LinkedListNode<int> toGoAfter = list.Find(nodeToGoAfter);
                list.AddAfter(toGoAfter, nodeToMove);
            }
            foreach (var item in list)
            {
                Console.Write(item);
            }
        }
    }
}

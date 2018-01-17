using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOT WORKING
namespace Swapping_2
{

    public class LinkedListNode
    {

    }

    class Swapping_2
    {
        static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();
            LinkedListNode<int> node = new LinkedListNode<int>(5);

            int n = int.Parse(Console.ReadLine());
            int[] swapNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for(int i = 1; i <= n; i ++)
            {
                list.AddLast(i);
            }

            foreach (var num in swapNums)
            {
                LinkedList<int> newList = new LinkedList<int>();
                LinkedList<int> newRightList = new LinkedList<int>();
                LinkedListNode<int> askedNode = list.Find(num);
               // Identify the first, last, before and after the SELECTED node.
                LinkedListNode<int> lastNode = list.Last;
                LinkedListNode<int> firstNode = list.First;
                LinkedListNode<int> beforeNode = askedNode.Previous;
                LinkedListNode<int> afterNode = askedNode.Next;
                // Removing connections
                //askedNode.Next = null;
            }

        }

       
    }
}

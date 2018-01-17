using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Swapping4_Jokata
{
    public class Swapping4
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var list = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                list.AddLast(i);
            }

            foreach (var command in commands)
            {
                list = ProcessCommand(list, command);
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static LinkedList<int> ProcessCommand(LinkedList<int> list, int command)
        {
            var reorderedList = new LinkedList<int>();
            var swapNode = list.Find(command);
            var next = swapNode.Next;
            Move(list, next, reorderedList);
            list.Remove(swapNode);
            reorderedList.AddLast(swapNode);
            next = list.First;
            Move(list, next, reorderedList);
            return reorderedList;
        }

        // Do you remember C/C++ inline functions/methods? C# has them as well!
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Move(LinkedList<int> source, LinkedListNode<int> node, LinkedList<int> destination)
        {
            while (node != null)
            {
                var newNext = node.Next;
                source.Remove(node);
                destination.AddLast(node);
                node = newNext;
            }
        }
    }
}

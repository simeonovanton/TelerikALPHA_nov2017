
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StudentsOrder
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int studentsNum = input1[0];
            int shiftingNum = input1[1];

            string[] names = Console.ReadLine().Split().ToArray();

            int nodesCount = names.Count();

            LinkedList<string> theList = new LinkedList<string>();
            Dictionary<string, LinkedListNode<string>> dict = new Dictionary<string, LinkedListNode<string>>();
            
            for (int i = 0; i < nodesCount; i++)
            {
                LinkedListNode<string> node = new LinkedListNode<string>(names[i]);
                theList.AddLast(node);
                dict.Add(names[i], node);
            }

            for (int i = 0; i < shiftingNum; i++)
            {
                string[] shifters = Console.ReadLine().Split().ToArray();
                string shifter1 = shifters[0];
                string shifter2 = shifters[1];

                var nodeToBeFirst = dict[shifter1];
                var nodeToAddBefore = dict[shifter2];
                theList.Remove(nodeToBeFirst);
                theList.AddBefore(nodeToAddBefore, nodeToBeFirst);
            }

            var stringArrList = theList.ToArray();
            Console.WriteLine(string.Join(" ", stringArrList));
        }
    }
}


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

            LinkedList<string> theList = new LinkedList<string>();

            for (int i = studentsNum - 1; i >= 0 ; i--)
            {
                theList.AddFirst(names[i]);
            }

            for (int i = 0; i < shiftingNum; i++)
            {
                string[] shifters = Console.ReadLine().Split().ToArray();
                string shifter1 = shifters[0];
                string shifter2 = shifters[1];

                theList.Remove(shifter1);
                var nodeToAddBefore = theList.Find(shifter2);
                theList.AddBefore(nodeToAddBefore, shifter1);
            }

            var stringArrList = theList.ToArray();
            Console.WriteLine(string.Join(" ", stringArrList));
        }
    }
}

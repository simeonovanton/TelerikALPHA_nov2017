using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation2
{
    class JediMeditation2
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var input = (Console.ReadLine().Split().ToArray());

            Queue<string> listM = new Queue<string>();
            Queue<string> listK = new Queue<string>();
            Queue<string> listP = new Queue<string>();

            foreach (var item in input)
            {
                switch (item[0])
                {
                    case 'M': listM.Enqueue(item); break;
                    case 'K': listK.Enqueue(item); break;
                    case 'P': listP.Enqueue(item); break;
                    default:
                        break;
                }
            }
            while (listM.Count > 0)
            {
                Console.Write(listM.Dequeue() + " ");
            }

            while (listK.Count > 0)
            {
                Console.Write(listK.Dequeue() + " ");
            }

            while (listP.Count > 1)
            {
                Console.Write(listP.Dequeue() + " ");
            }
            Console.WriteLine(listP.Dequeue() + " ");

        }
    }
}

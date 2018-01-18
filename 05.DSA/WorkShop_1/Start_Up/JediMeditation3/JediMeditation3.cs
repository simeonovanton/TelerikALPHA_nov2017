using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation3
{
    class JediMeditation3
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
            listM.Concat(listK).Concat(listP);
            Console.WriteLine(string.Join(" ", listM.Concat(listK).Concat(listP)).Trim());
        }
    }
}

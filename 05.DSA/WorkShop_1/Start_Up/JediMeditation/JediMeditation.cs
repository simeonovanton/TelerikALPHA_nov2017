using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace JediMeditation
{
    class JediMeditation
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> input = new List<string>(Console.ReadLine().Split().ToArray());

            List<string> listM = new List<string>();
            List<string> listK = new List<string>();
            List<string> listP = new List<string>();

            foreach (var item in input)
            {
                switch (item[0])
                {
                    case 'M': listM.Add(item); break;
                    case 'K': listK.Add(item); break;
                    case 'P': listP.Add(item); break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < listM.Count; i++)
            {
                Console.Write(listM[i] + " ");
            }
            for (int i = 0; i < listK.Count; i++)
            {
                Console.Write(listK[i] + " ");
            }
            for (int i = 0; i < listP.Count - 1; i++)
            {
                Console.Write(listP[i] + " ");
            }
            Console.WriteLine(listP[listP.Count - 1]);

        }
    }
}

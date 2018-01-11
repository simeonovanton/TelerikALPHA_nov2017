using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddRepeatingSequence
{
    class OddRepaetSequence
    {
        static void Main()
        {
            List<int> input = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> output = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                int counter = 1;
                for (int j = i; j < input.Count; j++)
                {
                    if (input[i] == input[j])
                    {
                        counter++;
                    }
                }
           
                if (counter % 2 == 0 && !output.Contains(input[i]))
                {
                    output.Add(input[i]);
                }
            }

            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i]);
                if (i < output.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            
        }
    }
}

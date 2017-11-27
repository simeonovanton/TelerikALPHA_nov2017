using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_04_SubStringInText
{
    class hw_04_SubStringInText
    {
        static void Main()
        {
            string searchText = Console.ReadLine().ToLower();
            string input = Console.ReadLine().ToLower();
          
            int counter = 0;

            for (int i = 0; i <= input.Length - searchText.Length; i++)
            {
                if (searchText == input.Substring(i, searchText.Length))
                {
                    counter++;
                }
            }
           
            Console.WriteLine(counter);
        }
    }
}

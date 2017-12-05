using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task_1
{
    static void Main()
    {
        string input = Console.ReadLine();
        long result = 0;
        
        for (int i = input.Length - 1, index = 1; i >= 0 ; i--, index ++)
        {
            if (input[i] == '-')
            {
                continue;
            }
            if (index % 2 == 0)
            {
                result += (input[i] - '0') * (input[i] - '0') * index;
            }
            else
            {
                result += (input[i] - '0') * index * index;
            }
        }
      
      
        // Console.WriteLine(result);
      
        int lengthMessage = 0;
        int s = 0;
        int start = 0;

        if (result % 10 == 0)
        {
            Console.WriteLine(result);
            Console.WriteLine("Big Vik wins again!");
            return;
        }
        else
        {
            lengthMessage = (int)result % 10;
            s = (int)result % 26;
            start = s;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lengthMessage; i++)
            {
               // int position = (start + i - 1) % 26;
                int position = (start + i) % 26;
                sb.Append(alphabet[position]);
            }
            Console.WriteLine(result);
            Console.WriteLine(sb.ToString().ToUpper());
            return;
        }
        
    }
}

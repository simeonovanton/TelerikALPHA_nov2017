using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task_1_new_solution
{
    static void Main()
    {
        string input = Console.ReadLine();
        int inputLength = input.Length;
        long result = 0;
        
        
        if (input[0] == '-')
        {
            for (int i = inputLength - 1,  index = 1; i > 0; i--, index++)
            {
                if (index % 2 == 0)
                {
                    result += index * (input[i] - 48) * (input[i] - 48);
                }
                else
                {
                    result += index * index * (input[i] - 48);
                }
            }
        }
        else
        {
            for (int i = inputLength - 1, index = 1; i >= 0; i--, index++)
            {
                if (index % 2 == 0)
                {
                    result += index * (input[i] - 48) * (input[i] - 48);
                }
                else
                {
                    result += index * index * (input[i] - 48);
                }
            }
        }
        

        //long result = 0;
        //
        //
        //for (int i = 0, index = input.Length; i < input.Length; i++, index--)
        //{
        //    string curr = input[i].ToString();
        //    if (curr == "-")
        //    {
        //        continue;
        //    }
        //    var digit = int.Parse(curr);
        //
        //    if (index % 2 == 0) // even
        //    {
        //        result += (long)Math.Pow(digit, 2) * index;
        //    }
        //    else // odd
        //    {
        //        result += digit * ((long)Math.Pow(index, 2));
        //    }
        //}

        if (result % 10 == 0)
        {
            Console.WriteLine(result);
            Console.WriteLine("Big Vik wins again!");
            return;
        }
        else
        {
            int s = (int)result % 26;
            int start = s;
            //start = s;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < (int)result % 10; i++)
            {
                // int position = (start + i - 1) % 26;
                int position = (start + i) % 26;
                sb.Append(alphabet[position]);
            }
            Console.WriteLine(result);
            Console.WriteLine(sb.ToString().ToUpper());
            return;

        }

        //Console.WriteLine(result);
    }
}


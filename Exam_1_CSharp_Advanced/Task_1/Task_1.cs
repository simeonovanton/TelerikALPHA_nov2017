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
        
        string inputStr = Console.ReadLine();

        int[] input = new int[inputStr.Length];
        for (int i = 0; i < inputStr.Length; i++)
        {
            input[i] = Math.Abs((inputStr[i] - '0'));
        }

        int[] result = new int[input.Length];
        int index = 0;

        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            index = input.Length - i;

            if (index % 2 == 0)
            {
                result[i] = input[i] * input[i] * index;
            }
            else
            {
                result[i] = input[i] * index * index;
            }
        }
        BigInteger resultResult = 0;
        foreach (var item in result)
        {
            resultResult += item;
        }
        // Console.WriteLine(resultResult);
        if (resultResult < 0)
        {
            resultResult *= -1;
        }
        int lengthMessage = 0;
        int s = 0;
        int start = 0;

        if (resultResult % 10 == 0)
        {
            Console.WriteLine(resultResult);
            Console.WriteLine("Big Vik wins again!");
        }
        else
        {
            lengthMessage = (int)resultResult % 10;
            s = (int)resultResult % 26;
            start = s + 1;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lengthMessage; i++)
            {
                int position = (start + i - 1) % 26;
                sb.Append(alphabet[position]);
            }
            Console.WriteLine(resultResult);
            Console.WriteLine(sb.ToString().ToUpper());
        }
        
    }
}

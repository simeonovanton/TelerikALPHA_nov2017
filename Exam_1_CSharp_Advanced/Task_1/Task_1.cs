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
        //BigInteger input1 = BigInteger.Parse(Console.ReadLine());
        //List<int> input2 = new List<int>();
        //if (input1 < 0)
        //{
        //    input1 *= -1;
        //}
        //
        //do
        //{
        //    input2.Add((int)input1 % 10);
        //    input1 = input1 / 10;
        //} while (input1 > 0);

        //int[] input = new int[input2.Count];
        //for (int i = input2.Count - 1; i >= 0; i--)
        //{
        //    input[input2.Count - i - 1] = input2[i];
        //}
       //int[] input = new int[inputStr.Length];
       //for (int i = 0; i < inputStr.Length; i++)
       //{
       //    input[i] = Math.Abs((inputStr[i] - '0'));
       //}

        int[] result = new int[input.Length];
        int index = 0;

        for (int i = result.Length - 1; i >= 0 ; i--)
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
      
        int lengthMessage = 0;
        int s = 0;
        int start = 0;

        if (resultResult % 10 == 0)
        {
            Console.WriteLine(resultResult);
            Console.WriteLine("Big Vik wins again!");
            return;
        }
        else
        {
            lengthMessage = (int)resultResult % 10;
            s = (int)resultResult % 26;
            start = s;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lengthMessage; i++)
            {
               // int position = (start + i - 1) % 26;
                int position = (start + i) % 26;
                sb.Append(alphabet[position]);
            }
            Console.WriteLine(resultResult);
            Console.WriteLine(sb.ToString().ToUpper());
            return;
        }
        
    }
}

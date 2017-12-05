using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine();
        decimal result = 0;

        
        for (int i = 0, index = input.Length; i < input.Length; i++, index--)
        {
            string curr = input[i].ToString();
            if(curr == "-")
            {
                continue;
            }
            var digit = int.Parse(curr);

            if (index % 2 == 0) // even
            {
                result += (decimal)Math.Pow(digit, 2) * index;
            }
            else // odd
            {
                result += digit * ((decimal)Math.Pow(index, 2));
            }
        }
        
        var sb = new StringBuilder();

        Console.WriteLine(result.ToString("0"));

        if (result.ToString().Last() == '0')
        {
            Console.WriteLine("Big Vik wins again!");
        }
        else
        {
            var msgLen = int.Parse(result.ToString().Last().ToString());

            var key = (long)result % 26;


            for (int i = 0; i < msgLen; i++)
            {
                char letter = (char)(65 + (key + i) % 26);

                sb.Append(letter);
            }

        }

        Console.WriteLine(sb.ToString());
    }
}


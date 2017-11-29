using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class nFactorial
{
    static BigInteger CalculateFactorial(int number)
    {
        BigInteger result = 1; ;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFactorial(numberN));
    }
}


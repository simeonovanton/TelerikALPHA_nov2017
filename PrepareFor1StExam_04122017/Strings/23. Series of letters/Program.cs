using System;
using System.Text;

namespace SeriesOfLetters
{
    class LetterSeries
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            StringBuilder resultString = new StringBuilder();
            resultString.Append(inputString[0]);

            if (inputString[0] != inputString[1])
            {
                resultString.Append(inputString[1]);
            }

            for (int i = 1; i < inputString.Length - 1; i++)
            {
                if (inputString[i] != inputString[i + 1])
                {
                    resultString.Append(inputString[i + 1]);
                }
            }

            Console.WriteLine(resultString.ToString());
        }
    }
}

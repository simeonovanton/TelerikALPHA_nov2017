using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task_2
{
    static void Main()
    {
        int startPoint = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine().Split(',').Select(long.Parse).ToArray();
        string input;
        long sumForward = 0;
        long sumBackwards = 0;
        int position = 0;

        do
        {
            input = Console.ReadLine();
            if (input == "exit")
            {
                break;
            }
            string[] inputArr = input.Split(' ').ToArray();
            int times = int.Parse(inputArr[0]);
            string direction = inputArr[1];
            int size = int.Parse(inputArr[2]);
            
            switch (direction)
            {
                case "forward":
                    for (int i = 0; i < times; i++)
                    {
                        position = (startPoint + size) % array.Length;
                        sumForward += array[position];
                        startPoint = position;
                    }
                    break;

                case "backwards":
                    for (int i = 0; i < times; i++)
                    {
                        position = (array.Length + startPoint - size) % array.Length;
                        sumBackwards += array[position];
                        startPoint = position;
                    }
                    break;

                default:
                    break;
            }

        } while (true);

        Console.WriteLine("Forward: {0}", sumForward);
        Console.WriteLine("Backwards: {0}", sumBackwards);
    }
}


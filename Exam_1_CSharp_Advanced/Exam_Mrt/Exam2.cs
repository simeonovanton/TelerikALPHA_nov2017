using System;
using System.Linq;

class Program
{
    private const string dirForward = "forward";
    private const string dirBackwards = "backwards";

    static void Main()
    {
        var pos = int.Parse(Console.ReadLine());
        var arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

        var sumForward = 0;
        var sumBackwards = 0;

        while (true)
        {

            var command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }

            // get params
            var commandParts = command.Split(' ');
            var steps = int.Parse(commandParts[0]);
            var dir = commandParts[1];
            var size = int.Parse(commandParts[2]);

            // move and collect
            if (dir == dirForward)
            {
                for (int i = 0; i < steps; i++)
                {
                    pos = MoveForwardInArray(pos, size, arr.Length);
                    sumForward += arr[pos];
                }
            }
            else if (dir == dirBackwards)
            {
                for (int i = 0; i < steps; i++)
                {
                    pos = MoveBackwardInArray(pos, size, arr.Length);
                    sumBackwards += arr[pos];
                }
            }
            else
            {
                throw new Exception("Invalid dir");
            }
        }

        Console.WriteLine($"Forward: {sumForward}");
        Console.WriteLine($"Backwards: {sumBackwards}");

    }

    private static int MoveForwardInArray(int pos, int step, int length)
    {
        return (pos + step) % length;
    }

    private static int MoveBackwardInArray(int pos, int step, int length)
    {
        pos = (pos - step) % length;

        if (pos < 0)
        {
            pos += length;
        }

        return pos;
    }
}


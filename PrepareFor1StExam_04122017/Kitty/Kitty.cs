using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Kitty
{
    static int food = 0;
    static int souls = 0;
    static int deadlocks = 0;
    static int currentPosition = 0;
    static string str;
    static int[] path;
    static int jumps = 0;
    static int direction = 0;
    static char[] sb;

    static void PathGeneral(int[] path)
    {
        if (str[direction] == '@')
        {
            souls++;
            sb[direction] = '0';
        }
        else if (str[direction] == '*')
        {
            food++;
            sb[direction] = '0';
        }
        else if (sb[direction] == 'x')
        {
            if (true)
            {

            }
        }
        for (int i = 0; i < path.Length; i++)
        {
            direction = path[i];
            if (direction > 0)
            {
                PathRight(direction);
            }
            else if (direction < 0)
            {
                PathLeft(direction);
            }
        }
    }

    static void PathLeft(int direction)
    {
        food = 1;
    }

    static void PathRight(int direction)
    {
       
    }

    static void Main()
    {
        str = Console.ReadLine();
        path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        sb = str.Split().Select(char.Parse).ToArray();
      
        if (str[0] == 'x')
        {
            Console.WriteLine("You are deadlocked, you greedy kitty!");
            Console.WriteLine("Jumps before deadlock: 0");
            return;
        }

        PathGeneral(path);

        Console.WriteLine("Coder souls collected: {0}", souls);
        Console.WriteLine("Food collected: {0}", food);
        Console.WriteLine("Deadlocks: {0}", deadlocks);
    }
}

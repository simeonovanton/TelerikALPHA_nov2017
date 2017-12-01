using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Kitty
{
    static char[] str;
    static int[] path;
    static int food = 0;
    static int souls = 0;
    static int deadlocks = 0;
    static int currentPosition = 0;
    static int jumps = 0;
    static int index = 0;

    static void CheckDeadlock()
    {
        if (index % 2 == 0)
        {
            if (souls > 0)
            {
                souls--;
                str[index] = '@';
            }
            else
            {
                return;
            }
        }
        else
        {
            if (food > 0)
            {
                food--;
                str[index] = '*';
            }
            else
            {
                return;
            }
        }
    }
    static void PathGeneral()
    {
       
        if (str[currentPosition] == '@')
        {
            souls++;
            str[currentPosition] = '0';
        }
        else if (str[currentPosition] == '*')
        {
            food++;
            str[currentPosition] = '0';
        }
        else if (str[currentPosition] == 'x')
        {
            CheckDeadlock();
        }
        for (int index = 0; index < path.Length; index++)
        {
            currentPosition = path[i];
            if (currentPosition > 0)
            {
                PathRight();
            }
            else if (currentPosition < 0)
            {
                PathLeft();
            }
        }
    }

    static void PathLeft()
    {
        food = 1;
    }

    static void PathRight()
    {
       
    }

    static void Main()
    {
        str = Console.ReadLine().Split().Select(char.Parse).ToArray();
        path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
      
        if (str[0] == 'x')
        {
            Console.WriteLine("You are deadlocked, you greedy kitty!");
            Console.WriteLine("Jumps before deadlock: 0");
            return;
        }

        PathGeneral();

        Console.WriteLine("Coder souls collected: {0}", souls);
        Console.WriteLine("Food collected: {0}", food);
        Console.WriteLine("Deadlocks: {0}", deadlocks);
    }
}

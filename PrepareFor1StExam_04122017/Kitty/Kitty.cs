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

    static bool CheckDeadlock()
    {
        if (currentPosition % 2 == 0)
        {
            if (souls > 0)
            {
                souls--;
                str[currentPosition] = '@';
                
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (food > 0)
            {
                food--;
                str[currentPosition] = '*';
                
            }
            else
            {
                return true;
            }
        }
        return false;
    }
    static bool PathGeneral()
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
            deadlocks++;
            if (CheckDeadlock())
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: {0}", jumps);
                return true;
            }
           
        }
        return false;
    }

    static void Main()
    {
        str = Console.ReadLine().ToCharArray();
        path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        foreach (var move in path)
        {
            jumps++;
            currentPosition = (str.Length + currentPosition + move % str.Length) % str.Length;
            if (PathGeneral())
            {
                return;
            }

          
        }
        Console.WriteLine("Coder souls collected: {0}", souls);
        Console.WriteLine("Food collected: {0}", food);
        Console.WriteLine("Deadlocks: {0}", deadlocks);
    }
}

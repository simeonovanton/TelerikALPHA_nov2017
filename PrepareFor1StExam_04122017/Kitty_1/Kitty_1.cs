using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Kitty_1
{
    static void Main()
    {
        // Input food, souls, deadloks ....
        char[] str = Console.ReadLine().ToCharArray();
        int[] path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int food = 0;
        int souls = 0;
        int deadlocks = 0;
        int jumps = 0;
        int currentPosition = 0;
        int i = 0;

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
            Console.WriteLine("You are deadlocked, you greedy kitty!\n\rJumps before deadlock: {0}", jumps);
            return;
        }

        do
        {
            jumps++;
            currentPosition = (str.Length + currentPosition + path[i] % str.Length) % str.Length;

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
                if (currentPosition % 2 == 0)
                {
                    if (souls > 0)
                    {
                        souls--;
                        str[currentPosition] = '@';
                        deadlocks++;
                    }
                    else
                    {
                        Console.WriteLine("You are deadlocked, you greedy kitty!\n\rJumps before deadlock: {0}", jumps);
                        return;
                    }
                }
                else 
                {
                    if (food > 0)
                    {
                        food--;
                        str[currentPosition] = '*';
                        deadlocks++;
                    }
                    else
                    {
                        Console.WriteLine("You are deadlocked, you greedy kitty!\n\rJumps before deadlock: {0}", jumps);
                        return;
                    }
                }
            }
            i++;
        }
        while (i < path.Length);

        Console.WriteLine("Coder souls collected: {0}", souls);
        Console.WriteLine("Food collected: {0}", food);
        Console.WriteLine("Deadlocks: {0}", deadlocks);
    }
}


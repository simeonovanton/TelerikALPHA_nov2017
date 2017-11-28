﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class EnglishDigit
{
    static string ReturnLastDigit(string input)
    {
        switch (input[input.Length - 1])
        {
            case '0': return "zero";
            case '1': return "one";
            case '2': return "two";
            case '3': return "three";
            case '4': return "four";
            case '5': return "five";
            case '6': return "six";
            case '7': return "seven";
            case '8': return "eight";
            case '9': return "nine";
            default:
                return "Wrong Input!";
        }
    }

    static void Main()
    {
        Console.WriteLine(ReturnLastDigit(Console.ReadLine()));
    }
}

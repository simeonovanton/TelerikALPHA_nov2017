using System;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        GenericList<int> ints = new GenericList<int>(15);
        GenericList<string> strings = new GenericList<string>();

        ints.Add(4);
        ints.Add(5);
        

        strings.Add("John");

        Console.WriteLine(ints.Count);
        Console.WriteLine(ints.Capacity);
        Console.WriteLine(strings.Count);
        Console.WriteLine(strings.Capacity);
    }
}

public class GenericList<T>
{
    private List<T> elements;

    public GenericList(int capacity = 4)
    {
        this.elements = new List<T>(capacity);
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }
    public int Capacity
    {
        get
        {
            return this.elements.Capacity;
        }
    }
}
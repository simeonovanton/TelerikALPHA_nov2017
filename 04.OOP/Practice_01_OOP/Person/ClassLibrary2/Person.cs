using System;


public class Person
{
    private string name;
    private int age;


    public Person(string name)
    {
        this.name = name;
    }

    public Person(string name, int age)
        : this(name)
    {
        this.age = age;
    }

    public void PrintName()
    {
        Console.WriteLine($"Person's name is: {this.name}");
    }

    public void PrintAge()
    {
        Console.WriteLine($"Person's age is:{this.age}");
    }
}

public class Program
{
    static void Main()
    {
        Person Goshko = new Person("Goshko", 14);
        Person Mitko = new Person("Mitko", 15);

        Goshko.PrintName();
        Goshko.PrintAge();
        Console.WriteLine("==================");
        Mitko.PrintName();
        Mitko.PrintAge();
    }
}


using System;

public class Program
{
    public static void Main()
    {
        var f1 = new Fraction(1, 2);
        var f2 = new Fraction(1, 2);

        Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
        Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
        Console.WriteLine($" -{f1} = {-f1}");
        Console.WriteLine($"f1 Hash Code is: {f1.GetHashCode()}");
    }
}

class Fraction
{
    private long numerator;
    private long denominator;

    public Fraction(long numerator, long denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public override int GetHashCode()
    {
        return this.numerator.GetHashCode();
    } 

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        long num = f1.numerator * f2.denominator +
        f2.numerator * f1.denominator;
        long denom = f1.denominator * f2.denominator;
        return new Fraction(num, denom);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        long num = f1.numerator * f2.denominator -
        f2.numerator * f1.denominator;
        long denom = f1.denominator * f2.denominator;
        return new Fraction(num, denom);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        long num = f1.numerator * f2.numerator;
        long denom = f1.denominator * f2.denominator;
        return new Fraction(num, denom);
    }

    public static Fraction operator -(Fraction fraction)
    {
        long num = -fraction.numerator;
        long denom = fraction.denominator;
        return new Fraction(num, denom);
    }

    // Operator ++ (the same for prefix and postfix form)
    public static Fraction operator ++(Fraction fraction)
    {
        long num = fraction.numerator + fraction.denominator;
        long denom = fraction.denominator;
        return new Fraction(num, denom);
    }

    // returns it in double format
    public override string ToString()
    {
        return ((double)this.numerator / this.denominator).ToString();
    }

}
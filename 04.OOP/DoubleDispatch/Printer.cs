using System;

namespace DoubleDispatch
{
	public class Printer
	{
		//protected string Name;

		public Printer()
		{
			//this.Name = "Printer";
		}

		public virtual void Print(Shape shape)
		{
			//Console.WriteLine($"{this.Name} printing a shape");
            Console.WriteLine($"Printer printing a shape");
		}

		public virtual void Print(Triangle triangle)
		{
			//Console.WriteLine($"{this.Name} printing a triangle");
            Console.WriteLine($"Printer printing a triangle");
		}
	}
}

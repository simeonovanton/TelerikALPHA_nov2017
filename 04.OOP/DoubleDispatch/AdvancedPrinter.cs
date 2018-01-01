using System;

namespace DoubleDispatch
{
	public class AdvancedPrinter : Printer
	{
		public AdvancedPrinter()
		{
			//this.Name = "Advanced printer";
		}

		public override void Print(Shape shape)
		{
			//Console.WriteLine($"{this.Name} printing a shape");
            Console.WriteLine($"Advanced printer printing a shape");
		}

		public override void Print(Triangle triangle)
		{
			//Console.WriteLine($"{this.Name} printing a triangle");
            Console.WriteLine($"Advanced printer printing a triangle");
		}
	}
}

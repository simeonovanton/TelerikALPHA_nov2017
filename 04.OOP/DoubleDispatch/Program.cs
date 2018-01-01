namespace DoubleDispatch
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Shape shape = new Shape();
			Triangle triangle = new Triangle();
			var printer = new Printer();
			printer.Print(shape);
			printer.Print(triangle);
			Printer advancedPrinter = new AdvancedPrinter();
			advancedPrinter.Print(shape);
			advancedPrinter.Print(triangle);
			// So far so good: single dispatching i.e. virtual method resolution works as expected.
			Shape secondTriangle = new Triangle();
			// But now we have a problem: overloaded methods resolutions is static i.e. the overload picked up is determined by the type of variable not the type of instance it holds.
			// The expected result would be "Advanced printer printing a triangle".
			advancedPrinter.Print(secondTriangle);
		}
	}
}

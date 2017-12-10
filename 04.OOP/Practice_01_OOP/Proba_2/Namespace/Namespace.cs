using System;

//namespace Outer.Inner
namespace SomeNamespace
{
    public class MyClass
    {
        public static double GetPiValue()
        {
            // This will not compile because
            // the compiler searches first the Outer namespace
            // and there is our Math class which
            // does not have PI property
            return Math.PI;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var pi = MyClass.GetPiValue();
            Console.WriteLine(pi);
        }
    }
}

namespace Outer.NewInner
{
    using System;

    public class MyClass
    {
        public static double GetPiValue()
        {
            // Here the copiler searcher first System namespace
            // and founds the PI in the System.Math class
            return Math.PI;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var pi = MyClass.GetPiValue();
        }
    }
}

namespace Outer
{
    // My math class
    class Math
    {
    }
}


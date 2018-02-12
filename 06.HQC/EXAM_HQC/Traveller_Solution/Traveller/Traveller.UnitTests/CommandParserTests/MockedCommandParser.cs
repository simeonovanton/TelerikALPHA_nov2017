using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Providers;

namespace Traveller.UnitTests.CommandParserTests
{
    class MockedCommandParser : CommandParser
    {
        public MockedCommandParser(IComponentContext container)
            : base(container)
        {
           
        }

        public IComponentContext Container { get { return base.container; } }
    }
}

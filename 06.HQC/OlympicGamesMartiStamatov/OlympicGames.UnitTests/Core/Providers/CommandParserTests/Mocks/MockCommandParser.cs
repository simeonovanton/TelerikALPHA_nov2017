using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.UnitTests.Core.Providers.CommandParserTests.Mocks
{
    public class MockCommandParser : CommandParser
    {
        public ICommandFactory ExposedCommandFactory { get { return this.CmdFactory; } }

        public MockCommandParser(ICommandFactory cmdFactory)
            : base(cmdFactory)
        {

        }
    }
}

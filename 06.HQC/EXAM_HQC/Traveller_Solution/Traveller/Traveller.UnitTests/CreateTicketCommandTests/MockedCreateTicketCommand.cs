using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.CreateTicketCommandTests
{
    class MockedCreateTicketCommand : CreateTicketCommand
    {
        public MockedCreateTicketCommand(IDataBase data, ITravellerFactory factory, Constants constants)
            :base(data, factory, constants)
        {
         
        }

        public IDataBase exposedData { get { return base.data; } }
        public ITravellerFactory exposedFactory { get { return base.factory; } }
        public Constants exposedConstants { get { return base.constants; } }
    }
}

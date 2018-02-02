
using OlympicGames.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Core.Providers.Decorators
{
    class CommandProcessorDecorator : ICommandProcessor
    {
        private readonly ICommandProcessor processor;
        private readonly IIoWrapper iowrapper;
        public ICollection<ICommand> Commands => throw new NotImplementedException();

        public void ProcessSingleCommand(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}

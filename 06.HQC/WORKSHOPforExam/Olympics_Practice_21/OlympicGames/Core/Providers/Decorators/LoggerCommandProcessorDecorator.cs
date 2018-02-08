using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers.Decorators
{
    public class LoggerCommandProcessorDecorator : ICommandProcessor
    {
        private readonly ICommandProcessor processor;
        private readonly IIoWrapper ioWrapper;

        public LoggerCommandProcessorDecorator(ICommandProcessor processor, IIoWrapper ioWrapper)
        {
            this.processor = processor;
            this.ioWrapper = ioWrapper;
        }
        public ICollection<ICommand> Commands => this.processor.Commands;

        public void ProcessSingleCommand(ICommand command)
        {
            this.processor.ProcessSingleCommand(command);
            this.ioWrapper.WriteWithWrapper($"-- [{DateTime.Now}] Processed Command --");
            //-- [01.02.2018 13:45:23] Processed Command --
        }
    }
}

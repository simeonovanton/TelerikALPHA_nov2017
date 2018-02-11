using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Decorators
{
    public class LoggerListCommand : ICommand
    {
        private readonly ICommand command;
        private readonly IConsoleWriter writer;

        public LoggerListCommand(ICommand command, IConsoleWriter writer)
        {
            this.command = command;
            this.writer = writer;
        }
        public string Execute()
        {
            this.writer.WriteLine("Executing list by decorated LOGGERLISTCOMMAND");
            return this.command.Execute();
        }
    }
}

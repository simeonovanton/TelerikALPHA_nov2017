using System;
using System.Linq;
using System.Reflection;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory cmdFactory;

        public CommandParser(ICommandFactory cmdFactory)
        {
            if (cmdFactory == null)
            {
                throw new ArgumentNullException();
            }
            this.cmdFactory = cmdFactory;
        }

        protected ICommandFactory CmdFactory => cmdFactory;

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0];
            var parameters = lineParameters.Skip(1);
            var command = this.CmdFactory.Create(commandName);
            return command;
        }

    }
}

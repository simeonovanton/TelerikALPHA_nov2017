﻿using System;
using System.Collections.Generic;
using System.Linq;

using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor()
        {
            this.Commands = new List<ICommand>();
        }

        public ICollection<ICommand> Commands { get; private set; }

        public void Add(ICommand command)
        {
            this.Commands.Add(command);
        }

        public void ProcessCommands()
        {
            foreach (var command in this.Commands)
            {
                var result = command.Execute();
                var normalizedOutput = this.NormalizeOutput(result);
                Console.WriteLine(normalizedOutput);
            }
        }

        public void ProcessSingleCommand(ICommand command)
        {
            var result = command.Execute();
            var normalizedOutput = this.NormalizeOutput(result);
            Console.WriteLine(normalizedOutput);
        }

        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}
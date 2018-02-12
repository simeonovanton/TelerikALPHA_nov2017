﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;

namespace Traveller.Core.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Traveller.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandLine);
    }
}

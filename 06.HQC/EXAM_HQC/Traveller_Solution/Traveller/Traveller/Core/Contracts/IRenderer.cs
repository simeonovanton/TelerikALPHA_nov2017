﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveller.Core.Contracts
{
    public interface IRenderer
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> output);
    }
}

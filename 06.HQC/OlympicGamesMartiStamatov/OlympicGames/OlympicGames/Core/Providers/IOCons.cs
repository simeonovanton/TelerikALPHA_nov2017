using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Core.Providers
{
    class IOWrapper
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;

        public IOWrapper(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }
        public string ReadLine()
        {
            return reader.ReadLine();
        }

        public void WriteLine(string text)
        {
            writer.WriteLine(text);
        }
    }
}

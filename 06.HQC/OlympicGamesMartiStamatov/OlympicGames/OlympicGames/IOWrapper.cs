using OlympicGames.Core.Providers;

namespace OlympicGames
{
    public class IOWrapper : IIOWrapper
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;

        public IOWrapper(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }
        public string ReadWithWrapper()
        {
            return this.reader.ReadLine();
        }

        public void WriteWithWrapper(string msg)
        {
            this.writer.WriteLine(msg);
        }
    }
}
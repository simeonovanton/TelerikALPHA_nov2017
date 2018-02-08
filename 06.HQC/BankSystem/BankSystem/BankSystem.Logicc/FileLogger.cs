using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankSystem.Logic
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", $"[{DateTime.Now}] {message}{Environment.NewLine}");

        }
    }
}

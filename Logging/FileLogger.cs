using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    internal class FileLogger : Logger
    {
        private string filePath = "log.txt";

        protected override void WriteLog(string message)
        {
            File.AppendAllText(filePath, message + "\n");
        }
    }
}

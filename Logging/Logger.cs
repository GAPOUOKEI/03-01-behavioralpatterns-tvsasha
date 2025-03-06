using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    abstract class Logger
    {
        public void Log(string message)
        {
            string formattedMessage = FormatMessage(message);
            WriteLog(formattedMessage);
        }

        protected virtual string FormatMessage(string message)
        {
            return $"[{DateTime.Now}] {message}";
        }

        protected abstract void WriteLog(string message);
    }
}

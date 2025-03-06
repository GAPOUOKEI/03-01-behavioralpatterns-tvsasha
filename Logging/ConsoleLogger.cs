using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    internal class ConsoleLogger : Logger
    {
        protected override void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}

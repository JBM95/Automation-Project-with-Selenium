using AventStack.ExtentReports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Library.Helpers
{
    public static class Logger
    {
        public static void WriteLine(string output, bool logToTestExplorer = true)
        {
            if (string.IsNullOrEmpty(output))
            {
                return;
            }

            Debug.WriteLine(output);

            if (!logToTestExplorer)
            {
                return;
            }

            Console.WriteLine(output);
        }

        public static void WriteLine(string message, object output)
        {
            WriteLine($"{message}\r\n{JsonConvert.SerializeObject(output, Formatting.Indented)}");
        }

        public static void WriteDebugLog(string output)
        {
            WriteLine(output, logToTestExplorer: false);
        }

    }
}

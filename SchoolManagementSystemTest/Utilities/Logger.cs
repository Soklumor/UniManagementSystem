using System;
using System.IO;

namespace SchoolManagementSystemTest.Utilities
{
    public static class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}

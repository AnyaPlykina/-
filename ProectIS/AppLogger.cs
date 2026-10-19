using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ProectIS
{
    public class AppLogger
    {
        private static AppLogger _instance;
        private static readonly object _lock = new object();
        private readonly string logPath;

        private AppLogger()
        {
            logPath = "informations.log";
        }

        public static AppLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new AppLogger();
                    }
                }
                return _instance;
            }
        }

        public void Info(string message)
        {
            string str = $"{DateTime.Now} Info: {message}";
            Console.WriteLine(str);
            lock (_lock)
            {
                File.AppendAllText(logPath, str + "\n");
            }
        }

        public void PError(string context, Exception ex)
        {
            string str = $"{DateTime.Now} {context}: {ex.Message}";
            Console.WriteLine(str);
            lock (_lock)
            {
                File.AppendAllText(logPath, str + "\n");
            }
        }
    }
}

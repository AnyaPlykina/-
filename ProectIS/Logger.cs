using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProectIS
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private Logger() { }
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock) // Потокобезопасность
                    {
                        if (_instance == null)
                            _instance = new Logger();
                    }
                }
                return _instance;
            }
        }

        public void Info(string message)
        {
            Console.WriteLine($"[INFO]: {message}");
        }

        // Выводит контекст и системное сообщение об ошибке в поток ошибок (stderr)
        public void PError(string context, Exception ex)
        {
            Console.Error.WriteLine($"[ERROR] {context}: {ex.Message}");
        }
    }
}

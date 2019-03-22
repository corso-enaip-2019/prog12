using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public class Logger : ILogger
    {
        List<IWriter> _writers = new List<IWriter>();

        public void LogErr(string message, Exception exception)
        {
            foreach (IWriter writer in _writers)
            {
                string composedMessage = $"{LoggerDate()} CONSOLE: Error: {message} exeption message : {exception.Message}";
                writer.Write(composedMessage);
            }
        }

        public void LogInfo(string message)
        {
            foreach (IWriter writer in _writers)
            {
                string composedMessage = $"{LoggerDate()} CONSOLE: Info: {message}";
                writer.Write(composedMessage);
            }
        }

        public void AddWriter(IWriter writer)
        {
            _writers.Add(writer);
        }

        public void RemoveWriter(IWriter writer)
        {
            _writers.Remove(writer);
        }

        string LoggerDate()
        {
            return DateTime.Now.ToString();
        }

    }


}

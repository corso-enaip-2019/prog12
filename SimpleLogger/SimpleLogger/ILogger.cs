using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public interface ILogger
    {
        void LogErr(string message, Exception exception);
        void LogInfo(string message);
        void AddWriter(IWriter writer);
        void RemoveWriter(IWriter writer);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($"FILE IMPLEMENTATION:\t{message}");
        }
    }
}

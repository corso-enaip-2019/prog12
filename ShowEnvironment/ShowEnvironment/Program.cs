using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("'My Documents' folder is actually " +
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Console.WriteLine();

            int msec = Environment.TickCount;
            Console.WriteLine("Windows has been running for " +
                              msec + " milliseconds");
            Console.WriteLine("\tor " + msec / 3600000.0 + " hours");
            Console.WriteLine();

            Console.WriteLine("You are running " + Environment.OSVersion);
            Console.WriteLine("\tand .NET version " + Environment.Version);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

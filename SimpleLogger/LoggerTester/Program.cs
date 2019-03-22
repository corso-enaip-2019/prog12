

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger;


namespace LoggerTester
{
    class Program
    {
        static void Main(string[] args)
        {

            Logger logger = new Logger();

            IWriter fileWriter = new FileWriter();
            IWriter consoleWriter = new ConsoleWriter();

            logger.AddWriter(fileWriter);
            logger.AddWriter(consoleWriter);

            logger.LogErr("ERRORE Disastroso", new Exception("NULL Reference"));
            logger.LogInfo("INFO Disastroso");

            /*
            ILogger logger = new MockLogger(); ;

            logger.LogErr("Messaggio", new Exception("ERRORE"));
            logger.LogInfo("Messaggio");
            */

            Console.ReadKey(true);

        }
    }
}

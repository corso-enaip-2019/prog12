using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            Semaphore semaphoreA = new Semaphore(Semaphore.RED);
            Semaphore semaphoreB = new Semaphore(Semaphore.GREEN);

            while (true)
            {
                Console.WriteLine($"Semaphore(s) A status {semaphoreA.State}");
                Console.WriteLine($"Semaphore(s) B status {semaphoreB.State}");
                Console.WriteLine();

                string controllerStatus = controller.next();

                if (controllerStatus.Contains("A"))
                {
                    semaphoreA.change();
                }
                if (controllerStatus.Contains("B"))
                {
                    semaphoreB.change();
                }


                for (int i = 0 ; i< 1000000000; i++)
                {

                }
            }
        }
    }
}

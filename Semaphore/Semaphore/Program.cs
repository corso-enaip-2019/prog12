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

            string twoOrThreeLights;
            CrossRoadController controller = null;


            Console.WriteLine("Please insert '2' or '3' to specify the colors of traffic lights");

            do
            { 
                twoOrThreeLights = Console.ReadLine();

                switch (twoOrThreeLights)
                {
                    case "2":
                        controller =
                            new CrossRoadController(CrossRoadController.TWO_LIGHTS_SEMAPHORE);
                        break;
                    case "3":
                        controller =
                            new CrossRoadController(CrossRoadController.THREE_LIGHTS_SEMAPHORE);
                        break;
                    default:
                        Console.WriteLine("Error: the inserted value should be '2' or '3', please try again");
                        break;
                }
            }
            while (controller == null) ;

            while (true)
            {
                string[] semaphoresState = controller.GetSemaphoresState();

                for (int i = 0; i < semaphoresState.Length; i++)
                {
                    Console.WriteLine($"Semaphore n. {i + 1} status {semaphoresState[i]}");
                }

                Console.WriteLine();

                controller.Next();

                for (int i = 0 ; i< 1000000000; i++) {}
            }
        }
    }
}

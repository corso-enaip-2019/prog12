using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{
    class CrossRoadController
    {
        int _controllerState;

        const int CROSS_ROAD_SEMAPHORE_NUM = 4;

        public const int TWO_LIGHTS_SEMAPHORE = 0;
        public const int THREE_LIGHTS_SEMAPHORE = 1;

        Semaphore[] semaphore = new Semaphore[CROSS_ROAD_SEMAPHORE_NUM];

        string[] statesDiagram;

        static readonly string[] twoLightsStatesDiagram = { "AB" };
        static readonly string[] threeLightsStatesDiagram = { "AB", "B", "AB", "A" };

        public CrossRoadController(int kind)
        {
            _controllerState = 0;

            for (int i = 0; i < semaphore.Length; i++)
            {
                if (kind == TWO_LIGHTS_SEMAPHORE)
                {
                    semaphore[i] = 
                        new SemaphoreTwoColors(i % 2 == 0 ?
                            SemaphoreTwoColors.RED :
                            SemaphoreTwoColors.GREEN);

                    statesDiagram = twoLightsStatesDiagram;
                }
                else if (kind == THREE_LIGHTS_SEMAPHORE)
                {
                    semaphore[i] =
                        new SemaphoreThreeColors(i % 2 == 0 ?
                            SemaphoreThreeColors.RED :
                            SemaphoreThreeColors.GREEN);

                    statesDiagram = threeLightsStatesDiagram;
                }
                else
                {
                    Console.WriteLine("CrossRoadController: Error invalid parameter kind = {kind}.");
                }
            }
        }

        /// <summary>
        /// Switches the semaphores depending on stateDiagram, where the presence of "A" means
        /// the horizontal semaphores need to switch state, and "B" means switching the vertical
        /// semaphores.
        /// </summary>
        public void Next()
        {
            _controllerState = ++_controllerState % statesDiagram.Length;

            for (int i = 0; i < semaphore.Length; i++)
            {
                // semaphore with even index is switched only when statesDiagram contains A
                if (i % 2 == 0 && statesDiagram[_controllerState].Contains("A")) 
                {
                    semaphore[i].SwitchColor();
                }

                // semaphore with even index is switched only when statesDiagram contains B
                if (i % 2 == 1 && statesDiagram[_controllerState].Contains("B"))
                {
                    semaphore[i].SwitchColor();
                }
            }
        }

        /// <summary>
        /// Provide the state of all the semaphores in the crossroad.
        /// </summary>
        /// <returns>an array of strings expressing the coloro of the crossroad semaphores</returns>
        public string[] GetSemaphoresState()
        {
            string[] semaphoresState = new string[CROSS_ROAD_SEMAPHORE_NUM];

            for (int i = 0; i < semaphore.Length; i++)
            {
                semaphoresState[i] = semaphore[i].State;
            }

            return semaphoresState;
        }
    }
}

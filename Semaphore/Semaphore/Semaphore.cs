using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{
    abstract class Semaphore
    {
        const int red3      = 0,
                  yellow3   = 1,
                  green3    = 2,
                  red2      = 0,
                  green2    = 1;
        
        Lamp[] lamps;

        public Semaphore(int howManyLamps, int lampSwitchedOn)
        {
            if (howManyLamps == 2 || howManyLamps == 3)
            {
                if (lampSwitchedOn > 0 && lampSwitchedOn <= howManyLamps) {

                    lamps = new Lamp[howManyLamps];

                    for (int i = 0; i < lamps.Length; i++)
                    {
                        lamps[i] = new Lamp();

                        lamps[i].SwitchOff();

                        if (i == (lampSwitchedOn - 1))
                        {
                            lamps[i].SwitchOn();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Semaphore: Cannot switch-on not existent lamp!");
                }
            }
            else
            {
                Console.WriteLine("Semaphore: Error the class can be created with 2 or 3 lights!");
            }
        }

        public string State()
        {
            string result = null;

            switch (lamps.Length)
            {
                case 2:
                {
                    if (lamps[red2].IsSwitchedOn())
                    {
                        result = "red";
                    }
                    else
                    {
                        result = "green";
                    }
                }
                break;

                case 3:
                { 
                    if (lamps[red3].IsSwitchedOn())
                    {
                        result = "red";
                    }
                    else if (lamps[yellow3].IsSwitchedOn())
                    {
                        result = "yellow";
                    }
                    else
                    {
                        result = "green";
                    }
                }
                break;

                default:
                {
                    Console.WriteLine("Semaphore: Number of colors different from 2 and 3!");
                }
                break;
            }

            return result;
        }

        /// <summary>
        /// Switches the color of the semaphore as:
        ///     3 colors semaphore (Green -> Yellow -> Red)
        ///     2 colors semaphore (Green -> Red)
        /// </summary>
        public abstract void SwitchColor();

        /// <summary>
        /// Check if the value of the state is valid.
        /// </summary>
        /// <param name="state">It is the color, that is switched on in a particular moment</param>
        /// <returns>It is true if the passed value is an admissible value, false otherwise.</returns>
        public abstract bool IsValidState(string state);
    }
}

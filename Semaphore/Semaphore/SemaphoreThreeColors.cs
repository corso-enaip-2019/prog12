using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{

    class SemaphoreThreeColors : Semaphore
    {

        public const string RED = "red";
        public const string YELLOW = "yellow";
        public const string GREEN = "green";

        public SemaphoreThreeColors(string state) : base(state)
        {
        }

        public override void SwitchColor()
        {
            switch (State)
            {
                case RED:
                    State = GREEN;
                    break;
                case GREEN:
                    State = YELLOW;
                    break;
                case YELLOW:
                    State = RED;
                    break;
            }
        }

        public override bool IsValidState(string state)
        {
            return state.Equals(RED) ||
                   state.Equals(YELLOW) ||
                   state.Equals(GREEN);
        }
    }
}

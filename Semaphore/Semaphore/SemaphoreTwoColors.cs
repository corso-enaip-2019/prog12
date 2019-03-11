using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{

    class SemaphoreTwoColors : Semaphore
    {

        public const string RED = "red";
        public const string GREEN = "green";

        public SemaphoreTwoColors(string state) : base(state)
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
                    State = RED;
                    break;
            }
        }

        public override bool IsValidState(string state)
        {
            return state.Equals(RED) ||
                   state.Equals(GREEN);
        }

    }
}

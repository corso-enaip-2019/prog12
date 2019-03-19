using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{
    class Lamp
    {
        bool _isSwitchedOn;

        public Lamp()
        {
            SwitchOff();
        }

        public void SwitchOn()
        {
            _isSwitchedOn = true;
        }

        public void SwitchOff()
        {
            _isSwitchedOn = false;

        }

        public bool IsSwitchedOn()
        {
            return _isSwitchedOn;
        }
    }
}

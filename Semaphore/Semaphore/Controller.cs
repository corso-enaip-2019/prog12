using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{
    class Controller
    {
        int _state;

        string[] statesDiagram = {"AB", "B", "AB", "A" };

        public Controller()
        {
            _state = 0;
        }

        public string next()
        {
            _state = ++_state % 4;

            return statesDiagram[_state];
        }

        

    }
}

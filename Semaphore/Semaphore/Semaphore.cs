using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{

    class Semaphore
    {
        string _state;

        public const string RED = "red";
        public const string YELLOW = "yellow";
        public const string GREEN = "green";
    
        public Semaphore(string state)
        {
            State = state;
        }

        public string State
        {
            set
            {
                if (value.Equals(RED) || value.Equals(YELLOW) || value.Equals(GREEN))                {
                    _state = value;
                }
                else
                {
                    Console.WriteLine("Semaphore: Error invalid parameter.");
                }
            }
            get
            {
                return _state;
            }
        }

        public void change()
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
    }
}

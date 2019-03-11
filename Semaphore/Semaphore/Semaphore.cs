using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaphore
{
    abstract class Semaphore
    {
        string _state;

        public Semaphore(string state)
        {
            _state = state;
        }

        public string State
        {
            set
            {
                if (IsValidState(value))
                {
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

        public abstract void SwitchColor();

        public abstract bool IsValidState(string state);
    }
}

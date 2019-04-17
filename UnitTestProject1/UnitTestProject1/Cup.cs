using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    class Cup
    { 
        public bool IsFull { get; private set; }
        public void Fill()
        {
            if (IsFull)
                throw new InvalidOperationException("Cup already full!");

            IsFull = true;
        }
        public void Drink()
        {
            if (!IsFull)
                throw new InvalidOperationException("Cup is empty!");

            IsFull = false;
        }

        public int GetQuantity()
        {
 //           return -1;
            throw new NotImplementedException();
        }
   }
}

using System;

namespace Multiplier
{
    public delegate int dMultiplier(int factor);
    class Program
    {
        
        static void Main(string[] args)
        {
            var multiplier5 = CreateMultiplier(5);

            int result;

            result = multiplier5(7);
            result = multiplier5(9);

            var multiplier10 = CreateMultiplier(10);

            result = multiplier10(7);
            result = multiplier10(9);


        }

        static dMultiplier CreateMultiplier(int multiplierFactor)
        {

          //return delegate(int s) { return s * multiplierFactor; };
            return s => s * multiplierFactor;
        }
    }

    
}

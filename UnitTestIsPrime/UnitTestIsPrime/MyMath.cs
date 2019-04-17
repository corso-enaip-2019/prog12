using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestIsPrime
{
    public static class MyMath
    {
        /// <summary>
        ///  This method calculate if the provided number is prime or not.
        /// </summary>
        /// <param name="number">The number to verify if prime</param>
        /// <returns>
        ///     true if the number is prime
        ///     false otherwise
        /// </returns>
        public static bool IsPrime(int number)
        {
            bool result = true;

            if (number > 1)
            {
                //for (int i = 2; i < number; i++)
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
     }
}

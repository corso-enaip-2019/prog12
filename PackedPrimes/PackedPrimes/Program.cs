using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackedPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> primes = new List<int>();

            stopwatch.Start();
            for (int n = 2; n < 1000000; n++)
            {
                if (IsPrime(n))
                    primes.Add(n);
            }
            stopwatch.Start();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.ReadKey();
        }

        static bool IsPrime(int n)
        {
            int limit = (int)Math.Sqrt(n) + 1;

            for (int i = 2; i <= limit; i++)
            {
                if (n != i && n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

    }

}

using System;
using System.Linq;
using System.Diagnostics;

namespace PerformanceTester
{
    public delegate void DMethod();
    class Program
    {
        static void Main(string[] args)
        {
            long timing1, timing2;

            timing1 = Tester.Measure(new Primes().Prime1);
            timing2 = Tester.Measure(new Primes().Prime2);

            Console.WriteLine($"Prime1 took {timing1} millisecs, Prime2 took {timing2} millisecs");

            Console.ReadKey();
        }
    }

    class Tester
    {
        private Tester() { }

        public static long Measure(DMethod method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            method();
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

    }

    class Primes
    {
        const int MAX_NUMBER_TESTED = 1000000;

        public void Prime1()
        {
            int max=0;

            for (int i = 2; i <= MAX_NUMBER_TESTED; i++)
            {
                if (IsPrime(i))
                    max = i;
            }

            Console.WriteLine(max);
        }

        public void Prime2()
        {
            int max;
            int[] numbers = new int[MAX_NUMBER_TESTED];

            for (int i = 2; i < MAX_NUMBER_TESTED; i++)
            {
                numbers[i] = i;
            }

            for (int i = 2; i < MAX_NUMBER_TESTED; i++)
            {
                if (numbers[i] != 0)
                {
                    int multiply = 2;
                    int index = i * multiply;

                    while (index < MAX_NUMBER_TESTED)
                    {
                        numbers[index] = 0;
                        index = i * (++multiply);
                    }
                }
            }

            max = numbers.Last(x => x != 0);

            Console.WriteLine(max);
        }


        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            else if (number == 2)
                return true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

    }
}

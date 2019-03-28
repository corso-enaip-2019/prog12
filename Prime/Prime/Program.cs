using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int howMany;

            Console.WriteLine("Compute the first n prime numbers (n >= 1)");

            howMany = ReadInteger("Please insert how many prime numbers to calculate: ");

            List<int> primes = GetFirstPrimeNumbers(howMany);
            PrintPrimeNumbers(primes);

            Console.ReadKey();
        }

        static List<int> GetFirstPrimeNumbers(int howMany)
        {
            int number = 2;
            List<int> primes = new List<int>();

            do
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
                number++;
            }
            while (primes.Count < howMany);

            return primes;
        }

        static void PrintPrimeNumbers(List<int> primes)
        {
            foreach (int number in primes)
            {
                Console.WriteLine(string.Format("The number {0,4} is prime!", number));
            }
        }

        static bool IsPrime(int n)
        {
            bool result = false;

            if (n > 1)
            {
                result = true;

                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        static int ReadInteger(string message)
        {
            int result;
            bool validInput;

            do
            {
                Console.Write(message);

                validInput = int.TryParse(Console.ReadLine(), out result);

                if (!validInput || result < 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("The value provided is invalid or less than 1! Please try again...");
                    Console.WriteLine();

                }
            }
            while (!validInput || result < 1);

            return result;
        }
    }
}

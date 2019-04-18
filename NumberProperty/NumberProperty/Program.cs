using System;

namespace NumberProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER = 22;

            PrintIfProperty(NUMBER, "prime", IsPrime);
            PrintIfProperty(NUMBER, "triangular", IsTriangular);
            PrintIfProperty(NUMBER, "even", IsEven);

            Console.ReadKey();
        }

        static void PrintIfProperty(int number, string description, DCheckProperty method)
        {
            if (method(number))
                Console.WriteLine($"{number} is {description }");
        }


        delegate bool DCheckProperty(int number);

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        static bool IsTriangular(int number)
        {

            return true;
        }

        static bool IsEven(int number)
        {
            if (number % 2 == 0)
                return true;

            return false;
        }

    }
}

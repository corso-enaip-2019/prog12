using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAll();
        }


        static void Exercise_1_1()
        {
            Console.WriteLine("Exercise_1_1");
            Console.WriteLine();

            Console.WriteLine("The answer to all the quesions is " + "42");

            Console.ReadKey();
        }

        static void Exercise_1_2()
        {
            const int Divider = 42;

            Console.WriteLine("Exercise_1_2");
            Console.WriteLine();

            Console.WriteLine($"Divisibility by {Divider}");
            Console.WriteLine();

            int number = ReadInteger("Please insert the number to test: ");

            if (number % Divider == 0)
            {
                Console.WriteLine($"The number {number} is divisible by {Divider}");
            }
            else
            {
                Console.WriteLine($"The number {number} is not divisible by {Divider}");
            }

            Console.ReadKey();
        }

        static void Exercise_2_0()
        {
            double number = 24.55;
            double doubleNumer = 2.0 * number;
            double tripleNumer = 3.0 * number;

            Console.WriteLine("Exercise_2_0");
            Console.WriteLine();

            Console.WriteLine("The double of " + number + " is " + doubleNumer);
            Console.WriteLine("The triple of " + number + " is " + tripleNumer);

            Console.ReadKey();
        }

        static void Exercise_3_1()
        {
            Console.WriteLine("Exercise_3_1");
            Console.WriteLine();

            for (int number = 1; number <= 100; number++ )
            {
                if (number % 3 == 0 && number % 5 == 0)
                {

                }

                //if (number % 3 == 0 && number % 5 == 0)
                if (number % 15 == 0)
                {
                    Console.WriteLine($"The number {number} is divisible by 3 and 5.");
                }

            }

            Console.ReadKey();
        }


        static void RunAll()
        {
//            Exercise_1_1();
//            Exercise_1_2();
//            Exercise_2_0();
            Exercise_3_1();

        }

        static int ReadInteger(string message)
        {
            int result;
            bool validInput;

            do
            {
                Console.Write(message);

                validInput = int.TryParse(Console.ReadLine(), out result);

                if (!validInput)
                {
                    Console.WriteLine();
                    Console.WriteLine("The value provided is invalid! Please try again...");
                    Console.WriteLine();
                }
            }
            while (!validInput);

            return result;
        }

    }
}

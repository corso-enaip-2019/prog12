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
            int number;
            int counter;
            Console.WriteLine("Exercise_3_1");
            Console.WriteLine();

            for (number = 1; number <= 100; number++ )
            {
                //if (number % 3 == 0 && number % 5 == 0)
                if (number % 15 == 0)
                {
                    Console.WriteLine($"The number {number} is divisible by 3 and 5.");
                }

                //if (number % 3 == 0 || number % 5 == 0)
                if (number % 3 == 0)
                {
                    Console.WriteLine($"The number {number} is divisible by 3.");
                }

                if (number % 5 == 0)
                {
                    Console.WriteLine($"The number {number} is divisible by 5.");
                }
            }

            number = 1;
            counter = 0;

            Console.WriteLine();

            while (counter < 100)
            {
                if (number % 3 == 0 || number % 5 == 0)
                {
                    Console.WriteLine($"The number {number} is divisible by 3 or 5.");
                    counter++;
                }
                number++;
            }

            Console.ReadKey();
        }

        static void Exercise_3_2()
        {
            for (int number = 1; number <= 100; number++)
            {
                if (number % 3 == 0)
                {
                    Console.WriteLine("fizz");
                }
                else if (number % 5 == 0)
                {
                    Console.WriteLine("buzz");
                }
                else
                {
                    Console.WriteLine(number);
                }
            }

            Console.ReadKey();
        }

        static void Exercise_4_0()
        {
            string s1, s2, s3;

            s1 = "Hello";
            s2 = "World";

            s3 = s1 + s2;
            Console.WriteLine(s3);

            s3 = s2 + s1;
            Console.WriteLine(s3);

            Console.ReadKey();
        }

        static void Exercise_5_1()
        {
            int number1, number2;

            number1 = ReadInteger("Insert the first  number: ");
            number2 = ReadInteger("Insert the second number: ");

            Console.WriteLine();

            Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
            Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
            Console.WriteLine($"{number1} * {number2} = {number1 * number2}");

            if (number2 != 0) { 
                Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
                Console.WriteLine($"{number1} % {number2} = {number1 % number2}");
            }
            else
            {
                Console.WriteLine($"{number1} / {number2} = cannot be computed because the second number is zero");
                Console.WriteLine($"{number1} % {number2} = cannot be computed because the second number is zero");
            }

            Console.ReadKey();
        }

        static void Exercise_5_2()
        {
            int number1, number2;
            string result, bar;

            number1 = ReadInteger("Insert the first  number: ");
            number2 = ReadInteger("Insert the second number: ");

            Console.WriteLine();

            result = $"== the sum is: {number1 + number2}! ==";
            bar = new string('=', result.Length);

            Console.WriteLine(bar);
            Console.WriteLine(result);
            Console.WriteLine(bar);

            result = $"== the difference is: {number1 - number2}! ==";
            bar = new string('=', result.Length);

            Console.WriteLine(bar);
            Console.WriteLine(result);
            Console.WriteLine(bar);

            result = $"== the multiplication is: {number1 * number2}! ==";
            bar = new string('=', result.Length);

            Console.WriteLine(bar);
            Console.WriteLine(result);
            Console.WriteLine(bar);

            if (number2 != 0)
            {
                result = $"== the division is: {number1 / number2}! ==";
                bar = new string('=', result.Length);

                Console.WriteLine(bar);
                Console.WriteLine(result);
                Console.WriteLine(bar);

                result = $"== the module is: {number1 % number2}! ==";
                bar = new string('=', result.Length);

                Console.WriteLine(bar);
                Console.WriteLine(result);
                Console.WriteLine(bar);
            }
            else
            {
                result = $"== the division is: {number1} / {number2} cannot be computed! ==";
                bar = new string('=', result.Length);

                Console.WriteLine(bar);
                Console.WriteLine(result);
                Console.WriteLine(bar);

                result = $"== the module for: {number1} % {number2} cannot be computed! ==";
                bar = new string('=', result.Length);

                Console.WriteLine(bar);
                Console.WriteLine(result);
                Console.WriteLine(bar);
            }

            Console.ReadKey();
        }

        static void Exercise_6_1()
        {
            string name, surname, work;
            int age;

            Console.WriteLine("Please provide the following data");

            name = AskForString("Name: ");
            surname = AskForString("Surname: ");
            age = ReadInteger("Age: ");
            work = AskForString("Work: ");

            Console.WriteLine();

            Console.WriteLine($"Name:    {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Age:     {age}");
            Console.WriteLine($"Work:    {work}");

            Console.ReadKey();
        }

        static void Exercise_6_2()
        {
            string name, surname, work;
            int age;

            Console.WriteLine("Please provide the following data");

            name = AskForString("Name: ");
            surname = AskForString("Surname: ");
            age = ReadInteger("Age: ");
            work = AskForString("Work: ");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Name:    {name}");

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Surname: {surname}");

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Age:     {age}");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Work:    {work}");

            Console.ReadKey();
        }

        static void RunAll()
        {
            //Exercise_1_1();
            //Exercise_1_2();
            //Exercise_2_0();
            //Exercise_3_1();
            //Exercise_3_2();
            //Exercise_4_0();
            //Exercise_5_1();
            //Exercise_5_2();
            //Exercise_6_1();
            Exercise_6_2();
        }

        static string AskForString(string message)
        {
            string result;
            bool validInput;

            Console.Write(message);

            result = Console.ReadLine();

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

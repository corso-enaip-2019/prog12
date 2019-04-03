using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            PrintLabelAndValueWithColor("Name: ",    name);
            PrintLabelAndValueWithColor("Surname: ", surname);
            PrintLabelAndValueWithColor("Age: ", age.ToString());
            PrintLabelAndValueWithColor("Work: ", work);

            Console.ReadKey();
        }

        static void PrintLabelAndValueWithColor(string label, string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(label);

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(value);
        }

        static void Exercise_7_0()
        {
            for (int i = -4; i < 20; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            for (int i = -4; i < 20; i +=3)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        static void Exercise_8_0()
        {
            int a = 2000000000;
            int b = 2000000000;
            int sum = a + b;

            Console.WriteLine(sum);
            Console.WriteLine();

            long la = 2000000000;
            long lb = 2000000000;
            long lsum = la + lb;

            Console.WriteLine(lsum);
            Console.WriteLine();

            // The following does not compile!!!!
/*
            BigInteger ba = new BigInteger(2000000000);
            BigInteger bb = new BigInteger(2000000000);
            BigInteger bsum = ba + bb;
*/
            Console.ReadKey();
        }

        static void Exercise_9_1()
        {
            PrintMatrix(1, 10);

            Console.ReadKey();
        }

        static void Exercise_9_2()
        {
            PrintMatrix(50, 60);

            Console.ReadKey();
        }

        static void PrintMatrix(int begin, int end)
        {
            int fieldSize = (end * end).ToString().Length + 1;
            string spacer = new string(' ', fieldSize);
            string format = "{0," + fieldSize + "}";

            Console.Write(spacer);

            for (int c = begin; c <= end; c++)
            {
                Console.Write(format, c);
            }
            Console.WriteLine();

            for (int r = begin; r <= end; r++)
            {
                Console.Write(format, r);

                for (int c = begin; c <= end; c++)
                {
                    Console.Write(format, r * c);
                }
                Console.WriteLine();
            }
        }

        static void Exercise_10_1()
        {
            int side;
            do
            {
                side = ReadInteger("Please type the side length: ");

                if (side < 1 || side > 20)
                {
                    Console.WriteLine("The value inserted is out of range (1-20). Try again...");
                }
            }
            while (side < 1 || side > 20);

            int fieldSize = side.ToString().Length + 1;
            string format = "{0," + fieldSize + "}";

            for (int r = 1; r <= side; r++)
            {
                for (int c = 1; c <= r; c++)
                {
                    Console.Write(format, c);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Exercise_10_2()
        {
            int side;
            do
            {
                side = ReadInteger("Please type the side length: ");

                if (side < 1 || side > 20)
                {
                    Console.WriteLine("The value inserted is out of range (1-20). Try again...");
                }
            }
            while (side < 1 || side > 20);

            Console.WriteLine();

            int fieldSize = side.ToString().Length + side.ToString().Length % 2 == 0 ? 3 : 4;
            int spaceDecrement = fieldSize / 2; 
            int spaceMax = side * spaceDecrement;
            string format = "{0," + fieldSize + "}";

            for (int r = 1; r <= side; r++)
            {
                spaceMax -= spaceDecrement;
                Console.Write(new string(' ', spaceMax));

                for (int c = 1; c <= r; c++)
                {
                    Console.Write(format, c);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Exercise_11_0()
        {
            int pbase;
            int pexp;

            pbase = ReadInteger("Please type the base on which compute the power: ");

            do
            {
                pexp = ReadInteger("Please the positive exponent: ");

                if (pexp < 0)
                {
                    Console.WriteLine("The exponent should be positive. Try again...");
                }
            }
            while (pexp < 0) ;

            Console.WriteLine($"The {pbase}^{pexp} = {pow(pbase, pexp)}");

            Console.ReadKey();
        }

        static int pow(int pbase, int pexp)
        {
            int result = 1;

            for (int i = 1; i <= pexp; i++)
            {
                result *= pbase;
            }

            return result; 
        }

        static void Exercise_12_0()
        {
            int a;
            int b;

            a = ReadInteger("Please type the first  factor of the multiplication: ");
            b = ReadInteger("Please type the second factor of the multiplication: ");

            int absa = Math.Abs(a);
            int absb = Math.Abs(b);

            int sa = Math.Sign(a);
            int sb = Math.Sign(b);

            int result = (sb != sa) ? -multiply(absa, absb) : multiply(absa, absb);

            Console.WriteLine($"The {a} * {b} = {result}");

            Console.ReadKey();
        }

        static int multiply(int a, int b)
        {
            int result = 0;

            for (int i = 1; i <= b; i++)
            {
                result += a;
            }

            return result;
        }

        static void Exercise_13_0()
        {
            int sum = 0;

            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0|| i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"The sum is {sum}");

            Console.ReadKey();
        }

        static void Exercise_14_1()
        {
            const int LIMIT = 1000;
            int f0 = 0;
            int f1 = 1;
            int f2;

            Console.WriteLine(f0);
            Console.WriteLine(f1);

            do
            {
                f2 = f1 + f0;
                if (f2 < LIMIT)
                {
                    Console.WriteLine(f2);
                }
                f0 = f1;
                f1 = f2;
            }
            while (f2 < LIMIT);

            Console.ReadKey();
        }

        static void Exercise_14_2()
        {
            const int LIMIT = 1000;
            BigInteger[] fibonacci = new BigInteger[LIMIT];

            fibonacci[0] = 0;
            fibonacci[1] = 1;

            int index = 2;

            do
            {
                fibonacci[index] = fibonacci[index - 1] + fibonacci[index - 2];
            }
            while (++index < LIMIT);

            foreach (BigInteger f in fibonacci)
                Console.WriteLine(f);

            Console.ReadKey();
        }

        static void Exercise_14_3()
        {
            const int LIMIT = 1000000;
            int f0 = 0;
            int f1 = 1;
            int f2;
            int sum = f0 + f1;

            Console.WriteLine(f0);
            Console.WriteLine(f1);
            
            do
            {
                f2 = f1 + f0;
                sum += f2;
                if (sum < LIMIT)
                {
                    Console.WriteLine(f2);
                }
                f0 = f1;
                f1 = f2;
            }
            while (sum < LIMIT);

            Console.ReadKey();
        }

        static void Exercise_15_0()
        {
            int i = 0;

            start_loop: if ((i >= 10)) goto exit_loop;
            {
                Console.WriteLine(i);
                i++;
            }
            goto start_loop;
            exit_loop:

            Console.ReadKey();
        }

        static void Exercise_16_0()
        {
            int number;
            do
            {
                number = ReadInteger("Please type the number to convert: ");

                if (number < 1)
                {
                    Console.WriteLine("The value to convert should be postive (> 0). Try again...");
                }
            }
            while (number < 1);

            PrintBinary(number);

            Console.ReadKey();
        }

        static void PrintBinary(int n)
        {
            bool flag = false;
            int mask = 1 << 30;

            while (mask != 0)
            {
                int bit = n & mask;

                if (bit != 0)
                {
                    Console.Write(1);
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        Console.Write(0);
                    }
                }

                mask >>= 1;
            }
        }

        static void Exercise_17_0()
        {
            int number = ReadInteger("Please type the number to convert: ");

            Console.WriteLine($"The abs({number}) = {AbsInt(number)}");

            Console.ReadKey();
        }

        static int AbsInt(int n)
        {
            return (n < 0) ? -n : n;
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
            //Exercise_6_2();
            //Exercise_7_0();
            //Exercise_8_0();
            //Exercise_9_1();
            //Exercise_9_2();
            //Exercise_10_1();
            //Exercise_10_2();
            //Exercise_11_0();
            //Exercise_12_0();
            //Exercise_13_0();
            //Exercise_14_1();
            //Exercise_14_2();
            //Exercise_14_3();
            //Exercise_15_0();
            //Exercise_16_0();
            Exercise_17_0();
        }

        static string AskForString(string message)
        {
            string result;

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

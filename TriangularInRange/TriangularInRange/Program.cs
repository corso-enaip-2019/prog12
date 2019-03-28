﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangularInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed;
            int triangular;
            int lower, upper;
            Console.WriteLine("Triangular Numbers in Range");
            Console.WriteLine();

            do
            {
                lower = ReadInteger("Please insert the lower  value (positive integer): ");
                upper = ReadInteger("Please insert the higher value (positive integer): ");

                if (lower > upper)
                {
                    Console.WriteLine("The lower value should be less than the higher one!");
                }
            }
            while (lower > upper);

            // Formula retrieved from https://en.wikipedia.org/wiki/Triangular_number

            seed = (int)(Math.Sqrt(8 * lower + 1) - 1) / 2;

            Console.WriteLine("\r\nResults\r\n");

            do
            {
                seed++;
                triangular = seed * (seed + 1) / 2;
                if (triangular < upper)
                {
                    Console.WriteLine($"Triangular number is :{triangular}");
                }
            }
            while (triangular < upper);

            Console.ReadKey();
        }

        static int ReadInteger(string message)
        {
            int result;
            bool validInput;

            Console.Write(message);

            do
            {
                validInput = int.TryParse(Console.ReadLine(), out result);

                if (!validInput || result <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The value provided is not a valid integer or zero or negative! Please try again...");
                    Console.WriteLine();

                }
            }
            while (!validInput || result <= 0);

            return result;
        }
    }
}
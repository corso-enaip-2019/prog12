using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sides = new int[3];

            for (int side = 0; side < sides.Length; side++)
            {
                sides[side] = GetValidatedValue("Insert side " + (side + 1));
            }

            if (IsTriangle(sides[0], sides[1], sides[2]))
            {
                Console.WriteLine("It is a triangle!");
            }
            else
            {
                Console.WriteLine("It is not a triangle!");

                do
                {
                    ReduceLongestSide(sides);
                }
                while (!IsTriangle(sides[0], sides[1], sides[2]));

                Console.WriteLine($"... but these values can constitute one {sides[0]}, {sides[1]}, {sides[2]}.");
            }
            Console.ReadLine();
        }

        static void ReduceLongestSide(int[] v)
        {
            int max = Math.Max(Math.Max(v[0], v[1]), v[2]);
            int index = Array.IndexOf(v, max);

            v[index]--;

            return;
        }

        /// <summary>
        /// Check if the values (a, b, c) provided can costitute the sides of a triangle.
        /// </summary>
        /// <param name="a">side a of a triangle</param>
        /// <param name="b">side b of a triangle</param>
        /// <param name="c">side c of a triangle</param>
        /// <returns>true if a, b, c can be the sides of a triangle, false otherwise</returns>
        static bool IsTriangle(int a, int b, int c) 
        {
            bool result =
                a <          b + c  &&
                b <          a + c  &&
                c <          a + b  &&
                a > Math.Abs(b - c) &&
                b > Math.Abs(a - c) &&
                c > Math.Abs(a - b);

            return result;
        }

        /// <summary>
        /// Richiede e valida valore intero corrispondente a un lato del triangolo.
        /// Mostrando una stringa di messaggio di richiesta.
        /// </summary>
        /// <params name="message">Message displayed to request the measure of the triangle side</params>
        static int GetValidatedValue(string message)
        {
            int valueOut;
            string valueIn;
            bool validated;
            const string delimiter = ": ";

            do
            {
                Console.Write(message + delimiter);
                valueIn = Console.ReadLine();
                validated = int.TryParse(valueIn, out valueOut) && valueOut > 0;

                if (!validated)
                {
                    Console.WriteLine("A triangle side must be a positive integer!");
                }
            }
            while (!validated);

            return valueOut;
        }
    }
}

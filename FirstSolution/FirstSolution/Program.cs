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
            int a = GetValidatedValue("Insert side a");
            int b = GetValidatedValue("Insert side b");
            int c = GetValidatedValue("Insert side c");

            if (a < b + c           &&
                b < a + c           &&
                c < a + b           &&
                a > Math.Abs(b - c) &&
                b > Math.Abs(a - c) &&
                c > Math.Abs(a - b))
            {
                Console.WriteLine("It is a triangle!");
            }
            else
            {
                Console.WriteLine("It is not a triangle!");
            }
            Console.ReadLine();
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

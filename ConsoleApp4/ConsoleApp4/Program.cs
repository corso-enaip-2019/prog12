using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserire il nome della persoma");
            string name = Console.ReadLine();

        }

        static void PrintAllModes(string name, string surname, string gender, decimal salary)
        {
            PrintInLine(name, surname, gender, salary);
            Console.WriteLine();
            PrintLarge(name, surname, gender, salary);
        }

        static void PrintInLine(string name, string surname, string gender, decimal salary)
        {
            Console.Write($"nome: {name}; cognome: {surname}; genere: {gender}; salario: {salary}");
        }

        static void PrintLarge(string name, string surname, string gender, decimal salary)
        {
            Console.WriteLine($"nome: {name}");
            Console.WriteLine($"cognome: {surname}");
            Console.WriteLine($"genere: {gender}");
            Console.WriteLine($"salario: {salary}");
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistration
{
    class Program
    {
        const int CLASSES = 5;
        const char INPUT_OPTION = '1';
        const char PRINT_ALL_OPTION = '2';
        const char PRINT_PART_OPTION = '3';
        const char SEARCH_STUDENT_CLASS = '4';
        const char REMOVE_STUDENT = '5';
        const char QUIT_OPTION  = '6';

        static void Main(string[] args)
        {
            char option;
            Dictionary<int, List<string>> registry = AllocateRegistry();

            do
            {
                option = GetMenuOption();

                switch (option)
                {
                    case INPUT_OPTION:
                        InputRegistry(registry);
                        break;
                    case PRINT_ALL_OPTION:
                        PrintRegistry(registry);
                        break;
                    case PRINT_PART_OPTION:
                        PrintPartRegistry(registry);
                        break;
                    case SEARCH_STUDENT_CLASS:
                        SearchStudentClass(registry);
                        break;
                    case REMOVE_STUDENT:
                        RemoveStudent(registry);
                        break;
                }
            }
            while (option != QUIT_OPTION);
        }

        static char GetMenuOption()
        {
            char option;

            do
            {
                Console.WriteLine("Insert the option you wish");
                Console.WriteLine();
                Console.WriteLine("1. Insert data");
                Console.WriteLine("2. Print all classes");
                Console.WriteLine("3. Print single class");
                Console.WriteLine("4. Search student's class");
                Console.WriteLine("5. Remove student");
                Console.WriteLine("6. Quit");

                option = Console.ReadLine()[0];
            }
            while (option < INPUT_OPTION || option > QUIT_OPTION);

            return option;
        }


        
        static Dictionary<int, List<string>> AllocateRegistry()
        {
            Dictionary<int, List<string>> registry = new Dictionary<int, List<string>>();

            for (int i = 0; i < CLASSES; i++)
            {
                registry.Add(i, new List<string>());
            }
       
            return registry;
        }

        static void InputRegistry(Dictionary<int, List<string>> registry)
        {
            string name;
            int classNum;

            do
            {
                Console.WriteLine("Insert the student name (Press enter for exit input...)");
                Console.WriteLine("");

                name = Console.ReadLine();
                
                if (!name.Equals(""))
                {
                    classNum = InsertClass("Insert the class of the student: ");
                    registry[classNum - 1].Add(name);

                    Console.WriteLine("");
                }
            }
            while (!name.Equals(""));

            return;
        }

        static int InsertClass(string message)
        {
            int classNum;
            bool result = false;
            do
            {

                Console.Write(message);
                result = int.TryParse(Console.ReadLine(), out classNum) ;

                if (!result || classNum < 1 || classNum > CLASSES)
                {
                    Console.WriteLine();
                    Console.WriteLine($"The value for the class is invalid (must be: 1 <= class <= {CLASSES}).");
                    Console.WriteLine();

                }
            }
            while (!result || classNum < 1 || classNum > CLASSES);

            return classNum;
        }

        static void PrintRegistry(Dictionary<int, List<string>> registry)
        {
            for (int classNum = 0; classNum < CLASSES; classNum++)
            {
                Console.WriteLine($"Class {classNum + 1}:");

                if (registry[classNum].Count > 0)
                {

                    foreach (string name in registry[classNum])
                    {
                        Console.WriteLine($"\t{name} ");
                    }
                }
                else
                {
                    Console.WriteLine("\tClass empty");
                }
            }
        }

        static void SearchStudentClass(Dictionary<int, List<string>> registry)
        {

            Console.WriteLine("Insert the student name you are looking for: ");
            Console.WriteLine("");
            string name = Console.ReadLine();

            if (!name.Equals("")) {

                for (int classNum = 0; classNum < CLASSES; classNum++)
                {

                    if (registry[classNum].Contains(name))
                    {
                        Console.WriteLine($"Class {classNum + 1}:");
                    }
                }
            }
        }

        static void RemoveStudent(Dictionary<int, List<string>> registry)
        {

            Console.WriteLine("Insert the student name you wish remove: ");
            Console.WriteLine("");
            string name = Console.ReadLine();
            List<int> presence = new List<int>();

            if (!name.Equals(""))
            {
                for (int classNum = 0; classNum < CLASSES; classNum++)
                {
                    if (registry[classNum].Contains(name))
                    {
                        int count = 0;
                        presence.Add(classNum);
                        Console.WriteLine($"Class {classNum + 1}:");
                        foreach (string nm in registry[classNum])
                        {
                            if (nm.Equals(name))
                            {
                                count++;
                            }
                        }

                        Console.WriteLine($"There are {count}: '{name}'");
                    }
                }

                if (presence.Count == 1)
                {
                    registry[presence[0]].Remove(name);
                }
                else if (presence.Count > 1)
                {
                    int classNum = 0;
                    Console.WriteLine();
                    Console.WriteLine("");

                    do
                    {
                        classNum = InsertClass("From which class do you want remove: ");
                    }
                    while (!presence.Contains(classNum - 1));

                    registry[classNum - 1].Remove(name);
                }
            }
        }

        static void PrintPartRegistry(Dictionary<int, List<string>> registry)
        {

            int classNum = InsertClass("What class would you print: ");

            classNum--;
            Console.WriteLine($"Class {classNum + 1}:");

            Console.WriteLine($"Students number: {registry[classNum].Count}");

            if (registry[classNum].Count > 0)
            {

                foreach (string name in registry[classNum])
                {
                    Console.WriteLine($"\t{name} ");
                }
            }
            else
            {
                Console.WriteLine("\tClass empty");
            }
        }

    }
}

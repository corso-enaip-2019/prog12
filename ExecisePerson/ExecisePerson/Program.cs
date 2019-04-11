using System;

namespace ExecisePerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Person
    {
        string FullName { get; set; }
        int Age { get; set; }
        decimal Salary { get; set; }

        ISaver Saver { set; }
    }

    interface ISaver
    {
        void Save(Person p);
    }


    class JsonSaver : ISaver
    {
        string Path { get; set; }
        JsonSaver (String path)
        {
            Path = path;
        }
        void Save(Person person)
        {

        }
    }

}


